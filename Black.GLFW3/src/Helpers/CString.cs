using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Black.GLFW3;

internal static class CString
{
    internal unsafe delegate void UseHandler(byte* data);
    internal unsafe delegate T UseHandler<T>(byte* data)
        where T : unmanaged;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Use(ReadOnlySpan<byte> str, UseHandler handler)
    {
        fixed (byte* data = str)
            handler(data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe T Use<T>(ReadOnlySpan<byte> str, UseHandler<T> handler)
        where T : unmanaged
    {
        fixed (byte* data = str)
            return handler(data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Use(ReadOnlySpan<char> str, UseHandler handler)
    {
        var data = (byte*)NativeMemory.Alloc((uint)Encoding.UTF8.GetByteCount(str) + 1);
        handler(data);
        NativeMemory.Free(data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe T Use<T>(ReadOnlySpan<char> str, UseHandler<T> handler)
        where T : unmanaged
    {
        var data = (byte*)NativeMemory.Alloc((uint)Encoding.UTF8.GetByteCount(str) + 1);
        T result = handler(data);
        NativeMemory.Free(data);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Use(string str, UseHandler handler)
    {
        var data = Utf8StringMarshaller.ConvertToUnmanaged(str);
        handler(data);
        Utf8StringMarshaller.Free(data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe T Use<T>(string str, UseHandler<T> handler)
        where T : unmanaged
    {
        var data = Utf8StringMarshaller.ConvertToUnmanaged(str);
        T result = handler(data);
        Utf8StringMarshaller.Free(data);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ReadOnlySpan<byte> AsBytes(byte* str)
    {
        return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(str);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ReadOnlySpan<char> AsSpan(byte* str)
    {
        var buffer = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(str);
        return Encoding.UTF8.GetString(buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe string AsString(byte* str, string overrideDefault = "")
    {
        return Utf8StringMarshaller.ConvertToManaged(str) ?? overrideDefault;
    }
}
