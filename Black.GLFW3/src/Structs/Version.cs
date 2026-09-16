using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Version(int Major, int Minor, int Revision)
{
    public override string ToString() => $"{Major}.{Minor}.{Revision}";
}
