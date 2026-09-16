using System.Runtime.InteropServices;
using System.Text;

namespace Black.Unmanaged;

[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct UnmanagedStr : IDisposable
{
    private readonly byte* pointer;
    private readonly uint length;

    public byte* Unmanaged => pointer;
    public string Managed => ToString();

    public Span<byte> View => new(pointer, (int)length);

    public UnmanagedStr(uint strLength)
    {
        length = strLength;
        pointer = (byte*)NativeMemory.Alloc(length);
        pointer[0] = 0;
    }

    public UnmanagedStr(byte* cstr)
    {
        ArgumentNullException.ThrowIfNull(cstr);

        length = UnmanagedHelper.StrLen(cstr);
        pointer = (byte*)NativeMemory.Alloc(length);
        NativeMemory.Copy(cstr, pointer, length);
    }

    public UnmanagedStr(string str) : this(str.AsSpan())
    {
        ArgumentException.ThrowIfNullOrEmpty(str);
    }

    public UnmanagedStr(ReadOnlySpan<char> str)
    {
        ArgumentOutOfRangeException.ThrowIfZero(str.Length);

        // string length + 1 for null terminator
        length = checked((uint)Encoding.UTF8.GetByteCount(str) + 1);
        pointer = (byte*)NativeMemory.Alloc(length);

        var view = new Span<byte>(pointer, (int)length);
        int byteWritten = Encoding.UTF8.GetBytes(str, view);
        view[byteWritten] = 0;
    }

    public UnmanagedStr(ReadOnlySpan<byte> str)
    {
        ArgumentOutOfRangeException.ThrowIfZero(str.Length);

        // string length + 1 for null terminator
        length = checked((uint)str.Length + 1);
        pointer = (byte*)NativeMemory.Alloc(length);

        var view = new Span<byte>(pointer, (int)length);
        str.CopyTo(view);
        view[^1] = 0;
    }

    public void Dispose()
    {
        NativeMemory.Free(pointer);
    }

    public override string ToString()
    {
        return Encoding.UTF8.GetString(pointer, (int)length);
    }

    public static implicit operator string(UnmanagedStr str) => str.ToString();
    public static implicit operator byte*(UnmanagedStr str) => str.pointer;

    public static explicit operator UnmanagedStr(string str) => new(str);
    public static explicit operator UnmanagedStr(byte* cstr) => new(cstr);
}
