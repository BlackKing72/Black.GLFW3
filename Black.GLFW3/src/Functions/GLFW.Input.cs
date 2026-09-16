namespace Black.GLFW3;

using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using static Black.GLFW3.GLFWNative;

public static unsafe partial class GLFW
{
    public static bool GetInputMode(this WindowPtr window, InputMode mode)
    {
        return glfwGetInputMode(window, (int)mode) == NativeTrue;
    }

    public static CursorMode GetInputMode(this WindowPtr window, InputCursorMode mode)
    {
        return (CursorMode)glfwGetInputMode(window, (int)mode);
    }

    public static void SetInputMode(this WindowPtr window, InputMode mode, bool value)
    {
        glfwSetInputMode(window, (int)mode, value ? NativeTrue : NativeFalse);
    }

    public static void SetInputMode(this WindowPtr window, InputCursorMode mode, CursorMode value)
    {
        glfwSetInputMode(window, (int)mode, (int)value);
    }

    public static bool RawMouseMotionSupported()
    {
        return glfwRawMouseMotionSupported() == NativeTrue;
    }

    public static string GetKeyName(Keys key, int scancode)
    {
        return CString.AsString(glfwGetKeyName(key, scancode));
    }

    public static string GetKeyName(this Keys key) => GetKeyName(key, 0);

    public static string GetKeyName(int scancode) => GetKeyName(Keys.Unknown, scancode);

    public static int GetKeyScancode(this Keys key)
    {
        return glfwGetKeyScancode(key);
    }

    public static InputAction GetKey(this WindowPtr window, Keys key)
    {
        return (InputAction)glfwGetKey(window, key);
    }

    public static InputAction GetMouseButton(this WindowPtr window, MouseButton button)
    {
        return (InputAction)glfwGetMouseButton(window, button);
    }

    public static Vector2 GetCursorPos(this WindowPtr window)
    {
        (double x, double y) pos = (0.0, 0.0);
        glfwGetCursorPos(window, &pos.x, &pos.y);
        return new((float)pos.x, (float)pos.y);
    }

    public static (double xPos, double yPos) GetCursorPosAsDouble(this WindowPtr window)
    {
        (double x, double y) pos = (0.0, 0.0);
        glfwGetCursorPos(window, &pos.x, &pos.y);
        return pos;
    }

    public static void SetCursorPos(this WindowPtr window, Vector2 position)
    {
        glfwSetCursorPos(window, position.X, position.Y);
    }

    public static void SetCursorPos(this WindowPtr window, float positionX, float positionY)
    {
        glfwSetCursorPos(window, positionX, positionY);
    }

    public static void SetCursorPos(this WindowPtr window, double positionX, double positionY)
    {
        glfwSetCursorPos(window, positionX, positionY);
    }

    public static CursorPtr CreateCursor(Image image, Point hotspot)
    {
        return glfwCreateCursor(image, hotspot.X, hotspot.Y);
    }

    public static CursorPtr CreateCursor(Image image, int hotspotX, int hotspotY)
    {
        return glfwCreateCursor(image, hotspotX, hotspotY);
    }

    public static CursorPtr CreateStandardCursor(CursorShape shape)
    {
        return glfwCreateStandardCursor(shape);
    }

    public static void DestroyCursor(this CursorPtr cursor)
    {
        glfwDestroyCursor(cursor);
    }

    public static void SetCursor(this WindowPtr window, CursorPtr cursor)
    {
        glfwSetCursor(window, cursor);
    }

    public static KeyCallback? SetKeyCallback(this WindowPtr window, KeyCallback? callback)
    {
        return glfwSetKeyCallback(window, callback);
    }

    public static CharCallback? SetCharCallback(this WindowPtr window, CharCallback? callback)
    {
        return glfwSetCharCallback(window, callback);
    }

    [Obsolete("Scheduled for removal in version 4.0.")]
    public static CharModsCallback? SetCharModsCallback(this WindowPtr window, CharModsCallback? callback)
    {
        return glfwSetCharModsCallback(window, callback);
    }

    public static MouseButtonCallback? SetMouseButtonCallback(
        this WindowPtr window,
        MouseButtonCallback? callback
    )
    {
        return glfwSetMouseButtonCallback(window, callback);
    }

    public static MousePositionCallback? SetCursorPosCallback(
        this WindowPtr window,
        MousePositionCallback? callback
    )
    {
        return glfwSetCursorPosCallback(window, callback);
    }

    public static MouseEnterCallback? SetCursorEnterCallback(
        this WindowPtr window,
        MouseEnterCallback? callback
    )
    {
        return glfwSetCursorEnterCallback(window, callback);
    }

    public static MouseScrollCallback? SetScrollCallback(this WindowPtr window, MouseScrollCallback? callback)
    {
        return glfwSetScrollCallback(window, callback);
    }

