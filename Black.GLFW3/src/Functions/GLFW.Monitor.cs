namespace Black.GLFW3;

using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using static Black.GLFW3.GLFWNative;

public static unsafe partial class GLFW
{
    public static ReadOnlySpan<MonitorPtr> GetMonitors()
    {
        int count = 0;
        var unmanagedMonitors = glfwGetMonitors(&count);
        return new(unmanagedMonitors, count);
    }

    /// <summary> This copies the data to a new array. Prefer using <see cref="GetMonitors"/> instead </summary>
    public static MonitorPtr[] GetMonitorsArray() => [.. GetMonitors()];

    public static MonitorPtr GetPrimaryMonitor()
    {
        return glfwGetPrimaryMonitor();
    }

    public static Point GetMonitorPos(this MonitorPtr monitor)
    {
        (int x, int y) position = (0, 0);
        glfwGetMonitorPos(monitor, &position.x, &position.y);
        return new(position.x, position.y);
    }

    public static Rectangle GetMonitorWorkArea(this MonitorPtr monitor)
    {
        (int x, int y, int width, int height) area = (0, 0, 0, 0);
        glfwGetMonitorWorkarea(monitor, &area.x, &area.y, &area.width, &area.height);
        return new(area.x, area.y, area.width, area.height);
    }

    public static Size GetMonitorPhysicalSize(this MonitorPtr monitor)
    {
        (int width, int height) size = (0, 0);
        glfwGetMonitorPhysicalSize(monitor, &size.width, &size.height);
        return new(size.width, size.height);
    }

    public static Vector2 GetMonitorContentScale(this MonitorPtr monitor)
    {
        (float x, float y) scale = (0, 0);
        glfwGetMonitorContentScale(monitor, &scale.x, &scale.y);
        return new(scale.x, scale.y);
    }

    public static string GetMonitorName(this MonitorPtr monitor)
    {
        return CString.AsString(glfwGetMonitorName(monitor));
    }

    public static void SetMonitorUserPointer<T>(this MonitorPtr monitor, ref T data)
        where T : unmanaged
    {
        var ptr = Unsafe.AsPointer(ref data);
        glfwSetMonitorUserPointer(monitor, ptr);
    }

    public static T GetMonitorUserPointer<T>(this MonitorPtr monitor)
        where T : unmanaged
    {
        var ptr = (T*)glfwGetMonitorUserPointer(monitor);
        return ptr is null ? default : *ptr;
    }

    public static MonitorCallback? SetMonitorCallback(this MonitorCallback? callback)
    {
        return glfwSetMonitorCallback(callback);
    }

    public static ReadOnlySpan<VideoMode> GetVideoModes(this MonitorPtr monitor)
    {
        int count = 0;
        var unmanagedVideoModes = glfwGetVideoModes(monitor, &count);
        return new ReadOnlySpan<VideoMode>(unmanagedVideoModes, count);
    }

    public static VideoMode GetVideoMode(this MonitorPtr monitor)
    {
        return *glfwGetVideoMode(monitor);
    }

    public static void SetGamma(this MonitorPtr monitor, float gamma)
    {
        glfwSetGamma(monitor, gamma);
    }

    public static GammaRamp GetGammaRamp(this MonitorPtr monitor)
    {
        return glfwGetGammaRamp(monitor);
    }

    public static void SetGammaRamp(this MonitorPtr monitor, GammaRamp ramp)
    {
        glfwSetGammaRamp(monitor, ramp);
    }
}
