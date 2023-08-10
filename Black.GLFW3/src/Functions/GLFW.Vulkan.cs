namespace Black.GLFW3;

using Black.Unmanaged;
using static Black.GLFW3.Native;

public unsafe static partial class GLFW
{
    public static bool VulkanSupported()
    {
        return glfwVulkanSupported() == True;
    }
    
    public static string[] GetRequiredInstanceExtensions()
    {
        uint count = 0;
        var requiredExtensions = glfwGetRequiredInstanceExtensions(&count);

        var extensions = new string[count];

        for (int i = 0; i < count; i++)
        {
            using var unmanagedExtension = requiredExtensions[i];
            extensions[i] = unmanagedExtension;
        }

        return extensions;
    }

    public static VulkanProcedure GetInstanceProcAddress(nint instance, string procname)
    {
        using var unmanagedProcname = new UnmanagedStr(procname);
        return glfwGetInstanceProcAddress(instance, unmanagedProcname);
    }
    
    public static bool GetPhysicalDevicePresentationSupport(nint instance, nint device, uint queuefamily)
    {
        return glfwGetPhysicalDevicePresentationSupport(instance, device, queuefamily) == True;
    }
    
    public static bool CreateWindowSurface(nint instance, Window window, nint allocator, nint surface)
    {
        return glfwCreateWindowSurface(instance, window, allocator, surface) == True;
    }
}