    public static FileDropCallback? SetDropCallback(this WindowPtr window, FileDropCallback? callback)
    {
        return glfwSetDropCallback(window, callback);
    }

    public static bool JoystickPresent(Joystick joystickID)
    {
        return glfwJoystickPresent(joystickID) == NativeTrue;
    }

    public static ReadOnlySpan<float> GetJoystickAxes(Joystick joystickID)
    {
        int count = 0;
        var unmanagedAxes = glfwGetJoystickAxes(joystickID, &count);
        return new ReadOnlySpan<float>(unmanagedAxes, count);
    }

    /// <summary> This copies the data to a new array. Prefer using <see cref="GetJoystickAxes"/> instead </summary>
    public static float[] GetJoystickAxesArray(Joystick joystickID) => [.. GetJoystickAxes(joystickID)];

    public static ReadOnlySpan<InputAction> GetJoystickButtons(Joystick joystickID)
    {
        int count = 0;
        var unmanagedButtons = glfwGetJoystickButtons(joystickID, &count);
        return new ReadOnlySpan<InputAction>(unmanagedButtons, count);
    }

    /// <summary> This copies the data to a new array. Prefer using <see cref="GetJoystickButtons"/> instead </summary>
    public static InputAction[] GetJoystickButtonsArray(Joystick joystickID) =>
        [.. GetJoystickButtons(joystickID)];

    public static ReadOnlySpan<GamepadHat> GetJoystickHats(Joystick joystickID)
    {
        int count = 0;
        var unmanagedHats = glfwGetJoystickHats(joystickID, &count);
        return new ReadOnlySpan<GamepadHat>(unmanagedHats, count);
    }

    /// <summary> This copies the data to a new array. Prefer using <see cref="GetJoystickHats"/> instead </summary>
    public static GamepadHat[] GetJoystickHatsArray(Joystick joystickID) => [.. GetJoystickHats(joystickID)];

    public static string GetJoystickName(Joystick joystickID)
    {
        return CString.AsString(glfwGetJoystickName(joystickID));
    }

    public static string GetJoystickGUID(Joystick joystickID)
    {
        return CString.AsString(glfwGetJoystickGUID(joystickID));
    }

    public static void SetJoystickUserPointer<T>(Joystick joystickID, ref T userData)
        where T : unmanaged
    {
        var ptr = Unsafe.AsPointer(ref userData);
        glfwSetJoystickUserPointer(joystickID, ptr);
    }

    public static T GetJoystickUserPointer<T>(Joystick joystickID)
        where T : unmanaged
    {
        var ptr = (T*)glfwGetJoystickUserPointer(joystickID);
        return ptr is null ? default : *ptr;
    }

    public static bool JoystickIsGamepad(Joystick joystickID)
    {
        return glfwJoystickIsGamepad(joystickID) == NativeTrue;
    }

    public static JoystickCallback? SetJoystickCallback(JoystickCallback? callback)
    {
        return glfwSetJoystickCallback(callback);
    }

    public static bool UpdateGamepadMappings(ReadOnlySpan<byte> mappings)
    {
        return CString.Use(mappings, str => glfwUpdateGamepadMappings(str) == NativeTrue);
    }

    public static bool UpdateGamepadMappings(ReadOnlySpan<char> mappings)
    {
        return CString.Use(mappings, str => glfwUpdateGamepadMappings(str) == NativeTrue);
    }

    public static bool UpdateGamepadMappings(string mappings)
    {
        return CString.Use(mappings, str => glfwUpdateGamepadMappings(str) == NativeTrue);
    }

    public static string GetGamepadName(Joystick joystickID)
    {
        return CString.AsString(glfwGetGamepadName(joystickID));
    }

    public static bool GetGamepadState(Joystick joystickID, out GamepadState state)
    {
        GamepadState data = new GamepadState();
        var result = glfwGetGamepadState(joystickID, &data);
        state = data;
        return result == NativeTrue;
    }

    public static void SetClipboardString(this WindowPtr window, ReadOnlySpan<byte> clipboard)
    {
        CString.Use(clipboard, str => glfwSetClipboardString(window, str));
    }

    public static void SetClipboardString(this WindowPtr window, ReadOnlySpan<char> clipboard)
    {
        CString.Use(clipboard, str => glfwSetClipboardString(window, str));
    }

    public static void SetClipboardString(this WindowPtr window, string clipboard)
    {
        CString.Use(clipboard, str => glfwSetClipboardString(window, str));
    }

    public static string GetClipboardString(this WindowPtr window)
    {
        return CString.AsString(glfwGetClipboardString(window));
    }

    public static double GetTime()
    {
        return glfwGetTime();
    }

    public static void SetTime(double time)
    {
        glfwSetTime(time);
    }

    public static ulong GetTimerValue()
    {
        return glfwGetTimerValue();
    }

    public static ulong GetTimerFrequency()
    {
        return glfwGetTimerFrequency();
    }
}
