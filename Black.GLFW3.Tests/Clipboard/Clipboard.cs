//========================================================================
// Clipboard test program
// Copyright (c) Camilla Löwy <elmindreda@glfw.org>
//
// This software is provided 'as-is', without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would
//    be appreciated but is not required.
//
// 2. Altered source versions must be plainly marked as such, and must not
//    be misrepresented as being the original software.
//
// 3. This notice may not be removed or altered from any source
//    distribution.
//
//========================================================================
//
// This program is used to test the clipboard functionality.
//
//========================================================================

using System.Runtime.InteropServices;
using Black.GLFW3;

const uint ColorBufferBit = 0x00004000;

// static void usage(void)
// {
//     printf("Usage: clipboard [-h]\n");
// }

GLFW.SetErrorCallback(ErrorCallback);
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

var glClearColor = Marshal.GetDelegateForFunctionPointer<ClearColor>(GLFW.GetProcAddress("glClearColor"));
var glClear = Marshal.GetDelegateForFunctionPointer<Clear>(GLFW.GetProcAddress("glClear"));

GLFW.SetKeyCallback(window, KeyCallback);

glClearColor(0.400f, 0.200f, 0.600f, 1.000f);

while (!GLFW.WindowShouldClose(window))
{
    glClear(ColorBufferBit);

    GLFW.SwapBuffers(window);
    GLFW.WaitEvents();
}

GLFW.Terminate();

static void ErrorCallback(ErrorCode error, string description)
{
    Console.WriteLine($"{error}: {description}");
}

static void KeyCallback(WindowPtr window, Keys key, int scancode, InputAction action, Modifiers mods)
{
    Modifiers modifier = RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
        ? Modifiers.Super
        : Modifiers.Control;

    if (action != InputAction.Press)
        return;

    switch (key)
    {
        case Keys.Escape:
        {
            GLFW.SetWindowShouldClose(window, true);
            break;
        }
        case Keys.V when mods.HasFlag(modifier):
        {
            string clipboard = GLFW.GetClipboardString(window);
            Console.WriteLine(
                !string.IsNullOrEmpty(clipboard)
                    ? $"Clipboard contains \"{clipboard}\""
                    : $"Clipboard does not contain a string"
            );
            break;
        }
        case Keys.C when mods.HasFlag(modifier):
        {
            var clipboard = "Hello GLFW World!";
            GLFW.SetClipboardString(window, clipboard);
            Console.WriteLine($"Setting clipboard to \"{clipboard}\"");
            break;
        }
    }
}

delegate void ClearColor(float r, float g, float b, float a);
delegate void Clear(uint mask);
