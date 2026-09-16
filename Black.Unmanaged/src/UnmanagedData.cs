using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Black.Unmanaged;

public unsafe readonly struct UnmanagedData<T> : IDisposable where T : unmanaged
{
    private readonly T* pointer;
    private readonly uint sizeInBytes;

    public void* Unmanaged => pointer;
    public T Managed => *pointer;

    public uint SizeInBytes => sizeInBytes;

    public UnmanagedData()
    {
        sizeInBytes = (uint)sizeof(T);
        pointer = (T*)NativeMemory.Alloc(sizeInBytes);
    }
    public UnmanagedData(void* unmanaged)
    {
        sizeInBytes = (uint)sizeof(T);
        pointer = (T*)unmanaged;
    }

    public UnmanagedData(T managed)
    {
        sizeInBytes = (uint)sizeof(T);
        pointer = (T*)NativeMemory.Alloc(sizeInBytes);
        NativeMemory.Copy(&managed, pointer, sizeInBytes);
    }

    public void Dispose()
    {
        NativeMemory.Free(pointer);
    }

    public static implicit operator void*(UnmanagedData<T> data) => data.pointer;
    public static implicit operator T*(UnmanagedData<T> data) => (T*)data.pointer;
    public static implicit operator nint(UnmanagedData<T> data) => (nint)data.pointer;
}
