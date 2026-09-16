using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GammaRamp(ushort* red, ushort* green, ushort* blue, uint size)
{
    public readonly ushort* red = red;
    public readonly ushort* green = green;
    public readonly ushort* blue = blue;
    public readonly uint size = size;

    public Span<ushort> Red => new(red, (int)size);
    public Span<ushort> Green => new(green, (int)size);
    public Span<ushort> Blue => new(blue, (int)size);
}
