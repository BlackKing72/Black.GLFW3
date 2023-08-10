namespace Black.GLFW3;

using System.Runtime.InteropServices;
using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class NativeGLFW
{
    public static string GetWin32Adapter(Monitor monitor)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return string.Empty;

        using var unmanagedName = glfwGetWin32Adapter(monitor);
        return unmanagedName;
    }

    public static string GetWin32Monitor(Monitor monitor)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return string.Empty;

        using var unmanagedName = glfwGetWin32Monitor(monitor);
        return unmanagedName;
    }

    public static nint GetWin32Window(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return nint.Zero;

        return glfwGetWin32Window(window);
    }

    public static nint GetWGLContext(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return nint.Zero;

        return glfwGetWGLContext(window);
    }

    public static nint GetCocoaMonitor(Monitor window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return nint.Zero;

        return glfwGetCocoaMonitor(window);
    }

    public static nint GetCocoaWindow(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return nint.Zero;

        return glfwGetCocoaWindow(window);
    }

    public static nint GetNSGLContext(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return nint.Zero;

        return glfwGetNSGLContext(window);
    }

    public static nint GetX11Display()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetX11Display();
    }

    public static nint GetX11Adapter(Monitor monitor)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetX11Adapter(monitor);
    }

    public static nint GetX11Monitor(Monitor monitor)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetX11Monitor(monitor);
    }

    public static nint GetX11Window(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetX11Window(window);
    }


    public static void SetX11SelectionString(string selection)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return;

        using var unmanagedSelection = new UnmanagedStr(selection);
        glfwSetX11SelectionString(unmanagedSelection);
    }

    public static string GetX11SelectionString()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return string.Empty;

        using var unmanagedSelection = glfwGetX11SelectionString();
        return unmanagedSelection;
    }

    public static nint GetGLXContext(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetGLXContext(window);
    }

    public static nint GetGLXWindow(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetGLXWindow(window);
    }

    public static nint GetWaylandDisplay()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetWaylandDisplay();
    }

    public static nint GetWaylandMonitor(Monitor monitor)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetWaylandMonitor(monitor);
    }

    public static nint GetWaylandWindow(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetWaylandWindow(window);
    }

    public static nint GetEGLDisplay()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetEGLDisplay();
    }

    public static nint GetEGLContext(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetEGLContext(window);
    }

    public static nint GetEGLSurface(Window window)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return nint.Zero;

        return glfwGetEGLSurface(window);
    }

    public static bool GetOSMesaColorBuffer(Window window, out int width, out int height, out int format, out nint buffer)
    {
        int unmanagedWidth, unmanagedHeight, unmanagedFormat;
        void* unmanagedBuffer = null;

        var unmanagedResult = glfwGetOSMesaColorBuffer(window, &unmanagedWidth, &unmanagedHeight, &unmanagedFormat, &unmanagedBuffer);

        width = unmanagedWidth;
        height = unmanagedHeight;
        format = unmanagedFormat;
        buffer = (nint)unmanagedBuffer;

        return unmanagedResult == True;
    }

    public static bool GetOSMesaDepthBuffer(Window window, out int width, out int height, out int bytesPerValue, out nint buffer)
    {
        int unmanagedWidth, unmanagedHeight, unmanagedBytesPerValue;
        void* unmanagedBuffer = null;

        var unmanagedResult = glfwGetOSMesaDepthBuffer(window, &unmanagedWidth, &unmanagedHeight, &unmanagedBytesPerValue, &unmanagedBuffer);

        width = unmanagedWidth;
        height = unmanagedHeight;
        bytesPerValue = unmanagedBytesPerValue;
        buffer = (nint)unmanagedBuffer;

        return unmanagedResult == True;
    }

    public static nint GetOSMesaContext(Window window)
    {
        return glfwGetOSMesaContext(window);
    }
}