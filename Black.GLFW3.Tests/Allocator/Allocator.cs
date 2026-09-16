//========================================================================
// Custom heap allocator test
// Copyright (c) Camilla Löwy <elmindreda@glfw.org>
//
// This software is provided 'as-is', without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would
//    be appreciated but is not required.
//
// 2. Altered source versions must be plainly marked as such, and must not
//    be misrepresented as being the original software.
//
// 3. This notice may not be removed or altered from any source
//    distribution.
//
//========================================================================

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Black.GLFW3;

internal class Allocator
{
    private delegate void ClearColor(float r, float g, float b, float a);
    private delegate void Clear(uint mask);

    private const uint ColorBufferBit = 0x00004000;

    private static void Main(string[] args)
    {
        // struct allocator_stats stats = {0};
        // const GLFWallocator allocator =
        // {
        //     .allocate = allocate,
        //     .deallocate = deallocate,
        //     .reallocate = reallocate,
        //     .user = &stats
        // };
        AllocatorStats allocatorStats = new();
        var allocator = new AllocatorPtr<AllocatorStats>(
            Allocate,
            Reallocate,
            Deallocate,
            ref allocatorStats
        );

        // glfwSetErrorCallback(error_callback);
        // glfwInitAllocator(&allocator);
        GLFW.SetErrorCallback(ErrorCallback);
        GLFW.InitAllocator(allocator);

        // if (!CALL(glfwInit)())
        //     exit(EXIT_FAILURE);
        if (!Call(() => GLFW.Init()))
            throw new Exception("Failed to initialize GLFW");

        // GLFWwindow* window = CALL(glfwCreateWindow)(400, 400, "Custom allocator test", NULL, NULL);
        // if (!window)
        // {
        //     glfwTerminate();
        //     exit(EXIT_FAILURE);
        // }
        WindowPtr window = Call(() => GLFW.CreateWindow(400, 400, "Custom allocator test"));
        if (window == WindowPtr.Null)
        {
            GLFW.Terminate();
            throw new Exception("Failed to create window");
        }

        // CALL(glfwMakeContextCurrent)(window);
        // gladLoadGL(glfwGetProcAddress);
        // CALL(glfwSwapInterval)(1);
        Call(() => GLFW.MakeContextCurrent(window));
        Call(() => GLFW.SwapInterval(1));

        var glClearColor = Marshal.GetDelegateForFunctionPointer<ClearColor>(
            GLFW.GetProcAddress("glClearColor")
        );
        var glClear = Marshal.GetDelegateForFunctionPointer<Clear>(GLFW.GetProcAddress("glClear"));

        // while (!CALL(glfwWindowShouldClose)(window))
        // {
        //     glClear(GL_COLOR_BUFFER_BIT);
        //     CALL(glfwSwapBuffers)(window);
        //     CALL(glfwWaitEvents)();
        // }
        while (!Call(() => GLFW.WindowShouldClose(window)))
        {
            glClearColor(0.400f, 0.200f, 0.600f, 1.000f);
            glClear(ColorBufferBit);
            Call(() => GLFW.SwapBuffers(window));
            Call(() => GLFW.WaitEvents());
        }

        Call(() => GLFW.Terminate());
        // CALL(glfwTerminate)();
        // exit(EXIT_SUCCESS);
    }

    static string functionName = "";

    static void Call(Action action, [CallerArgumentExpression(nameof(action))] string x = "")
    {
        functionName = x;
        action();
    }

    static T Call<T>(Func<T> action, [CallerArgumentExpression(nameof(action))] string x = "")
    {
        functionName = x;
        return action();
    }

    static void ErrorCallback(ErrorCode error, string description)
    {
        Console.WriteLine($"{error}: {description}");
    }

    static nint Allocate(nint size, ref AllocatorStats stats)
    {
        Debug.Assert(size > 0);

        stats.Total += size;
        stats.Current += size;
        if (stats.Current > stats.Maximum)
            stats.Maximum = stats.Current;

        //     printf("%s: allocate %zu bytes (current %zu maximum %zu total %zu)\n",
        //            function_name, size, stats->current, stats->maximum, stats->total);
        Console.WriteLine(
            $"{functionName}: allocate {size} bytes (current {stats.Current} maximum {stats.Maximum} total {stats.Total})"
        );

        //     size_t* real_block = malloc(size + sizeof(size_t));
        //     assert(real_block != NULL);
        //     *real_block = size;
        //     return real_block + 1;
        nint realBlock = Marshal.AllocCoTaskMem((int)(size + nint.Size));
        Debug.Assert(realBlock != nint.Zero);
        Marshal.WriteIntPtr(realBlock, size);
        return realBlock + nint.Size;
    }

    static void Deallocate(nint block, ref AllocatorStats stats)
    {
        // struct allocator_stats* stats = user;
        // assert(block != NULL);
        Debug.Assert(block != nint.Zero);

        // size_t* real_block = (size_t*) block - 1;
        // stats->current -= *real_block;
        nint realBlock = block - nint.Size;
        nint size = Marshal.ReadIntPtr(realBlock);
        stats.Current -= size;

        // printf("%s: deallocate %zu bytes (current %zu maximum %zu total %zu)\n",
        //     function_name, *real_block, stats->current, stats->maximum, stats->total);
        Console.WriteLine(
            $"{functionName}: deallocate {size} bytes (current {stats.Current} maximum {stats.Maximum} total {stats.Total})"
        );

        // free(real_block);
        Marshal.FreeCoTaskMem(realBlock);
    }

    // static void* reallocate(void* block, size_t size, void* user)
    static nint Reallocate(nint block, nint size, ref AllocatorStats stats)
    {
        // struct allocator_stats* stats = user;
        // assert(block != NULL);
        // assert(size > 0);
        Debug.Assert(block != nint.Zero);
        Debug.Assert(size > 0);

        // size_t* real_block = (size_t*) block - 1;
        // stats->total += size;
        // stats->current += size - *real_block;
        // if (stats->current > stats->maximum)
        //     stats->maximum = stats->current;
        nint realBlock = block - nint.Size;
        nint blockSize = Marshal.ReadIntPtr(realBlock);
        stats.Total += size;
        stats.Current += size - blockSize;
        if (stats.Current > stats.Maximum)
            stats.Maximum = stats.Current;

        // printf("%s: reallocate %zu bytes to %zu bytes (current %zu maximum %zu total %zu)\n",
        //     function_name, *real_block, size, stats->current, stats->maximum, stats->total);
        Console.WriteLine(
            $"{functionName}: reallocate {blockSize} bytes to {size} bytes (current {stats.Current} maximum {stats.Maximum} total {stats.Total})"
        );

        // real_block = realloc(real_block, size + sizeof(size_t));
        // assert(real_block != NULL);
        // *real_block = size;
        // return real_block + 1;
        realBlock = Marshal.ReAllocCoTaskMem(realBlock, (int)(size + nint.Size));
        Debug.Assert(realBlock != nint.Zero);
        Marshal.WriteIntPtr(realBlock, size);
        return realBlock + nint.Size;
    }
}

public struct AllocatorStats()
{
    public nint Total { get; set; } = 0;
    public nint Current { get; set; } = 0;
    public nint Maximum { get; set; } = 0;
};
