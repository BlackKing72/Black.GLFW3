#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    public static extern UnmanagedStr glfwGetWin32Adapter(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    public static extern UnmanagedStr glfwGetWin32Monitor(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetWin32Window(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetWGLContext(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetCocoaMonitor(Monitor window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetCocoaWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetNSGLContext(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetX11Display();
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetX11Adapter(Monitor monitor);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetX11Monitor(Monitor monitor);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetX11Window(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern void glfwSetX11SelectionString(UnmanagedStr @string);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern UnmanagedStr glfwGetX11SelectionString();

    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetGLXContext(Window window);

    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetGLXWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetWaylandDisplay();
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetWaylandMonitor(Monitor monitor);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetWaylandWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetEGLDisplay();
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetEGLContext(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetEGLSurface(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern int glfwGetOSMesaColorBuffer(Window window, int* width, int* height, int* format, void** buffer);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern int glfwGetOSMesaDepthBuffer(Window window, int* width, int* height, int* bytesPerValue, void** buffer);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern nint glfwGetOSMesaContext(Window window);
}

#pragma warning restore CA1401 // P/Invokes should not be visible
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time