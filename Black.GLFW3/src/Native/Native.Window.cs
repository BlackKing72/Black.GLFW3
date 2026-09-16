#pragma warning disable CA1401 // P/Invokes should not be visible

using System.Runtime.InteropServices;

namespace Black.GLFW3;

// csharpier-ignore-start
public unsafe static partial class GLFWNative
{
    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwDefaultWindowHints();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwWindowHint(int hint, int value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwWindowHintString(int hint, byte* value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowPtr glfwCreateWindow(int width, int height, byte* title, MonitorPtr monitor, WindowPtr share);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwDestroyWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwWindowShouldClose(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowShouldClose(WindowPtr window, int value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial byte* glfwGetWindowTitle(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowTitle(WindowPtr window, byte* title);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowIcon(WindowPtr window, int count, Image* images);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetWindowPos(WindowPtr window, int* xpos, int* ypos);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowPos(WindowPtr window, int xpos, int ypos);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetWindowSize(WindowPtr window, int* width, int* height);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowSizeLimits(WindowPtr window, int minwidth, int minheight, int maxwidth, int maxheight);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowAspectRatio(WindowPtr window, int number, int denom);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowSize(WindowPtr window, int width, int height);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetFramebufferSize(WindowPtr window, int* width, int* height);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetWindowFrameSize(WindowPtr window, int* left, int* top, int* right, int* bottom);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwGetWindowContentScale(WindowPtr window, float* xscale, float* yscale);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial float glfwGetWindowOpacity(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowOpacity(WindowPtr window, float opacity);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwIconifyWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwRestoreWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwMaximizeWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwShowWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwHideWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwFocusWindow(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwRequestWindowAttention(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial MonitorPtr glfwGetWindowMonitor(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowMonitor(WindowPtr window, MonitorPtr monitor, int xpos, int ypos, int width, int height, int refreshRate);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial int glfwGetWindowAttrib(WindowPtr window, Attributes attrib);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowAttrib(WindowPtr window, MutableAttributes attrib, int value);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSetWindowUserPointer(WindowPtr window, void* pointer);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void* glfwGetWindowUserPointer(WindowPtr window);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowPositionCallback? glfwSetWindowPosCallback(WindowPtr window, WindowPositionCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowSizeCallback? glfwSetWindowSizeCallback(WindowPtr window, WindowSizeCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowCloseCallback? glfwSetWindowCloseCallback(WindowPtr window, WindowCloseCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowRefreshCallback? glfwSetWindowRefreshCallback(WindowPtr window, WindowRefreshCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowFocusCallback? glfwSetWindowFocusCallback(WindowPtr window, WindowFocusCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowIconifyCallback? glfwSetWindowIconifyCallback(WindowPtr window, WindowIconifyCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowMaximizeCallback? glfwSetWindowMaximizeCallback(WindowPtr window, WindowMaximizeCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowFramebufferSizeCallback? glfwSetFramebufferSizeCallback(WindowPtr window, WindowFramebufferSizeCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial WindowContentsScaleCallback? glfwSetWindowContentScaleCallback(WindowPtr window, WindowContentsScaleCallback? callback);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwPollEvents();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwWaitEvents();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwWaitEventsTimeout(double timeout);

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwPostEmptyEvent();

    [LibraryImport(GLFWLibrary.Name)]
    public static partial void glfwSwapBuffers(WindowPtr window);
}

// csharpier-ignore-end

#pragma warning disable CA1401 // P/Invokes should not be visible
