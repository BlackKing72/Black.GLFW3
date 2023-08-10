namespace Black.GLFW3;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    public static void DefaultWindowHints()
    {
        glfwDefaultWindowHints();
    }

    public static void WindowHint(WindowHints hint, Constants value)
    {
        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, bool value)
    {
        WindowHint(hint, value ? True : False);
    }

    public static void WindowHint(WindowHints hint, int value)
    {
        glfwWindowHint((int)hint, value);
    }

    public static void WindowHint(WindowHints hint, ClientAPIs value)
    {
        if (hint is not WindowHints.ClientApi)
            return;

        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, ContextCreationAPIs value)
    {
        if (hint is not WindowHints.ContextCreationAPI)
            return;

        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, OpenGLProfiles value)
    {
        if (hint is not WindowHints.OpenGLProfile)
            return;

        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, ContextRobustness value)
    {
        if (hint is not WindowHints.ContextRobustness)
            return;

        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, ContextReleaseBehaviours value)
    {
        if (hint is not WindowHints.ContextReleaseBehaviour)
            return;

        WindowHint(hint, (int)value);
    }

    public static void WindowHint(WindowHints hint, string value)
    {
        var isInvalidHint = hint is not WindowHints.CocoaFrameName or WindowHints.X11ClassName or WindowHints.X11InstanceName;
        if (value is null || isInvalidHint)
            return;

        using var unmanagedValue = new UnmanagedStr(value);
        glfwWindowHintString((int)hint, unmanagedValue);
    }

    public static Window CreateWindow(int width, int height, string title)
    {
        return CreateWindow(width, height, title, Monitor.Null, Window.Null);
    }

    public static Window CreateWindow(int width, int height, string title, Monitor monitor, Window share)
    {
        using var unmanagedTitle = new UnmanagedStr(title);
        var window = glfwCreateWindow(width, height, unmanagedTitle, monitor, share);

        return window != Window.Null ? window : throw new Exception("Failed to create glfw window.");
    }

    public static void DestroyWindow(this Window window)
    {
        glfwDestroyWindow(window);
    }

    public static bool WindowShouldClose(this Window window)
    {
        return glfwWindowShouldClose(window) == True;
    }

    public static void SetWindowShouldClose(this Window window, bool value)
    {
        glfwSetWindowShouldClose(window, value ? True : False);
    }

    public static void SetWindowTitle(this Window window, string title)
    {
        using var nativeTitle = new UnmanagedStr(title);
        glfwSetWindowTitle(window, nativeTitle);
    }

    public static void SetWindowIcon(this Window window, ReadOnlySpan<Image> images)
    {
        Image* nativeImages = images.AsPointer();
        glfwSetWindowIcon(window, images.Length, nativeImages);
    }

    public static (int x, int y) GetWindowPos(this Window window)
    {
        (int x, int y) position = (0, 0);
        glfwGetWindowPos(window, &position.x, &position.y);
        return position;
    }

    public static void SetWindowPos(this Window window, int xPos, int yPos)
    {
        glfwSetWindowPos(window, xPos, yPos);
    }

    public static (int width, int height) GetWindowSize(this Window window)
    {
        (int width, int height) size = (0, 0);
        glfwGetWindowSize(window, &size.width, &size.height);
        return size;
    }

    public static void SetWindowSizeLimits(this Window window, int minWidth = DontCare, int minHeight = DontCare, int maxWidth = DontCare, int maxHeight = DontCare)
    {
        glfwSetWindowSizeLimits(window, minWidth, minHeight, maxWidth, maxHeight);
    }

    public static void SetWindowAspectRatio(this Window window, int numerator = DontCare, int denominator = DontCare)
    {
        glfwSetWindowAspectRatio(window, numerator, denominator);
    }

    public static void SetWindowSize(this Window window, int width, int height)
    {
        glfwSetWindowSize(window, width, height);
    }

    public static (int width, int height) GetFramebufferSize(this Window window)
    {
        (int width, int height) size = (0, 0);
        glfwGetFramebufferSize(window, &size.width, &size.height);
        return size;
    }

    public static (int left, int top, int right, int bottom) GetWindowFrameSize(this Window window)
    {
        (int left, int top, int right, int bottom) rect = (0, 0, 0, 0);
        glfwGetWindowFrameSize(window, &rect.left, &rect.top, &rect.right, &rect.bottom);
        return rect;
    }

    public static (float x, float y) GetWindowContentScale(this Window window)
    {
        (float x, float y) scale = (0, 0);
        glfwGetWindowContentScale(window, &scale.x, &scale.y);
        return scale;
    }

    public static float GetWindowOpacity(this Window window)
    {
        return glfwGetWindowOpacity(window);
    }

    public static void SetWindowOpacity(this Window window, float opacity)
    {
        glfwSetWindowOpacity(window, opacity);
    }

    public static void IconifyWindow(this Window window)
    {
        glfwIconifyWindow(window);
    }

    public static void RestoreWindow(this Window window)
    {
        glfwRestoreWindow(window);
    }

    public static void MaximizeWindow(this Window window)
    {
        glfwMaximizeWindow(window);
    }

    public static void ShowWindow(this Window window)
    {
        glfwShowWindow(window);
    }

    public static void HideWindow(this Window window)
    {
        glfwHideWindow(window);
    }

    public static void FocusWindow(this Window window)
    {
        glfwFocusWindow(window);
    }

    public static void RequestWindowAttention(this Window window)
    {
        glfwRequestWindowAttention(window);
    }

    public static Monitor GetWindowMonitor(this Window window)
    {
        return glfwGetWindowMonitor(window);
    }

    public static void SetWindowMonitor(this Window window, Monitor monitor, int xPos, int yPos, int width, int height, int refreshRate)
    {
        glfwSetWindowMonitor(window, monitor, xPos, yPos, width, height, refreshRate);
    }

    public static bool GetWindowAttrib(this Window window, WindowAttributes attribute)
    {
        return glfwGetWindowAttrib(window, attribute) == True;
    }

    public static void SetWindowAttrib(this Window window, WindowAttributes attribute, bool value)
    {
        glfwSetWindowAttrib(window, attribute, value ? True : False);
    }

    public static void SetWindowUserPointer<T>(this Window window, T data) where T : unmanaged
    {
        using var unmanagedData = new UnmanagedData<T>(data);
        glfwSetWindowUserPointer(window, unmanagedData);
    }

    public static T GetWindowUserPointer<T>(this Window window) where T : unmanaged
    {
        using var unmanagedData = new UnmanagedData<T>(glfwGetWindowUserPointer(window));
        return unmanagedData.ManagedData;
    }

    public static WindowPositionCallback? SetWindowPosCallback(this Window window, WindowPositionCallback? callback)
    {
        return glfwSetWindowPosCallback(window, callback);
    }

    public static WindowSizeCallback? SetWindowSizeCallback(this Window window, WindowSizeCallback? callback)
    {
        return glfwSetWindowSizeCallback(window, callback);
    }

    public static WindowCloseCallback? SetWindowCloseCallback(this Window window, WindowCloseCallback? callback)
    {
        return glfwSetWindowCloseCallback(window, callback);
    }

    public static WindowRefreshCallback? SetWindowRefreshCallback(this Window window, WindowRefreshCallback? callback)
    {
        return glfwSetWindowRefreshCallback(window, callback);
    }

    public static WindowFocusCallback? SetWindowFocusCallback(this Window window, WindowFocusCallback? callback)
    {
        return glfwSetWindowFocusCallback(window, callback);
    }

    public static WindowIconifyCallback? SetWindowIconifyCallback(this Window window, WindowIconifyCallback? callback)
    {
        return glfwSetWindowIconifyCallback(window, callback);
    }

    public static WindowMaximizeCallback? SetWindowMaximizeCallback(this Window window, WindowMaximizeCallback? callback)
    {
        return glfwSetWindowMaximizeCallback(window, callback);
    }

    public static WindowFramebufferSizeCallback? SetFramebufferSizeCallback(this Window window, WindowFramebufferSizeCallback? callback)
    {
        return glfwSetFramebufferSizeCallback(window, callback);
    }

    public static WindowContentsScaleCallback? SetWindowContentScaleCallback(this Window window, WindowContentsScaleCallback? callback)
    {
        return glfwSetWindowContentScaleCallback(window, callback);
    }

    public static void PollEvents()
    {
        glfwPollEvents();
    }

    public static void WaitEvents()
    {
        glfwWaitEvents();
    }

    public static void WaitEventsTimeout(double timeout)
    {
        glfwWaitEventsTimeout(timeout);
    }

    public static void PostEmptyEvent()
    {
        glfwPostEmptyEvent();
    }

    public static void SwapBuffers(this Window window)
    {
        glfwSwapBuffers(window);
    }
}