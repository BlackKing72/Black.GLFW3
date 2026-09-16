#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public static unsafe partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetInputMode(WindowPtr window, int mode);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetInputMode(WindowPtr window, int mode, int value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwRawMouseMotionSupported();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetKeyName(Keys key, int scancode);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetKeyScancode(Keys key);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetKey(WindowPtr window, Keys key);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetMouseButton(WindowPtr window, MouseButton button);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetCursorPos(WindowPtr window, double* xpos, double* ypos);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetCursorPos(WindowPtr window, double xpos, double ypos);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial CursorPtr glfwCreateCursor(Image image, int xhot, int yhot);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial CursorPtr glfwCreateStandardCursor(CursorShape shape);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwDestroyCursor(CursorPtr cursor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetCursor(WindowPtr window, CursorPtr cursor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial KeyCallback? glfwSetKeyCallback(WindowPtr window, KeyCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial CharCallback? glfwSetCharCallback(WindowPtr window, CharCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    [Obsolete("Scheduled for removal in version 4.0.")]
    public static partial CharModsCallback? glfwSetCharModsCallback(WindowPtr window, CharModsCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MouseButtonCallback? glfwSetMouseButtonCallback(WindowPtr window, MouseButtonCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MousePositionCallback? glfwSetCursorPosCallback(WindowPtr window, MousePositionCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MouseEnterCallback? glfwSetCursorEnterCallback(WindowPtr window, MouseEnterCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MouseScrollCallback? glfwSetScrollCallback(WindowPtr window, MouseScrollCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial FileDropCallback? glfwSetDropCallback(WindowPtr window, FileDropCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwJoystickPresent(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial float* glfwGetJoystickAxes(Joystick jid, int* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetJoystickButtons(Joystick jid, int* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetJoystickHats(Joystick jid, int* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetJoystickName(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetJoystickGUID(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetJoystickUserPointer(Joystick jid, void* pointer);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void* glfwGetJoystickUserPointer(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwJoystickIsGamepad(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial JoystickCallback? glfwSetJoystickCallback(JoystickCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwUpdateGamepadMappings(byte* @string);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetGamepadName(Joystick jid);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetGamepadState(Joystick jid, GamepadState* state);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetClipboardString(WindowPtr window, byte* @string);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetClipboardString(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial double glfwGetTime();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetTime(double time);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial ulong glfwGetTimerValue();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial ulong glfwGetTimerFrequency();
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
