using Godot;

namespace HybridArms.Core.Input;

public partial class GodotPlayerInput : RefCounted, IPlayerInput
{
    public float GetHorizontalAxis()
    {
        return Input.GetAxis("move_left", "move_right");
    }

    public bool IsJumpJustPressed()
    {
        return Input.IsActionJustPressed("move_jump");
    }

    public bool IsJumpJustReleased()
    {
        return Input.IsActionJustReleased("move_jump");
    }
}
