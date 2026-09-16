using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using static Black.GLFW3.GLFWNative;

namespace Black.GLFW3;

public static unsafe partial class GLFW
{
    private static readonly HashSet<Hint> booleanHints = [];

    public static void DefaultWindowHints()
    {
        glfwDefaultWindowHints();
    }

    public static void WindowHint(Hint hint, int value)
    {
        glfwWindowHint((int)hint, value);
    }

    public static void WindowHint(Hint hint, Constants value)
    {
        WindowHint(hint, (int)value);
    }

    public static void WindowHint(Hint hint, bool value)
    {
        Debug.Assert(
            hint
                is Hint.Resizable
                    or Hint.Visible
                    or Hint.Decorated
                    or Hint.Focused
                    or Hint.AutoIconify
                    or Hint.Floating
                    or Hint.Maximized
                    or Hint.CenterCursor
                    or Hint.TransparentFramebuffer
                    or Hint.FocusOnShow
                    or Hint.ScaleToMonitor
                    or Hint.ScaleFramebuffer
                    or Hint.MousePassthrough
                    or Hint.Stereo
                    or Hint.SRGBCapable
                    or Hint.DoubleBuffer
                    or Hint.OpenGLForwardCompat
                    or Hint.ContextDebug
                    or Hint.Win32KeyboardMenu
                    or Hint.Win32ShowDefault
                    or Hint.CocoaGraphicsSwitching
        );

        WindowHint(hint, value ? NativeTrue : NativeFalse);
    }

    public static void WindowHint(Hint hint, ClientAPI value)
    {
        Debug.Assert(hint is Hint.ClientAPI);
        WindowHint(value);
    }

    public static void WindowHint(Hint hint, ContextCreationAPI value)
    {
        Debug.Assert(hint is Hint.ContextCreationAPI);
        WindowHint(value);
    }

    public static void WindowHint(Hint hint, OpenGLProfile value)
    {
        Debug.Assert(hint is Hint.OpenGLProfile);
        WindowHint(value);
    }

    public static void WindowHint(Hint hint, ContextRobustness value)
    {
        Debug.Assert(hint is Hint.ContextRobustness);
        WindowHint(value);
    }

    public static void WindowHint(Hint hint, ContextReleaseBehaviour value)
    {
        Debug.Assert(hint is Hint.ContextReleaseBehaviour);
        WindowHint(value);
    }

    public static void WindowHint(ClientAPI value)
    {
        WindowHint(Hint.ClientAPI, (int)value);
    }

    public static void WindowHint(ContextCreationAPI value)
    {
        WindowHint(Hint.ContextCreationAPI, (int)value);
    }

    public static void WindowHint(OpenGLProfile value)
    {
        WindowHint(Hint.OpenGLProfile, (int)value);
    }

    public static void WindowHint(ContextRobustness value)
    {
        WindowHint(Hint.ContextRobustness, (int)value);
    }

    public static void WindowHint(ContextReleaseBehaviour value)
    {
        WindowHint(Hint.ContextReleaseBehaviour, (int)value);
    }

