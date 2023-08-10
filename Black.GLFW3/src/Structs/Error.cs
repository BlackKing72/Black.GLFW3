using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Error(ErrorCodes Code, string Description)
{
    public override string ToString() => $"{Code}: {Description}";
}
