#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    internal static extern Monitor* glfwGetMonitors(int* count);

    [DllImport(GLFWLibrary.Name)]
    internal static extern Monitor glfwGetPrimaryMonitor();

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetMonitorPos(Monitor monitor, int* xpos, int* ypos);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetMonitorWorkarea(Monitor monitor, int* xpos, int* ypos, int* width, int* height);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetMonitorPhysicalSize(Monitor monitor, int* widthMM, int* heightMM);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetMonitorContentScale(Monitor monitor, float* xscale, float* yscale);

    [DllImport(GLFWLibrary.Name)]
    internal static extern UnmanagedStr glfwGetMonitorName(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetMonitorUserPointer(Monitor monitor, void* pointer);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void* glfwGetMonitorUserPointer(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern MonitorCallback? glfwSetMonitorCallback (MonitorCallback? callback);

    [DllImport(GLFWLibrary.Name)]
    internal static extern VideoMode* glfwGetVideoModes(Monitor monitor, int* count);

    [DllImport(GLFWLibrary.Name)]
    internal static extern VideoMode* glfwGetVideoMode(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetGamma(Monitor monitor, float gamma);

    [DllImport(GLFWLibrary.Name)]
    internal static extern GammaRamp* glfwGetGammaRamp(Monitor monitor);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetGammaRamp(Monitor monitor, GammaRamp ramp);
}

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time