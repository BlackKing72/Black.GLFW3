using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Black.Unmanaged;

public unsafe static class UnmanagedHelper
{
    public static uint StrLen(byte* str)
    {
        byte* current = str;
        uint length = 0;

        while (*current != '\0')
        {
            length = checked(length + 1);
            current = (byte*)Unsafe.Add<byte>(current, 1);
        }

        return length;
    }

    public static T* UnsafeAsPointer<T>(this ReadOnlySpan<T> span) where T : unmanaged
    {
        return (T*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }
    public static T* UnsafeAsPointer<T>(this Span<T> span) where T : unmanaged
    {
        return (T*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }
    public static T* UnsafeAsPointer<T>(this T[] span) where T : unmanaged
    {
        return (T*)Unsafe.AsPointer(ref MemoryMarshal.GetArrayDataReference(span));
    }
}
