using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Black.GLFW3;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct AllocatorPtr<T>
    where T : unmanaged
{
    private readonly void* allocate;
    private readonly void* reallocate;
    private readonly void* deallocate;
    private readonly T* user;

    public AllocatorPtr(
        AllocateFunction<T> allocate,
        ReallocateFunction<T> reallocate,
        DeallocateFunction<T> deallocate,
        ref T user
    )
    {
        this.allocate = (void*)Marshal.GetFunctionPointerForDelegate(AllocateWrapper);
        this.reallocate = (void*)Marshal.GetFunctionPointerForDelegate(ReallocateWrapper);
        this.deallocate = (void*)Marshal.GetFunctionPointerForDelegate(DeallocateWrapper);
        this.user = (T*)Unsafe.AsPointer(ref user);

        void* AllocateWrapper(nint size, void* user)
        {
            return (void*)allocate(size, ref *(T*)user);
        }
        void* ReallocateWrapper(void* block, nint size, void* user)
        {
            return (void*)reallocate((nint)block, size, ref *(T*)user);
        }
        void DeallocateWrapper(void* block, void* user)
        {
            deallocate((nint)block, ref *(T*)user);
        }
    }

    public ref T User
    {
        get => ref *user;
    }
}
