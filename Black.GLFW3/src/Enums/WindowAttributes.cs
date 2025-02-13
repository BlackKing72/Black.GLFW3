namespace Black.GLFW3;

public enum WindowMutableAttributes : int
{
    Decorated               = 0x00020005,
    Resizable               = 0x00020003,
    Floating                = 0x00020007,
    AutoIconify             = 0x00020006,
    FocusOnShow             = 0x0002000C,
}

public enum WindowAttributes : int
{
    Focused                 = 0x00020001,
    Iconified               = 0x00020002,
    Maximized               = 0x00020008,
    Hovered                 = 0x0002000B,
    Visible                 = 0x00020004,
    Resizable               = 0x00020003,
    Decorated               = 0x00020005,
    AutoIconify             = 0x00020006,
    Floating                = 0x00020007,
    TransparentFramebuffer  = 0x0002000A,
    FocusOnShow             = 0x0002000C,
}
