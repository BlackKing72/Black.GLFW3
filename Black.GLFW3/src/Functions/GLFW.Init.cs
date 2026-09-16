namespace Black.GLFW3;

using static Black.GLFW3.GLFWNative;

public static unsafe partial class GLFW
{
    private static Version cachedVersion = default;
    private static string cachedVersionString = "";

    static GLFW()
    {
        GLFWLibrary.Initialize();
    }

    public static bool Init()
    {
        return glfwInit() == NativeTrue;
    }

    public static void Terminate()
    {
        glfwTerminate();
    }

    public static void InitHint(InitHint hint, bool value)
    {
        glfwInitHint(hint, value ? NativeTrue : NativeFalse);
    }

    public static void InitAllocator<T>(AllocatorPtr<T> allocator)
        where T : unmanaged
    {
        glfwInitAllocator(&allocator);
    }

    public static void InitializeVulkanLoader(VKGetInstanceProcAddr loader)
    {
        glfwInitVulkanLoader(loader);
    }

    public static Version GetVersion()
    {
        if (cachedVersion == default)
        {
            int major,
                minor,
                revision;
            glfwGetVersion(&major, &minor, &revision);
            cachedVersion = new(major, minor, revision);
        }

        return cachedVersion;
    }

    public static string GetVersionString()
    {
        if (string.IsNullOrEmpty(cachedVersionString))
            cachedVersionString = CString.AsString(glfwGetVersionString());

        return cachedVersionString;
    }

    public static Error GetError()
    {
        byte* description;
        ErrorCode error = glfwGetError(&description);
        return new Error(error, CString.AsString(description));
    }

    public static ErrorCallback? SetErrorCallback(ErrorCallback? callback)
    {
        return glfwSetErrorCallback(callback);
    }

    public static Platform GetPlatform()
    {
        return glfwGetPlatform();
    }

    public static bool IsPlatformSupported(Platform platform)
    {
        return glfwPlatformSupported(platform) == NativeTrue;
    }
}
