#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    internal const int True = 1;
    internal const int False = 0;
    internal const int DontCare = -1;

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwInit();

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwTerminate();

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwInitHint(InitHints hint, int value);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetVersion(int* major, int* minor, int* rev);

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetVersionString();

    [DllImport(GLFWLibrary.Name)]
    internal static extern ErrorCodes glfwGetError(UnmanagedStr* description);

    [DllImport(GLFWLibrary.Name)]
    internal static extern ErrorCallback? glfwSetErrorCallback(ErrorCallback? callback);
}

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
