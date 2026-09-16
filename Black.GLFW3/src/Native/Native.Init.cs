#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public static unsafe partial class GLFWNative
{
    public const int NativeTrue = 1;
    public const int NativeFalse = 0;
    public const int NativeDontCare = -1;

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwInit();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwTerminate();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwInitHint(InitHint hint, int value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwInitAllocator(void* allocator);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwInitVulkanLoader(VKGetInstanceProcAddr loader);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetVersion(int* major, int* minor, int* rev);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetVersionString();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial ErrorCode glfwGetError(byte** description);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial ErrorCallback? glfwSetErrorCallback(ErrorCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial Platform glfwGetPlatform();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwPlatformSupported(Platform platform);
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
