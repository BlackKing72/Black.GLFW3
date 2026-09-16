using static Black.GLFW3.GLFWNative;

namespace Black.GLFW3;

public static unsafe partial class GLFW
{
    public static void MakeContextCurrent(this WindowPtr window)
    {
        glfwMakeContextCurrent(window);
    }

    public static WindowPtr GetCurrentContext()
    {
        return glfwGetCurrentContext();
    }

    public static void SwapInterval(int interval)
    {
        glfwSwapInterval(interval);
    }

    public static void SwapInterval(VSyncMode mode)
    {
        glfwSwapInterval((int)mode);
    }

    public static bool ExtensionSupported(ReadOnlySpan<byte> extension)
    {
        return CString.Use(extension, str => glfwExtensionSupported(str) == NativeTrue);
    }

    public static bool ExtensionSupported(ReadOnlySpan<char> extension)
    {
        return CString.Use(extension, str => glfwExtensionSupported(str) == NativeTrue);
    }

    public static bool ExtensionSupported(string extension)
    {
        return CString.Use(extension, str => glfwExtensionSupported(str) == NativeTrue);
    }

    public static nint GetProcAddress(ReadOnlySpan<byte> procedure)
    {
        return CString.Use(procedure, str => (nint)glfwGetProcAddress(str));
    }

    public static nint GetProcAddress(ReadOnlySpan<char> procedure)
    {
        return CString.Use(procedure, str => (nint)glfwGetProcAddress(str));
    }

    public static nint GetProcAddress(string procedure)
    {
        return CString.Use(procedure, str => (nint)glfwGetProcAddress(str));
    }
}
