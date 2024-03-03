using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Image(int Width, int Height, nint Pixels)
{
    public static readonly Image Null = new();
}
