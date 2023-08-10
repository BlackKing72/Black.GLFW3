using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public record struct Window(nint Handle)
{
    public static readonly Window Null = new();

    public static implicit operator nint(Window window) => window.Handle;
    public static explicit operator Window(nint handle) => new(handle);
}
