namespace Black.GLFW3;

using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    private static Version cachedVersion = default;
    private static string cachedVersionString = "";

    static GLFW()
    {
        GLFWLibrary.Initialize();
    }

    public static void Initialize()
    {
        if (glfwInit() != True)
            throw new Exception("Failed to initialize GLFW.");
    }

    public static void Terminate()
    {
        glfwTerminate();
    }

    public static void InitializeHint(InitHints hint, bool value)
    {
        glfwInitHint(hint, value ? True : False);
    }

    public static Version Version
    {
        get
        {
            if (cachedVersion == default)
                fixed (Version* version = &cachedVersion)
                    glfwGetVersion(&version->Major, &version->Minor, &version->Revision);

            return cachedVersion;
        }
    }

    public static string VersionString
    {
        get
        {
            if (string.IsNullOrEmpty(cachedVersionString))
            {
                var versionString = glfwGetVersionString();
                cachedVersionString = versionString;
            }

            return cachedVersionString;
        }
    }

    public static Error Error
    {
        get
        {
            UnmanagedStr description;
            ErrorCodes error = glfwGetError(&description);
            return new Error(error, description);
        }
    }

    public static ErrorCallback? SetErrorCallback(ErrorCallback? callback)
    {
        return glfwSetErrorCallback(callback);
    }
}