#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    public static extern int glfwVulkanSupported();
    
    [DllImport(GLFWLibrary.Name)]
    public static extern UnmanagedStr* glfwGetRequiredInstanceExtensions(uint* count);

    [DllImport(GLFWLibrary.Name)]
    public static extern VulkanProcedure glfwGetInstanceProcAddress(nint instance, UnmanagedStr procname);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern int glfwGetPhysicalDevicePresentationSupport(nint instance, nint device, uint queuefamily);
    
    [DllImport(GLFWLibrary.Name)]
    public static extern int glfwCreateWindowSurface(nint instance, Window window, nint allocator, nint surface);
}

#pragma warning restore CA1401 // P/Invokes should not be visible
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time