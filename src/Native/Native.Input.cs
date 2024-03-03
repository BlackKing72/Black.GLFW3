#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetInputMode(Window window, InputModes mode);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetInputMode(Window window, InputModes mode, int value);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwRawMouseMotionSupported();

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetKeyName(KeyCodes key, int scancode);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetKeyScancode(KeyCodes key);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetKey(Window window, KeyCodes key);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetMouseButton(Window window, MouseCodes button);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetCursorPos(Window window, double* xpos, double* ypos);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetCursorPos(Window window, double xpos, double ypos);

    [DllImport(GLFWLibrary.Name)]
    internal static extern Cursor glfwCreateCursor(Image image, int xhot, int yhot);

    [DllImport(GLFWLibrary.Name)]
    internal static extern Cursor glfwCreateStandardCursor(StandardCursorShapes shape);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwDestroyCursor(Cursor cursor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetCursor(Window window, Cursor cursor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern KeyCallback? glfwSetKeyCallback(Window window, KeyCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern CharCallback? glfwSetCharCallback(Window window, CharCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    [Obsolete("Scheduled for removal in version 4.0.")]
    internal static extern CharModsCallback? glfwSetCharModsCallback(Window window, CharModsCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern MouseButtonCallback? glfwSetMouseButtonCallback(Window window, MouseButtonCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern MousePositionCallback? glfwSetCursorPosCallback(Window window, MousePositionCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern MouseEnterCallback? glfwSetCursorEnterCallback(Window window, MouseEnterCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern MouseScrollCallback? glfwSetScrollCallback(Window window, MouseScrollCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern FileDropCallback? glfwSetDropCallback(Window window, FileDropCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwJoystickPresent(Joysticks jid);

    [DllImport(GLFWLibrary.Name)]
    internal static extern float* glfwGetJoystickAxes(Joysticks jid, int* count);

    [DllImport(GLFWLibrary.Name)]
    internal static extern byte* glfwGetJoystickButtons(Joysticks jid, int* count);

    [DllImport(GLFWLibrary.Name)]
    internal static extern byte* glfwGetJoystickHats(Joysticks jid, int* count);

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetJoystickName(Joysticks jid);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetJoystickGUID(Joysticks jid);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetJoystickUserPointer(Joysticks jid, void* pointer);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void* glfwGetJoystickUserPointer(Joysticks jid);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwJoystickIsGamepad(Joysticks jid);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern JoystickCallback? glfwSetJoystickCallback(JoystickCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwUpdateGamepadMappings(UnmanagedStr @string);

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetGamepadName(Joysticks jid);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetGamepadState(Joysticks jid, GamepadState* state);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetClipboardString(Window window, UnmanagedStr @string);

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetClipboardString(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern double glfwGetTime();
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetTime(double time);

    [DllImport(GLFWLibrary.Name)]
    internal static extern ulong glfwGetTimerValue();
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern ulong glfwGetTimerFrequency();
}

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time