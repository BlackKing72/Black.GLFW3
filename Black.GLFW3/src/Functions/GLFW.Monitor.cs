namespace Black.GLFW3;

using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    public static ReadOnlySpan<Monitor> GetMonitors()
    {
        int count = 0;
        var unmanagedMonitors = glfwGetMonitors(&count);
        return new(unmanagedMonitors, count);
    }

    public static Monitor GetPrimaryMonitor()
    {
        return glfwGetPrimaryMonitor();
    }

    public static (int x, int y) GetMonitorPos(this Monitor monitor)
    {
        (int x, int y) position = (0, 0);
        glfwGetMonitorPos(monitor, &position.x, &position.y);
        return position;
    }

    public static (int x, int y, int width, int height) GetMonitorWorkArea(this Monitor monitor)
    {
        (int x, int y, int width, int height) area = (0, 0, 0, 0);
        glfwGetMonitorWorkarea(monitor, &area.x, &area.y, &area.width, &area.height);
        return area;
    }

    public static (int width, int height) GetMonitorPhysicalSize(this Monitor monitor)
    {
        (int width, int height) physicalSize = (0, 0);
        glfwGetMonitorPhysicalSize(monitor, &physicalSize.width, &physicalSize.height);
        return physicalSize;
    }

    public static (float x, float y) GetMonitorContentScale(this Monitor monitor)
    {
        (float x, float y) scale = (0, 0);
        glfwGetMonitorContentScale(monitor, &scale.x, &scale.y);
        return scale;
    }

    public static string GetMonitorName(this Monitor monitor)
    {
        using var unmanagedName = glfwGetMonitorName(monitor);
        return unmanagedName;
    }

    public static void SetMonitorUserPointer<T>(this Monitor monitor, T data) where T : unmanaged
    {
        using var unmanagedData = new UnmanagedData<T>(data);
        glfwSetMonitorUserPointer(monitor, unmanagedData);
    }

    public static T GetMonitorUserPointer<T>(this Monitor monitor) where T : unmanaged
    {
        using var unmanagedData = new UnmanagedData<T>(glfwGetMonitorUserPointer(monitor));
        return unmanagedData.ManagedData;
    }

    public static MonitorCallback? SetMonitorCallback(this MonitorCallback? callback)
    {
        return glfwSetMonitorCallback(callback);
    }

    public static ReadOnlySpan<VideoMode> GetVideoModes(this Monitor monitor)
    {
        int count = 0;
        var unmanagedVideoModes = glfwGetVideoModes(monitor, &count);
        return new ReadOnlySpan<VideoMode>(unmanagedVideoModes, count);
    }

    public static VideoMode GetVideoMode(this Monitor monitor)
    {
        using var unmanagedData = new UnmanagedData<VideoMode>(glfwGetVideoMode(monitor));
        return unmanagedData.ManagedData;
    }

    public static void SetGamma(this Monitor monitor, float gamma)
    {
        glfwSetGamma(monitor, gamma);
    }

    public static GammaRamp GetGammaRamp(this Monitor monitor)
    {
        using var unmanagedData = new UnmanagedData<GammaRamp>(glfwGetGammaRamp(monitor));
        return unmanagedData.ManagedData;
    }

    public static void SetGammaRamp(this Monitor monitor, GammaRamp ramp)
    {
        glfwSetGammaRamp(monitor, ramp);
    }
}