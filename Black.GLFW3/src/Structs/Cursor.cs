using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public record struct Cursor(nint Handle) : IDisposable
{
    public static readonly Cursor Null = new();

    public Cursor(StandardCursorShapes shape) 
        : this(GLFW.CreateStandardCursor(shape)) { }

    public void Dispose()
    {
        GLFW.DestroyCursor(this);
        Handle = nint.Zero;
    }

    public static implicit operator nint(Cursor cursor) => cursor.Handle;
    public static explicit operator Cursor(nint handle) => new(handle);
}
