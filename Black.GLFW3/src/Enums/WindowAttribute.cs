namespace Black.GLFW3;

public enum MutableAttributes : int
{
    Decorated = 0x00020005,
    Resizable = 0x00020003,
    Floating = 0x00020007,
    AutoIconify = 0x00020006,
    FocusOnShow = 0x0002000C,
    MousePassthrough = 0x0002000D,
}

public enum Attributes : int
{
    Focused = 0x00020001,
    Iconified = 0x00020002,
    Maximized = 0x00020008,
    Hovered = 0x0002000B,
    Visible = 0x00020004,
    Resizable = 0x00020003,
    Decorated = 0x00020005,
    AutoIconify = 0x00020006,
    Floating = 0x00020007,
    TransparentFramebuffer = 0x0002000A,
    FocusOnShow = 0x0002000C,
    MousePassthrough = 0x0002000D,
    ClientAPI = 0x00022001,
    ContextCreationAPI = 0x0002200B,
    ContextVersionMajor = 0x00022002,
    ContextVersionMinor = 0x00022003,
    ContextRevision = 0x00022004,
    OpenGLForwardCompat = 0x00022006,
    ContextDebug = 0x00022007,
    OpenGLDebugContext = ContextDebug,
    OpenGLProfile = 0x00022008,
    ContextReleaseBehaviour = 0x00022009,
    ContextNoError = 0x0002200A,
    ContextRobustness = 0x00022005,
    DoubleBuffer = 0x00021010,
}
