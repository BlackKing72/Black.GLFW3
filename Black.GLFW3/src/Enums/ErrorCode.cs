namespace Black.GLFW3;

public enum ErrorCode : int
{
    /// <summary><b>GLFW_NO_ERROR</b> No error has occurred.</summary>
    NoError = 0x00000000,

    /// <summary><b>GLFW_NOT_INITIALIZED</b> GLFW has not been initialized.</summary>
    NotInitialized = 0x00010001,

    /// <summary><b>GLFW_NO_CURRENT_CONTEXT</b> No context is current for this thread.</summary>
    NoCurrentContext = 0x00010002,

    /// <summary><b>GLFW_INVALID_ENUM</b> One of the arguments to the function was an invalid enum value.</summary>
    InvalidEnum = 0x00010003,

    /// <summary><b>GLFW_INVALID_VALUE</b> One of the arguments to the function was an invalid value.</summary>
    InvalidValue = 0x00010004,

    /// <summary><b>GLFW_OUT_OF_MEMORY</b> 	A memory allocation failed.</summary>
    OutOfMemory = 0x00010005,

    /// <summary><b>GLFW_API_UNAVAILABLE</b> GLFW could not find support for the requested API on the system.</summary>
    ApiUnavailable = 0x00010006,

    /// <summary><b>GLFW_VERSION_UNAVAILABLE</b> The requested OpenGL or OpenGL ES version is not available.</summary>
    VersionUnavailable = 0x00010007,

    /// <summary><b>GLFW_PLATFORM_ERROR</b> A platform-specific error occurred that does not match any of the more specific categories.</summary>
    PlatformError = 0x00010008,

    /// <summary><b>GLFW_FORMAT_UNAVAILABLE</b> The requested format is not supported or available.</summary>
    FormatUnavailable = 0x00010009,

    /// <summary><b>GLFW_NO_WINDOW_CONTEXT</b> The specified window does not have an OpenGL or OpenGL ES context.</summary>
    NoWindowContext = 0x0001000A,

    /// <summary><b>GLFW_CURSOR_UNAVAILABLE</b> The specified cursor shape is not available.</summary>
    CursorUnavailable = 0x0001000B,

    /// <summary><b>GLFW_FEATURE_UNAVAILABLE</b> The requested feature is not provided by the platform.</summary>
    FeatureUnavailable = 0x0001000C,

    /// <summary><b>GLFW_FEATURE_UNIMPLEMENTED</b> The requested feature is not implemented for the platform.</summary>
    FeatureUnimplemented = 0x0001000D,

    /// <summary><b>GLFW_PLATFORM_UNAVAILABLE</b> Platform unavailable or no matching platform was found.</summary>
    PlatformUnavailable = 0x0001000E,
}

public record struct ErrorDescription(string Summary, string Description, string Analysis);

public static class ErrorCodeExtension
{
    extension(ErrorCode code)
    {
        public ErrorDescription GetDescription()
        {
            if (errorToDescriptionMap.TryGetValue(code, out var description))
                return description;

            return new ErrorDescription(
                "Unknown error",
                "An unknown error has occurred",
                $"Error code: {code}"
            );
        }
    }

