#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public static unsafe partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwVulkanSupported();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte** glfwGetRequiredInstanceExtensions(uint* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void* glfwGetInstanceProcAddress(nint instance, byte* procname);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetPhysicalDevicePresentationSupport(nint instance, nint device, uint queuefamily);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwCreateWindowSurface(nint instance, WindowPtr window, nint allocator, nint surface);
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
