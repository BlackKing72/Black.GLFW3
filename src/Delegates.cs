using System.Runtime.InteropServices;

namespace Black.GLFW3;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public delegate void ErrorCallback(ErrorCodes code, [MarshalAs(UnmanagedType.LPUTF8Str)] string description);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowPositionCallback(Window window, int xPos, int yPos);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowSizeCallback(Window window, int width, int height);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowCloseCallback(Window window);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowRefreshCallback(Window window);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowFocusCallback(Window window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowIconifyCallback(Window window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowMaximizeCallback(Window window, bool focused);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowFramebufferSizeCallback(Window window, int width, int height);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void WindowContentsScaleCallback(Window window, int xScale, int yScale);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MonitorCallback(Monitor monitor, ConnectionEvents callbackEvent);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseButtonCallback(Window window, MouseCodes button, InputActions action, ModifierKeys mods);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MousePositionCallback(Window window, double xpos, double ypos);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseEnterCallback(Window window, bool entered);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseScrollCallback(Window window, double xoffset, double yoffset);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void KeyCallback(Window window, KeyCodes key, int scancode, InputActions action, ModifierKeys mods);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void CharCallback(Window window, uint codepoint);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void CharModsCallback(Window window, uint codepoint, int mods);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
public unsafe delegate void FileDropCallback (Window window, int pathCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]string[] paths);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void JoystickCallback(Joysticks joystickID, ConnectionEvents callbackEvent);

public delegate void OpenGLProcedure();

public delegate void VulkanProcedure();