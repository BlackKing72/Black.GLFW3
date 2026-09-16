using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct WindowPtr : IEquatable<WindowPtr>
{
    public static readonly WindowPtr Null = new(null);

    private readonly WindowPtr* handle = null;

    public bool IsNull => handle == null;
    public readonly WindowPtr* Handle => handle;

    private WindowPtr(WindowPtr* handle) => this.handle = handle;

    public override readonly string ToString() => ((nint)handle).ToString();

    public override readonly bool Equals(object? obj) => obj is WindowPtr other && this == other;

    public override readonly int GetHashCode() => ((nuint)handle).GetHashCode();

    public readonly bool Equals(WindowPtr other) => handle == other.handle;

    public static bool operator ==(WindowPtr left, WindowPtr right) => left.handle == right.handle;

    public static bool operator !=(WindowPtr left, WindowPtr right) => left.handle != right.handle;

    public static implicit operator WindowPtr*(WindowPtr window) => window.handle;

    public static implicit operator nint(WindowPtr window) => (nint)window.handle;

    public static explicit operator WindowPtr(WindowPtr* handle) => new(handle);

    public static explicit operator WindowPtr(nint handle) => new((WindowPtr*)handle);
}
