#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public unsafe static partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial MonitorPtr* glfwGetMonitors(int* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MonitorPtr glfwGetPrimaryMonitor();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetMonitorPos(MonitorPtr monitor, int* xpos, int* ypos);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetMonitorWorkarea(MonitorPtr monitor, int* xpos, int* ypos, int* width, int* height);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetMonitorPhysicalSize(MonitorPtr monitor, int* widthMM, int* heightMM);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetMonitorContentScale(MonitorPtr monitor, float* xscale, float* yscale);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetMonitorName(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetMonitorUserPointer(MonitorPtr monitor, void* pointer);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void* glfwGetMonitorUserPointer(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MonitorCallback? glfwSetMonitorCallback(MonitorCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial VideoMode* glfwGetVideoModes(MonitorPtr monitor, int* count);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial VideoMode* glfwGetVideoMode(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetGamma(MonitorPtr monitor, float gamma);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial GammaRamp glfwGetGammaRamp(MonitorPtr monitor);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetGammaRamp(MonitorPtr monitor, GammaRamp ramp);
}

// csharpier-ignore-end

#pragma warning restore CA1401 // P/Invokes should not be visible
