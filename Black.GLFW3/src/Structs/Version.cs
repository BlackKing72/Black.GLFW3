using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Version
{
    public readonly int Major, Minor, Revision;

    public Version(int major, int minor, int revision)
        => (Major, Minor, Revision) = (major, minor, revision);

    public override string ToString() => $"{Major}.{Minor}.{Revision}";
}