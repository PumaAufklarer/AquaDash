using Godot;

namespace PBStudio
{
    public abstract record HorizontalMoveState;
    public record IdleState : HorizontalMoveState;
    public record RunningState : HorizontalMoveState;
    public abstract record VerticalMoveState;
    public record OnFloorState : VerticalMoveState;
    public record JumpState : VerticalMoveState;
    public record FallState : VerticalMoveState;

    public partial class MobController : CharacterBody2D
    {
        private HorizontalMoveState _horizontalMoveState = new IdleState();
        private VerticalMoveState _verticalMoveState = new OnFloorState();

        private HorizontalMoveState UpdateHorizontalMoveState()
        {

        }

        private VerticalMoveState UpdateVerticalMoveState()
        {

        }
    }
}