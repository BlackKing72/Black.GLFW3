#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    internal static extern unsafe void glfwMakeContextCurrent(Window window);

    [DllImport(GLFWLibrary.Name)]
    internal static extern unsafe Window glfwGetCurrentContext();

    [DllImport(GLFWLibrary.Name)]
    internal static extern unsafe void glfwSwapInterval(int interval);

    [DllImport(GLFWLibrary.Name)]
    internal static extern unsafe int glfwExtensionSupported(UnmanagedStr extension);

    [DllImport(GLFWLibrary.Name)]
    internal static extern unsafe OpenGLProcedure glfwGetProcAddress(UnmanagedStr procname);
}

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
