namespace HybridArms.Core.Inputs;

public interface IPlayerInput
{
    float GetHorizontalAxis();
    bool IsJumpJustPressed();
    bool IsJumpJustReleased();
}
