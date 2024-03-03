using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GamepadState
{
    public const int MaxButtonCount = 15;
    public const int MaxAxesCount = 6;

    private fixed byte buttons[MaxButtonCount];
    private fixed float axes[MaxAxesCount];

    public Span<InputActions> Buttons
    {
        get
        {
            fixed (byte* b = buttons) 
                return new(b, 15);
        }
    }
    public Span<float> Axes
    {
        get
        {
            fixed (float* f = axes) 
                return new(f, 6);
        }
    }
}