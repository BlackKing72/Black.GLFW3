namespace Black.GLFW3;

public enum ContextRobustness : int
{
    NoRobustness            = 0x0,
    NoResetNotification     = 0x00031001,
    LoseContextOnReset      = 0x00031002,
}
