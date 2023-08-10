using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct GammaRamp
{
    public readonly unsafe ushort* red;
    public readonly unsafe ushort* green;
    public readonly unsafe ushort* blue;
    public readonly uint size;

    public Span<ushort> Red   => new(red, (int)size);
    public Span<ushort> Green => new(green, (int)size);
    public Span<ushort> Blue  => new(blue, (int)size);

    public GammaRamp(ushort* red, ushort* green, ushort* blue, uint size)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.size = size;
    }
}