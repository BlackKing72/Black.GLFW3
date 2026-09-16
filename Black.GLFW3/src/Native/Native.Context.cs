
#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public static unsafe partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwMakeContextCurrent(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowPtr glfwGetCurrentContext();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSwapInterval(int interval);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwExtensionSupported(byte* extension);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void* glfwGetProcAddress(byte* procname);
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