    public static void WindowHint(Hint hint, string value)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(value));
        Debug.Assert(
            hint is Hint.CocoaFrameName or Hint.WaylandAppID or Hint.X11InstanceName or Hint.X11ClassName
        );

        CString.Use(value, str => glfwWindowHintString((int)hint, str));
    }

    public static WindowPtr CreateWindow(
        int width,
        int height,
        ReadOnlySpan<byte> title,
        MonitorPtr monitor = default,
        WindowPtr share = default
    ) => CString.Use(title, str => glfwCreateWindow(width, height, str, monitor, share));

    public static WindowPtr CreateWindow(
        int width,
        int height,
        ReadOnlySpan<char> title,
        MonitorPtr monitor = default,
        WindowPtr share = default
    ) => CString.Use(title, str => glfwCreateWindow(width, height, str, monitor, share));

    public static WindowPtr CreateWindow(
        int width,
        int height,
        string title,
        MonitorPtr monitor = default,
        WindowPtr share = default
    ) => CString.Use(title, str => glfwCreateWindow(width, height, str, monitor, share));

    public static void DestroyWindow(this WindowPtr window)
    {
        glfwDestroyWindow(window);
    }

    public static bool WindowShouldClose(this WindowPtr window)
    {
        return glfwWindowShouldClose(window) == NativeTrue;
    }

    public static void SetWindowShouldClose(this WindowPtr window, bool value)
    {
        glfwSetWindowShouldClose(window, value ? NativeTrue : NativeFalse);
    }

    public static string GetWindowTitle(WindowPtr window)
    {
        return CString.AsString(glfwGetWindowTitle(window));
    }

    public static void SetWindowTitle(this WindowPtr window, ReadOnlySpan<byte> title)
    {
        CString.Use(title, str => glfwSetWindowTitle(window, str));
    }

    public static void SetWindowTitle(this WindowPtr window, ReadOnlySpan<char> title)
    {
        CString.Use(title, str => glfwSetWindowTitle(window, str));
    }

    public static void SetWindowTitle(this WindowPtr window, string title)
    {
        CString.Use(title, str => glfwSetWindowTitle(window, str));
    }

    public static void SetWindowIcon(this WindowPtr window, ReadOnlySpan<Image> images)
    {
        fixed (Image* ptr = images)
            glfwSetWindowIcon(window, images.Length, ptr);
    }

    public static Point GetWindowPos(this WindowPtr window)
    {
        (int x, int y) pos = (0, 0);
        glfwGetWindowPos(window, &pos.x, &pos.y);
        return new(pos.x, pos.y);
    }

    public static void SetWindowPos(this WindowPtr window, Point position)
    {
        glfwSetWindowPos(window, position.X, position.Y);
    }

    public static void SetWindowPos(this WindowPtr window, int positionX, int positionY)
    {
        glfwSetWindowPos(window, positionX, positionY);
    }

    public static Size GetWindowSize(this WindowPtr window)
    {
        (int width, int height) size = (0, 0);
        glfwGetWindowSize(window, &size.width, &size.height);
        return new(size.width, size.height);
    }

    // NOTE: This makes setting only width or only height limits more verbose
    public static void SetWindowSizeLimits(this WindowPtr window, Size? minSize = null, Size? maxSize = null)
    {
        Size min = minSize ?? new Size(NativeDontCare, NativeDontCare);
        Size max = maxSize ?? new Size(NativeDontCare, NativeDontCare);

        glfwSetWindowSizeLimits(window, min.Width, min.Height, max.Width, max.Height);
    }

    public static void SetWindowSizeLimits(
        this WindowPtr window,
        int minWidth = NativeDontCare,
        int minHeight = NativeDontCare,
        int maxWidth = NativeDontCare,
        int maxHeight = NativeDontCare
    )
    {
        glfwSetWindowSizeLimits(window, minWidth, minHeight, maxWidth, maxHeight);
    }

    public static void SetWindowAspectRatio(
        this WindowPtr window,
        int numerator = NativeDontCare,
        int denominator = NativeDontCare
    )
    {
        glfwSetWindowAspectRatio(window, numerator, denominator);
    }

    public static void SetWindowSize(this WindowPtr window, Size size)
    {
        glfwSetWindowSize(window, size.Width, size.Height);
    }

    public static void SetWindowSize(this WindowPtr window, int width, int height)
    {
        glfwSetWindowSize(window, width, height);
    }

    public static Size GetFramebufferSize(this WindowPtr window)
    {
        (int width, int height) size = (0, 0);
        glfwGetFramebufferSize(window, &size.width, &size.height);
        return new(size.width, size.height);
    }

    // NOTE: No good alternative to this, maybe a custom type?
    public static (int left, int top, int right, int bottom) GetWindowFrameSize(this WindowPtr window)
    {
        (int left, int top, int right, int bottom) rect = (0, 0, 0, 0);
        glfwGetWindowFrameSize(window, &rect.left, &rect.top, &rect.right, &rect.bottom);
        return rect;
    }

    public static Vector2 GetWindowContentScale(this WindowPtr window)
    {
        Vector2 scale = Vector2.Zero;
        glfwGetWindowContentScale(window, &scale.X, &scale.Y);
        return scale;
    }

    public static float GetWindowOpacity(this WindowPtr window)
    {
        return glfwGetWindowOpacity(window);
    }

    public static void SetWindowOpacity(this WindowPtr window, float opacity)
    {
        glfwSetWindowOpacity(window, opacity);
    }

    public static void IconifyWindow(this WindowPtr window)
    {
        glfwIconifyWindow(window);
    }

    public static void RestoreWindow(this WindowPtr window)
    {
        glfwRestoreWindow(window);
    }

    public static void MaximizeWindow(this WindowPtr window)
    {
        glfwMaximizeWindow(window);
    }

    public static void ShowWindow(this WindowPtr window)
    {
        glfwShowWindow(window);
    }

    public static void HideWindow(this WindowPtr window)
    {
        glfwHideWindow(window);
    }

    public static void FocusWindow(this WindowPtr window)
    {
        glfwFocusWindow(window);
    }

    public static void RequestWindowAttention(this WindowPtr window)
    {
        glfwRequestWindowAttention(window);
    }

    public static MonitorPtr GetWindowMonitor(this WindowPtr window)
    {
        return glfwGetWindowMonitor(window);
    }

    public static void SetWindowMonitor(
        this WindowPtr window,
        MonitorPtr monitor,
        Rectangle rect,
        int refreshRate
    )
    {
        glfwSetWindowMonitor(window, monitor, rect.X, rect.Y, rect.Width, rect.Height, refreshRate);
    }

    public static void SetWindowMonitor(
        this WindowPtr window,
        MonitorPtr monitor,
        int x,
        int y,
        int width,
        int height,
        int refreshRate
    )
    {
        glfwSetWindowMonitor(window, monitor, x, y, width, height, refreshRate);
    }

    public static void GetWindowAttrib(this WindowPtr window, Attributes attribute, out bool value)
    {
        Debug.Assert(
            attribute
                is not Attributes.ClientAPI
                    and not Attributes.ContextCreationAPI
                    and not Attributes.ContextVersionMajor
                    and not Attributes.ContextVersionMinor
                    and not Attributes.ContextRevision
                    and not Attributes.OpenGLProfile
                    and not Attributes.ContextReleaseBehaviour
                    and not Attributes.ContextRobustness
        );

        value = glfwGetWindowAttrib(window, attribute) == NativeTrue;
    }

    public static void GetWindowAttrib(this WindowPtr window, Attributes attribute, out int value)
    {
        Debug.Assert(
            attribute
                is Attributes.ContextVersionMajor
                    or Attributes.ContextVersionMinor
                    or Attributes.ContextRevision
        );
        value = glfwGetWindowAttrib(window, attribute);
    }

    public static void GetWindowAttrib(this WindowPtr window, out ClientAPI value)
    {
        value = (ClientAPI)glfwGetWindowAttrib(window, Attributes.ClientAPI);
    }

    public static void GetWindowAttrib(this WindowPtr window, out ContextCreationAPI value)
    {
        value = (ContextCreationAPI)glfwGetWindowAttrib(window, Attributes.ContextCreationAPI);
    }

    public static void GetWindowAttrib(this WindowPtr window, out OpenGLProfile value)
    {
        value = (OpenGLProfile)glfwGetWindowAttrib(window, Attributes.OpenGLProfile);
    }

    public static void GetWindowAttrib(this WindowPtr window, out ContextReleaseBehaviour value)
    {
        value = (ContextReleaseBehaviour)glfwGetWindowAttrib(window, Attributes.ContextReleaseBehaviour);
    }

    public static void GetWindowAttrib(this WindowPtr window, out ContextRobustness value)
    {
        value = (ContextRobustness)glfwGetWindowAttrib(window, Attributes.ContextRobustness);
    }

    public static bool IsWindowFocused(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Focused) == NativeTrue;

    public static bool IsWindowIconified(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Iconified) == NativeTrue;

    public static bool IsWindowMaximized(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Maximized) == NativeTrue;

    public static bool IsWindowHovered(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Hovered) == NativeTrue;

    public static bool IsWindowVisible(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Visible) == NativeTrue;

    public static bool IsWindowResizable(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Resizable) == NativeTrue;

    public static bool IsWindowDecorated(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Decorated) == NativeTrue;

    public static bool IsWindowAutoIconify(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.AutoIconify) == NativeTrue;

    public static bool IsWindowFloating(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.Floating) == NativeTrue;

    public static bool IsWindowTransparentFramebuffer(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.TransparentFramebuffer) == NativeTrue;

    public static bool IsWindowFocusOnShow(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.FocusOnShow) == NativeTrue;

    public static bool IsWindowMousePassthrough(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.MousePassthrough) == NativeTrue;

    public static ClientAPI GetWindowClientAPI(this WindowPtr window) =>
        (ClientAPI)glfwGetWindowAttrib(window, Attributes.ClientAPI);

    public static ContextCreationAPI GetWindowContextCreationAPI(this WindowPtr window) =>
        (ContextCreationAPI)glfwGetWindowAttrib(window, Attributes.ContextCreationAPI);

    public static int GetWindowContextVersionMajor(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.ContextVersionMajor);

    public static int GetWindowContextVersionMinor(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.ContextVersionMinor);

    public static int GetWindowContextRevision(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.ContextRevision);

    public static bool IsWindowOpenGLForwardCompat(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.OpenGLForwardCompat) == NativeTrue;

    public static bool IsWindowContextDebug(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.ContextDebug) == NativeTrue;

    public static OpenGLProfile GetWindowOpenGLProfile(this WindowPtr window) =>
        (OpenGLProfile)glfwGetWindowAttrib(window, Attributes.OpenGLProfile);

    public static ContextReleaseBehaviour GetWindowContextReleaseBehaviour(this WindowPtr window) =>
        (ContextReleaseBehaviour)glfwGetWindowAttrib(window, Attributes.ContextReleaseBehaviour);

    public static bool GetWindowContextNoError(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.ContextNoError) == NativeTrue;

    public static ContextRobustness GetWindowContextRobustness(this WindowPtr window) =>
        (ContextRobustness)glfwGetWindowAttrib(window, Attributes.ContextRobustness);

    public static bool IsWindowDoubleBuffer(this WindowPtr window) =>
        glfwGetWindowAttrib(window, Attributes.DoubleBuffer) == NativeTrue;

    public static void SetWindowAttrib(this WindowPtr window, MutableAttributes attribute, bool value)
    {
        glfwSetWindowAttrib(window, attribute, value ? NativeTrue : NativeFalse);
    }

    public static void SetWindowUserPointer<T>(this WindowPtr window, ref T data)
        where T : unmanaged
    {
        var ptr = Unsafe.AsPointer(ref data);
        glfwSetWindowUserPointer(window, ptr);
    }

    public static T GetWindowUserPointer<T>(this WindowPtr window)
        where T : unmanaged
    {
        var ptr = (T*)glfwGetWindowUserPointer(window);
        return ptr is null ? default : *ptr;
    }

    public static WindowPositionCallback? SetWindowPosCallback(
        this WindowPtr window,
        WindowPositionCallback? callback
    )
    {
        return glfwSetWindowPosCallback(window, callback);
    }

    public static WindowSizeCallback? SetWindowSizeCallback(
        this WindowPtr window,
        WindowSizeCallback? callback
    )
    {
        return glfwSetWindowSizeCallback(window, callback);
    }

    public static WindowCloseCallback? SetWindowCloseCallback(
        this WindowPtr window,
        WindowCloseCallback? callback
    )
    {
        return glfwSetWindowCloseCallback(window, callback);
    }

    public static WindowRefreshCallback? SetWindowRefreshCallback(
        this WindowPtr window,
        WindowRefreshCallback? callback
    )
    {
        return glfwSetWindowRefreshCallback(window, callback);
    }

    public static WindowFocusCallback? SetWindowFocusCallback(
        this WindowPtr window,
        WindowFocusCallback? callback
    )
    {
        return glfwSetWindowFocusCallback(window, callback);
    }

    public static WindowIconifyCallback? SetWindowIconifyCallback(
        this WindowPtr window,
        WindowIconifyCallback? callback
    )
    {
        return glfwSetWindowIconifyCallback(window, callback);
    }

    public static WindowMaximizeCallback? SetWindowMaximizeCallback(
        this WindowPtr window,
        WindowMaximizeCallback? callback
    )
    {
        return glfwSetWindowMaximizeCallback(window, callback);
    }

    public static WindowFramebufferSizeCallback? SetFramebufferSizeCallback(
        this WindowPtr window,
        WindowFramebufferSizeCallback? callback
    )
    {
        return glfwSetFramebufferSizeCallback(window, callback);
    }

    public static WindowContentsScaleCallback? SetWindowContentScaleCallback(
        this WindowPtr window,
        WindowContentsScaleCallback? callback
    )
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

    public static void SwapBuffers(this WindowPtr window)
    {
        glfwSwapBuffers(window);
    }
}
