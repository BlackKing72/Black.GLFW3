using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Explicit, Size = (sizeof(byte) * ButtonCount + sizeof(float) * AxesCount))]
public unsafe struct GamepadState : IEquatable<GamepadState>
{
    public const int ButtonCount = 15;
    public const int AxesCount = 6;

    [FieldOffset(0)]
    public fixed byte buttons[ButtonCount];

    [FieldOffset(sizeof(byte) * ButtonCount)]
    public fixed float axes[AxesCount];

    public InputAction this[GamepadButton button]
    {
        get => (InputAction)buttons[(int)button];
    }

    public float this[GamepadAxis axis]
    {
        get => axes[(int)axis];
    }

    public ReadOnlySpan<InputAction> Buttons
    {
        get
        {
            fixed (byte* ptr = buttons)
                return new(ptr, ButtonCount);
        }
    }

    public ReadOnlySpan<float> Axes
    {
        get
        {
            fixed (float* ptr = axes)
                return new(ptr, AxesCount);
        }
    }

    public override bool Equals(object? obj) => obj is GamepadState other && this.Equals(other);

    public override readonly int GetHashCode()
    {
        fixed (float* a = axes)
        fixed (byte* b = buttons)
            return HashCode.Combine((nint)b, (nint)a);
    }

    public bool Equals(GamepadState other) => Buttons == other.Buttons && Axes == other.Axes;

    public static bool operator ==(GamepadState left, GamepadState right) => left.Equals(right);

    public static bool operator !=(GamepadState left, GamepadState right) => !left.Equals(right);
}
