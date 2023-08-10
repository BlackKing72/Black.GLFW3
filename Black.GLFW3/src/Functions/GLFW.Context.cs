namespace Black.GLFW3;

using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    public static void MakeContextCurrent(this Window window)
    {
        glfwMakeContextCurrent(window);
    }

    public static Window GetCurrentContext()
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

    public static bool ExtensionSupported(string extensionName)
    {
        using var nativeExtension = new UnmanagedStr(extensionName);
        return glfwExtensionSupported(nativeExtension) == Native.True;
    }

    public static OpenGLProcedure GetProcAddress(string procedureName)
    {
        using var nativeProcedureName = new UnmanagedStr(procedureName);
        return glfwGetProcAddress(nativeProcedureName);
    }
}