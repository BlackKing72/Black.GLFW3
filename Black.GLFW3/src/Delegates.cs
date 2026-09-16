using System.Runtime.InteropServices;

namespace Black.GLFW3;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public delegate void ErrorCallback(ErrorCode code, [MarshalAs(UnmanagedType.LPUTF8Str)] string description);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowPositionCallback(WindowPtr window, int xpos, int ypos);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowSizeCallback(WindowPtr window, int width, int height);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowCloseCallback(WindowPtr window);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowRefreshCallback(WindowPtr window);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowFocusCallback(WindowPtr window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowIconifyCallback(WindowPtr window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowMaximizeCallback(WindowPtr window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowFramebufferSizeCallback(WindowPtr window, int width, int height);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowContentsScaleCallback(WindowPtr window, int xScale, int yScale);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MonitorCallback(MonitorPtr monitor, ConnectionEvent callbackEvent);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseButtonCallback(
    WindowPtr window,
    MouseButton button,
    InputAction action,
    Modifiers mods
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MousePositionCallback(WindowPtr window, double xpos, double ypos);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseEnterCallback(WindowPtr window, bool entered);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseScrollCallback(WindowPtr window, double xoffset, double yoffset);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void KeyCallback(
    WindowPtr window,
    Keys key,
    int scancode,
    InputAction action,
    Modifiers mods
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void CharCallback(WindowPtr window, uint codepoint);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void CharModsCallback(WindowPtr window, uint codepoint, Modifiers mods);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
public delegate void FileDropCallback(
    WindowPtr window,
    int pathCount,
    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] paths
);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void JoystickCallback(Joystick joystickID, ConnectionEvent callbackEvent);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate nint VKGetInstanceProcAddr(nint instance, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

public delegate nint AllocateFunction<T>(nint size, ref T user)
    where T : unmanaged;

public delegate nint ReallocateFunction<T>(nint block, nint size, ref T user)
    where T : unmanaged;

public delegate void DeallocateFunction<T>(nint block, ref T user)
    where T : unmanaged;
