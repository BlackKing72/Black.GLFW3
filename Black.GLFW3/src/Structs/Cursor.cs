using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct CursorPtr : IEquatable<CursorPtr>
{
    public static readonly CursorPtr Null = new(null);

    private readonly CursorPtr* handle;

    public bool IsNull => handle == null;
    public readonly CursorPtr* Handle => handle;

    private CursorPtr(CursorPtr* handle) => this.handle = handle;

    public override readonly bool Equals(object? obj) => obj is CursorPtr other && this == other;

    public override readonly int GetHashCode() => ((nuint)handle).GetHashCode();

    public readonly bool Equals(CursorPtr other) => handle == other.handle;

    public static bool operator ==(CursorPtr left, CursorPtr right) => left.handle == right.handle;

    public static bool operator !=(CursorPtr left, CursorPtr right) => left.handle != right.handle;

    public static implicit operator CursorPtr*(CursorPtr window) => window.handle;

    public static explicit operator CursorPtr(CursorPtr* handle) => new(handle);

    public static implicit operator nint(CursorPtr window) => (nint)window.handle;

    public static explicit operator CursorPtr(nint handle) => new((CursorPtr*)handle);
}
