using System.Reflection;
using System.Runtime.InteropServices;

namespace Black.GLFW3;

public static partial class GLFWLibrary
{
    public const string Name = "glfw";

    public static void Initialize ()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), LibraryImporterResolver);
    }

    public static nint LibraryImporterResolver (string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == GLFWLibrary.Name)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
                return NativeLibrary.Load("glfw3", assembly, searchPath);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
                return NativeLibrary.Load("glfw", assembly, searchPath);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) 
                return NativeLibrary.Load("libglfw.3", assembly, searchPath);
        }

        return nint.Zero;
    }
}
