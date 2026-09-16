using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Image(int width, int height, void* pixels)
{
    public static readonly Image Null = new();

    public int Width { get; set; } = width;
    public int Height { get; set; } = height;
    public void* Pixels { get; set; } = pixels;

    public Image(int width, int height, nint pixels) : this(width, height, (void*)pixels) { }
}
