namespace Black.GLFW3;

using System.Diagnostics;
using static Black.GLFW3.GLFWNative;

public static unsafe partial class GLFW
{
    public static bool VulkanSupported()
    {
        return glfwVulkanSupported() == NativeTrue;
    }

    public static string[] GetRequiredInstanceExtensions()
    {
        uint count = 0;
        var requiredExtensions = glfwGetRequiredInstanceExtensions(&count);
        var extensions = new string[count];

        for (int i = 0; i < count; i++)
        {
            var extensionName = CString.AsString(requiredExtensions[i]);
            Debug.Assert(extensionName is not null);
            extensions[i] = extensionName;
        }

        return extensions;
    }

    public static nint GetInstanceProcAddress(nint instance, string procedure)
    {
        return CString.Use(procedure, str => (nint)glfwGetInstanceProcAddress(instance, str));
    }

    public static bool GetPhysicalDevicePresentationSupport(nint instance, nint device, uint queuefamily)
    {
        return glfwGetPhysicalDevicePresentationSupport(instance, device, queuefamily) == NativeTrue;
    }

    public static bool CreateWindowSurface(nint instance, WindowPtr window, nint allocator, nint surface)
    {
        return glfwCreateWindowSurface(instance, window, allocator, surface) == NativeTrue;
    }
}
