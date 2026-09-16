# Black.GLFW3

A .NET 10 GLFW wrapper with supports for Native AOT.

- GLFW 3.5.1 support
- Native AOT compatible
- C# managed API
- Native unsafe API


### Requirements

> [!NOTE]
> This library targets GLFW 3.5.1, but older versions may also work. If your application calls a function that is not available on your binary, it may (more likely will) cause the application to crash.

This library includes pre-compiled binaries for 64-bit Windows, Linux and macOS for convenience. However, its **recommended** to replace the binaries with your own copies. The library will automatically copy the binaries to the output when building.

For Windows and MacOS you can grab a pre-compiled binary on [GLFW](https://www.glfw.org/download.html) download page. For linux check if your distro provides GLFW 3.5.1, if its not available, you will need to compile it from source. 

The binaries are located at `Black.GLFW3/native/<platform>/`, just replace the files in the corresponding platform. 

### Sample

```cs
using Black.GLFW3;

if (!GLFW.Init())
{
    throw new Exception("Failed to initialize GLFW");
}

var window = GLFW.CreateWindow(200, 200, "Clipboard Test");
if (window == WindowPtr.Null)
{
    GLFW.Terminate();
    throw new Exception("Failed to create window");
}

GLFW.MakeContextCurrent(window);
GLFW.SwapInterval(1);

while (!GLFW.WindowShouldClose(window))
{
    GLFW.SwapBuffers(window);
    GLFW.WaitEvents();
}

GLFW.Terminate();
```

## Notes

- The functions are written/tested as I use/need, so expect some bugs and/or missing convenient methods on some functions.
- For supported platforms see [.NET Native AOT Platform Restrictions]([https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net7#platformarchitecture-restrictions](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=windows%2Cnet9plus#platformarchitecture-restrictions)).
