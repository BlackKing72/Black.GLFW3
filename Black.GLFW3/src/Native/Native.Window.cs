#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

using System.Runtime.InteropServices;
using Black.Unmanaged;

namespace Black.GLFW3;

public unsafe static partial class Native
{
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwDefaultWindowHints();

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwWindowHint(int hint, int value);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwWindowHintString(int hint, UnmanagedStr value);

    [DllImport(GLFWLibrary.Name)]
    internal static extern Window glfwCreateWindow(int width, int height, UnmanagedStr title, Monitor monitor, Window share);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwDestroyWindow(Window window);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwWindowShouldClose(Window window);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowShouldClose(Window window, int value);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowTitle(Window window, UnmanagedStr title);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowIcon(Window window, int count, Image* images);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetWindowPos(Window window, int* xpos, int* ypos);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowPos(Window window, int xpos, int ypos);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetWindowSize(Window window, int* width, int* height);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowSizeLimits(Window window, int minwidth, int minheight, int maxwidth, int maxheight);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowAspectRatio(Window window, int number, int denom);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowSize(Window window, int width, int height);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetFramebufferSize(Window window, int* width, int* height);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetWindowFrameSize(Window window, int* left, int* top, int* right, int* bottom);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwGetWindowContentScale(Window window, float* xscale, float* yscale);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern float glfwGetWindowOpacity(Window window);

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowOpacity(Window window, float opacity);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwIconifyWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwRestoreWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwMaximizeWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwShowWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwHideWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwFocusWindow(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwRequestWindowAttention(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern Monitor glfwGetWindowMonitor(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowMonitor(Window window, Monitor monitor, int xpos, int ypos, int width, int height, int refreshRate);

    [DllImport(GLFWLibrary.Name)]
    internal static extern int glfwGetWindowAttrib(Window window, WindowAttributes attrib);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowAttrib(Window window, WindowAttributes attrib, int value);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSetWindowUserPointer(Window window, void* pointer);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void* glfwGetWindowUserPointer(Window window);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowPositionCallback? glfwSetWindowPosCallback(Window window, WindowPositionCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowSizeCallback? glfwSetWindowSizeCallback(Window window, WindowSizeCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowCloseCallback? glfwSetWindowCloseCallback(Window window, WindowCloseCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowRefreshCallback? glfwSetWindowRefreshCallback(Window window, WindowRefreshCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowFocusCallback? glfwSetWindowFocusCallback(Window window, WindowFocusCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowIconifyCallback? glfwSetWindowIconifyCallback(Window window, WindowIconifyCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowMaximizeCallback? glfwSetWindowMaximizeCallback(Window window, WindowMaximizeCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowFramebufferSizeCallback? glfwSetFramebufferSizeCallback(Window window, WindowFramebufferSizeCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern WindowContentsScaleCallback? glfwSetWindowContentScaleCallback(Window window, WindowContentsScaleCallback? callback);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwPollEvents();
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwWaitEvents();
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwWaitEventsTimeout(double timeout);
    
    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwPostEmptyEvent();

    [DllImport(GLFWLibrary.Name)]
    internal static extern void glfwSwapBuffers(Window window);
}

#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time