using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VideoMode(int Width, int Height, int RedBits, int GreenBits, int BlueBits, int RefreshRate)
{
    public static readonly VideoMode Null = new();
}