    private static readonly Dictionary<ErrorCode, ErrorDescription> errorToDescriptionMap = new()
    {
        [ErrorCode.NoError] = new(
            Summary: "No error has occurred.",
            Description: "No error has occurred.",
            Analysis: "Yay."
        ),
        [ErrorCode.NotInitialized] = new(
            Summary: "GLFW has not been initialized.",
            Description: "This occurs if a GLFW function was called that must not be called unless the library is initialized.",
            Analysis: "Application programmer error. Initialize GLFW before calling any function that requires initialization."
        ),
        [ErrorCode.NoCurrentContext] = new(
            Summary: "No context is current for this thread.",
            Description: "This occurs if a GLFW function was called that needs and operates on the current OpenGL or OpenGL ES context but no context is current on the calling thread. One such function is glfwSwapInterval.",
            Analysis: "Application programmer error. Ensure a context is current before calling functions that require a current context."
        ),
        [ErrorCode.InvalidEnum] = new(
            Summary: "One of the arguments to the function was an invalid enum value.",
            Description: "One of the arguments to the function was an invalid enum value, for example requesting GLFW_RED_BITS with glfwGetWindowAttrib.",
            Analysis: "Application programmer error. Fix the offending call."
        ),
        [ErrorCode.InvalidValue] = new(
            Summary: "One of the arguments to the function was an invalid value.",
            Description: "One of the arguments to the function was an invalid value, for example requesting a non-existent OpenGL or OpenGL ES version like 2.7. Requesting a valid but unavailable OpenGL or OpenGL ES version will instead result in a GLFW_VERSION_UNAVAILABLE error.",
            Analysis: "Application programmer error. Fix the offending call."
        ),
        [ErrorCode.OutOfMemory] = new(
            Summary: "A memory allocation failed.",
            Description: "A memory allocation failed.",
            Analysis: "A bug in GLFW or the underlying operating system. Report the bug to our issue tracker."
        ),
        [ErrorCode.ApiUnavailable] = new(
            Summary: "GLFW could not find support for the requested API on the system.",
            Description: "GLFW could not find support for the requested API on the system.",
            Analysis: "The installed graphics driver does not support the requested API, or does not support it via the chosen context creation API. Below are a few examples. Some pre-installed Windows graphics drivers do not support OpenGL. AMD only supports OpenGL ES via EGL, while Nvidia and Intel only support it via a WGL or GLX extension. macOS does not provide OpenGL ES at all. The Mesa EGL, OpenGL and OpenGL ES libraries do not interface with the Nvidia binary driver. Older graphics drivers do not support Vulkan."
        ),
        [ErrorCode.VersionUnavailable] = new(
            Summary: "The requested OpenGL or OpenGL ES version is not available.",
            Description: "The requested OpenGL or OpenGL ES version (including any requested context or framebuffer hints) is not available on this machine.",
            Analysis: "The machine does not support your requirements. If your application is sufficiently flexible, downgrade your requirements and try again. Otherwise, inform the user that their machine does not match your requirements. Future invalid OpenGL and OpenGL ES versions, for example OpenGL 4.8 if 5.0 comes out before the 4.x series gets that far, also fail with this error and not GLFW_INVALID_VALUE, because GLFW cannot know what future versions will exist."
        ),
        [ErrorCode.PlatformError] = new(
            Summary: "A platform-specific error occurred that does not match any of the more specific categories.",
            Description: "A platform-specific error occurred that does not match any of the more specific categories.",
            Analysis: "A bug or configuration error in GLFW, the underlying operating system or its drivers, or a lack of required resources. Report the issue to our issue tracker."
        ),
        [ErrorCode.FormatUnavailable] = new(
            Summary: "The requested format is not supported or available.",
            Description: "If emitted during window creation, the requested pixel format is not supported. If emitted when querying the clipboard, the contents of the clipboard could not be converted to the requested format.",
            Analysis: "If emitted during window creation, one or more hard constraints did not match any of the available pixel formats. If your application is sufficiently flexible, downgrade your requirements and try again. Otherwise, inform the user that their machine does not match your requirements. If emitted when querying the clipboard, ignore the error or report it to the user, as appropriate."
        ),
        [ErrorCode.NoWindowContext] = new(
            Summary: "The specified window does not have an OpenGL or OpenGL ES context.",
            Description: "A window that does not have an OpenGL or OpenGL ES context was passed to a function that requires it to have one.",
            Analysis: "Application programmer error. Fix the offending call."
        ),
        [ErrorCode.CursorUnavailable] = new(
            Summary: "The specified cursor shape is not available.",
            Description: "The specified standard cursor shape is not available, either because the current platform cursor theme does not provide it or because it is not available on the platform.",
            Analysis: "Platform or system settings limitation. Pick another standard cursor shape or create a custom cursor."
        ),
        [ErrorCode.FeatureUnavailable] = new(
            Summary: "The requested feature is not provided by the platform.",
            Description: "The requested feature is not provided by the platform, so GLFW is unable to implement it. The documentation for each function notes if it could emit this error.",
            Analysis: "Platform or platform version limitation. The error can be ignored unless the feature is critical to the application. A function call that emits this error has no effect other than the error and updating any existing out parameters."
        ),
        [ErrorCode.FeatureUnimplemented] = new(
            Summary: "The requested feature is not implemented for the platform.",
            Description: "The requested feature has not yet been implemented in GLFW for this platform.",
            Analysis: "An incomplete implementation of GLFW for this platform, hopefully fixed in a future release. The error can be ignored unless the feature is critical to the application. A function call that emits this error has no effect other than the error and updating any existing out parameters."
        ),
        [ErrorCode.PlatformUnavailable] = new(
            Summary: "Platform unavailable or no matching platform was found.",
            Description: "If emitted during initialization, no matching platform was found. If the GLFW_PLATFORM init hint was set to GLFW_ANY_PLATFORM, GLFW could not detect any of the platforms supported by this library binary, except for the Null platform. If the init hint was set to a specific platform, it is either not supported by this library binary or GLFW was not able to detect it. If emitted by a native access function, GLFW was initialized for a different platform than the function is for.",
            Analysis: "Failure to detect any platform usually only happens on non-macOS Unix systems, either when no window system is running or the program was run from a terminal that does not have the necessary environment variables. Fall back to a different platform if possible or notify the user that no usable platform was detected. Failure to detect a specific platform may have the same cause as above or be because support for that platform was not compiled in. Call glfwPlatformSupported to check whether a specific platform is supported by a library binary."
        ),
    };
}
