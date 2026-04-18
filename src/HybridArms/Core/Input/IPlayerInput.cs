namespace HybridArms.Core.Input;

public interface IPlayerInput
{
    float GetHorizontalAxis();
    bool IsJumpJustPressed();
    bool IsJumpJustReleased();
}
