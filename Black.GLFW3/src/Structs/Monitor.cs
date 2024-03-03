using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Monitor(nint Handle)
{
    public static readonly Monitor Null = new();

    public static implicit operator nint(Monitor monitor) => monitor.Handle;
    public static explicit operator Monitor(nint handle) => new(handle);
}
