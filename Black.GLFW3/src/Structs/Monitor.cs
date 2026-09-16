using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct MonitorPtr : IEquatable<MonitorPtr>
{
    public static readonly MonitorPtr Null = new(null);

    private readonly MonitorPtr* handle = null;

    public bool IsNull => handle == null;
    public readonly MonitorPtr* Handle => handle;

    private MonitorPtr(MonitorPtr* handle) => this.handle = handle;

    public override readonly bool Equals(object? obj) => obj is MonitorPtr other && this == other;
    public override readonly int GetHashCode() => ((nuint)handle).GetHashCode();

    public readonly bool Equals(MonitorPtr other) => handle == other.handle;
    public static bool operator ==(MonitorPtr left, MonitorPtr right) => left.handle == right.handle;
    public static bool operator !=(MonitorPtr left, MonitorPtr right) => left.handle != right.handle;

    public static implicit operator MonitorPtr*(MonitorPtr window) => window.handle;
    public static implicit operator nint(MonitorPtr window) => (nint)window.handle;
    public static explicit operator MonitorPtr(MonitorPtr* handle) => new(handle);
    public static explicit operator MonitorPtr(nint handle) => new((MonitorPtr*)handle);
}
