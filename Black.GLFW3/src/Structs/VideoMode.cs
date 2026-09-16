using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VideoMode(
    int Width,
    int Height,
    int RedBits,
    int GreenBits,
    int BlueBits,
    int RefreshRate
)
{
    public override string ToString() => $"{Width}x{Height}@{RefreshRate} R{RedBits}G{GreenBits}B{BlueBits}";
}
