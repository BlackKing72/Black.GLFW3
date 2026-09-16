namespace Black.GLFW3;

using static Black.GLFW3.GLFWNative;

public static unsafe partial class NativeGLFW
{
    public static string GetWin32Adapter(MonitorPtr monitor)
    {
        return CString.AsString(glfwGetWin32Adapter(monitor));
    }

    public static string GetWin32Monitor(MonitorPtr monitor)
    {
        return CString.AsString(glfwGetWin32Monitor(monitor));
    }

    public static nint GetWin32Window(WindowPtr window)
    {
        return glfwGetWin32Window(window);
    }

    public static nint GetWGLContext(WindowPtr window)
    {
        return glfwGetWGLContext(window);
    }

    public static nint GetCocoaMonitor(MonitorPtr window)
    {
        return glfwGetCocoaMonitor(window);
    }

    public static nint GetCocoaWindow(WindowPtr window)
    {
        return glfwGetCocoaWindow(window);
    }

    public static nint GetCocoaView(WindowPtr window)
    {
        return glfwGetCocoaView(window);
    }

    public static nint GetNSGLContext(WindowPtr window)
    {
        return glfwGetNSGLContext(window);
    }

    public static nint GetX11Display()
    {
        return glfwGetX11Display();
    }

    public static nint GetX11Adapter(MonitorPtr monitor)
    {
        return glfwGetX11Adapter(monitor);
    }

    public static nint GetX11Monitor(MonitorPtr monitor)
    {
        return glfwGetX11Monitor(monitor);
    }

    public static nint GetX11Window(WindowPtr window)
    {
        return glfwGetX11Window(window);
    }

    public static void SetX11SelectionString(string selection)
    {
        CString.Use(selection, str => glfwSetX11SelectionString(str));
    }

    public static string GetX11SelectionString()
    {
        return CString.AsString(glfwGetX11SelectionString());
    }

    public static nint GetGLXContext(WindowPtr window)
    {
        return glfwGetGLXContext(window);
    }

    public static nint GetGLXWindow(WindowPtr window)
    {
        return glfwGetGLXWindow(window);
    }

    public static bool GetGLXFbConfig(WindowPtr window, nint config)
    {
        return glfwGetGLXFBConfig(window, config) == NativeTrue;
    }

    public static nint GetWaylandDisplay()
    {
        return glfwGetWaylandDisplay();
    }

    public static nint GetWaylandMonitor(MonitorPtr monitor)
    {
        return glfwGetWaylandMonitor(monitor);
    }

    public static nint GetWaylandWindow(WindowPtr window)
    {
        return glfwGetWaylandWindow(window);
    }

    public static nint GetEGLDisplay()
    {
        return glfwGetEGLDisplay();
    }

    public static nint GetEGLContext(WindowPtr window)
    {
        return glfwGetEGLContext(window);
    }

    public static nint GetEGLSurface(WindowPtr window)
    {
        return glfwGetEGLSurface(window);
    }

    public static bool GetEGLConfig(WindowPtr window, nint config)
    {
        return glfwGetEGLConfig(window, config) == NativeTrue;
    }

    public static bool GetOSMesaColorBuffer(
        WindowPtr window,
        out int width,
        out int height,
        out int format,
        out nint buffer
    )
    {
        (int width, int height, int format) data = (0, 0, 0);
        void* dataBuffer = null;
        var result = glfwGetOSMesaColorBuffer(window, &data.width, &data.height, &data.format, &dataBuffer);

        width = data.width;
        height = data.height;
        format = data.format;
        buffer = (nint)dataBuffer;

        return result == NativeTrue;
    }

    public static bool GetOSMesaDepthBuffer(
        WindowPtr window,
        out int width,
        out int height,
        out int bytesPerValue,
        out nint buffer
    )
    {
        (int width, int height, int bytesPerValue) data = (0, 0, 0);
        void* dataBuffer = null;

        var unmanagedResult = glfwGetOSMesaDepthBuffer(
            window,
            &data.width,
            &data.height,
            &data.bytesPerValue,
            &dataBuffer
        );

        width = data.width;
        height = data.height;
        bytesPerValue = data.bytesPerValue;
        buffer = (nint)dataBuffer;

        return unmanagedResult == NativeTrue;
    }

    public static nint GetOSMesaContext(WindowPtr window)
    {
        return glfwGetOSMesaContext(window);
    }
}
