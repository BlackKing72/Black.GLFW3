using Black.Unmanaged;

namespace Black.GLFW3;

using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    public static bool GetInputMode (this Window window, InputModes mode)
    {
        if (mode is InputModes.Cursor)
            return false;

        return glfwGetInputMode(window, mode) == True;
    }

    public static CursorModes GetCursorInputMode(this Window window)
    {
        return (CursorModes)glfwGetInputMode(window, InputModes.Cursor);
    }
   
    public static void SetInputMode(this Window window, InputModes mode, bool value)
    {
        if (mode is InputModes.Cursor)
            return;

        glfwSetInputMode(window, mode, value ? True : False);
    }

    public static void SetCursorInputMode(this Window window, CursorModes value)
    {
        glfwSetInputMode(window, InputModes.Cursor, (int)value);
    }

    public static bool RawMouseMotionSupported()
    {
        return glfwRawMouseMotionSupported() == True;
    }

    public static string GetKeyName(KeyCodes key, int scancode)
    {
        using var unmanagedName = glfwGetKeyName(key, scancode);
        return unmanagedName;
    }

    public static string GetKeyName(this KeyCodes key)
    {
        return GetKeyName(key, 0);
    }

    public static string GetKeyName(int scancode)
    {
        return GetKeyName(KeyCodes.Unknown, scancode);
    }

    public static int GetKeyScancode(this KeyCodes key)
    {
        return glfwGetKeyScancode(key);
    }

    public static InputActions GetKey(this Window window, KeyCodes key)
    {
        return (InputActions)glfwGetKey(window, key);
    }

    public static InputActions GetMouseButton(this Window window, MouseCodes button)
    {
        return (InputActions)glfwGetMouseButton(window, button);
    }

    public static (double xPos, double yPos) GetCursorPos(this Window window)
    {
        double xpos = 0.0, ypos = 0.0;
        glfwGetCursorPos(window, &xpos, &ypos);
        return (xpos, ypos);
    }

    public static void SetCursorPos(this Window window, double xPos, double yPos)
    {
        glfwSetCursorPos(window, xPos, yPos);
    }

    public static Cursor CreateCursor(Image image, int xHot, int yHot)
    {
        return glfwCreateCursor(image, xHot, yHot);
    }

    public static Cursor CreateStandardCursor(StandardCursorShapes shape)
    {
        return glfwCreateStandardCursor(shape);
    }

    public static void DestroyCursor(this Cursor cursor)
    {
        glfwDestroyCursor(cursor);
    }

    public static void SetCursor(this Window window, Cursor cursor)
    {
        glfwSetCursor(window, cursor);
    }

    public static KeyCallback? SetKeyCallback(this Window window, KeyCallback? callback)
    {
        return glfwSetKeyCallback(window, callback);
    }

    public static CharCallback? SetCharCallback(this Window window, CharCallback? callback)
    {
        return glfwSetCharCallback(window, callback);
    }

    [Obsolete("Scheduled for removal in version 4.0.")]
    public static CharModsCallback? SetCharModsCallback(this Window window, CharModsCallback? callback)
    {
        return glfwSetCharModsCallback(window, callback);
    }

    public static MouseButtonCallback? SetMouseButtonCallback(this Window window, MouseButtonCallback? callback)
    {
        return glfwSetMouseButtonCallback(window, callback);
    }

    public static MousePositionCallback? SetCursorPosCallback(this Window window, MousePositionCallback? callback)
    {
        return glfwSetCursorPosCallback(window, callback);
    }

    public static MouseEnterCallback? SetCursorEnterCallback(this Window window, MouseEnterCallback? callback)
    {
        return glfwSetCursorEnterCallback(window, callback);
    }

    public static MouseScrollCallback? SetScrollCallback(this Window window, MouseScrollCallback? callback)
    {
        return glfwSetScrollCallback(window, callback);
    }

    public static FileDropCallback? SetDropCallback(this Window window, FileDropCallback? callback)
    {
        return glfwSetDropCallback(window, callback);
    }

    public static bool JoystickPresent(Joysticks joystickID)
    {
        return glfwJoystickPresent(joystickID) == True;
    }

    public static ReadOnlySpan<float> GetJoystickAxes(Joysticks joystickID)
    {
        int count = 0;
        var unmanagedAxes = glfwGetJoystickAxes(joystickID, &count);

        return new ReadOnlySpan<float>(unmanagedAxes, count);
    }

    public static ReadOnlySpan<InputActions> GetJoystickButtons(Joysticks joystickID)
    {
        int count = 0;
        var unmanagedButtons = glfwGetJoystickButtons(joystickID, &count);

        return new ReadOnlySpan<InputActions>(unmanagedButtons, count);
    }

    public static ReadOnlySpan<JoystickHatStates> GetJoystickHats(Joysticks joystickID)
    {
        int count = 0;
        var unmanagedHats = glfwGetJoystickHats(joystickID, &count);

        return new ReadOnlySpan<JoystickHatStates>(unmanagedHats, count);
    }

    public static string GetJoystickName(Joysticks joystickID)
    {
        using var unmanagedName = glfwGetJoystickName(joystickID);
        return unmanagedName;
    }
    
    public static string GetJoystickGUID(Joysticks joystickID)
    {
        using var unmanagedGUID = glfwGetJoystickGUID(joystickID);
        return unmanagedGUID;
    }
    
    public static void SetJoystickUserPointer<T>(Joysticks joystickID, T userData) where T : unmanaged
    {
        using var unmanagedUserData = new UnmanagedData<T>(userData);
        glfwSetJoystickUserPointer(joystickID, unmanagedUserData);
    }
    
    public static T GetJoystickUserPointer<T>(Joysticks joystickID) where T : unmanaged
    {
        using var unmanagedUserData = new UnmanagedData<T>(glfwGetJoystickUserPointer(joystickID));
        return unmanagedUserData.ManagedData;
    }
    
    public static bool JoystickIsGamepad(Joysticks joystickID)
    {
        return glfwJoystickIsGamepad(joystickID) == True;
    }
    
    public static JoystickCallback? SetJoystickCallback(JoystickCallback? callback)
    {
        return glfwSetJoystickCallback(callback);
    }
    
    public static bool UpdateGamepadMappings(string mappings)
    {
        using var unmanagedMappings = new UnmanagedStr(mappings);
        return glfwUpdateGamepadMappings(unmanagedMappings) == True;
    }

    public static string GetGamepadName(Joysticks joystickID)
    {
        using var unmanagedName = glfwGetGamepadName(joystickID);
        return unmanagedName;
    }
    
    public static bool GetGamepadState(Joysticks joystickID, out GamepadState state)
    {
        using var unmanagedState = new UnmanagedData<GamepadState>(state);
        return glfwGetGamepadState(joystickID, unmanagedState) == True;
    }

    public static void SetClipboardString(this Window window, string clipboard)
    {
        using var unmanagedClipboard = new UnmanagedStr(clipboard);
        glfwSetClipboardString(window, unmanagedClipboard);
    }

    public static string GetClipboardString(this Window window)
    {
        using var unmanagedClipboard = glfwGetClipboardString(window);
        return unmanagedClipboard;
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