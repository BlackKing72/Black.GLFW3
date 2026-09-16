#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public unsafe static partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetWin32Adapter(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetWin32Monitor(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetWin32Window(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetWGLContext(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetCocoaMonitor(MonitorPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetCocoaWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetCocoaView(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetNSGLContext(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetX11Display();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetX11Adapter(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetX11Monitor(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetX11Window(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetX11SelectionString(byte* @string);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetX11SelectionString();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetGLXContext(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetGLXWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetGLXFBConfig(WindowPtr window, nint config);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetWaylandDisplay();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetWaylandMonitor(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetWaylandWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetEGLDisplay();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetEGLContext(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetEGLSurface(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetEGLConfig(WindowPtr window, nint config);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetOSMesaColorBuffer(WindowPtr window, int* width, int* height, int* format, void** buffer);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetOSMesaDepthBuffer(WindowPtr window, int* width, int* height, int* bytesPerValue, void** buffer);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial nint glfwGetOSMesaContext(WindowPtr window);
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
