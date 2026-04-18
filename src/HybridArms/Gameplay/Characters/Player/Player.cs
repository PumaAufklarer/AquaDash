using System.Collections.Generic;
using Godot;
using HybridArms.Core.Input;
using HybridArms.Gameplay.Characters.Player.Components;
using HybridArms.Utils;

namespace HybridArms.Gameplay.Characters.Player;

public partial class Player : CharacterBody2D
{
    [Export] public PlayerConfig? Config { get; set; }

    private IPlayerInput _input = null!;
    private PlayerState _state = null!;
    private InputBuffer _groundBuffer = null!;
    private InputBuffer _jumpBuffer = null!;
    private List<InputBuffer> _inputBuffers = null!;

    public override void _Ready()
    {
        Config ??= new PlayerConfig();
        _input = new GodotPlayerInput();
        _state = new PlayerState(
            new HorizontalState(0f, 0f),
            new VerticalState(IsOnFloor(), false, 0f)
        );

        _groundBuffer = RegisterBuffer(() => IsOnFloor());
        _jumpBuffer = RegisterBuffer(() => _input.IsJumpJustPressed());
        _inputBuffers = new List<InputBuffer> { _groundBuffer, _jumpBuffer };
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (var buffer in _inputBuffers)
        {
            buffer.Update();
        }

        float moveDir = _input.GetHorizontalAxis();
        bool isOnFloor = IsOnFloor();
        bool jumpPressed = _input.IsJumpJustPressed();
        bool jumpReleased = _input.IsJumpJustReleased();

        var newHorizontal = HorizontalMovement.Update(
            _state.Horizontal,
            moveDir,
            Config,
            isOnFloor
        );

        var newVertical = VerticalMovement.Update(
            _state.Vertical,
            isOnFloor,
            jumpPressed,
            jumpReleased,
            Config
        );

        if (ShouldJump(isOnFloor, jumpPressed))
        {
            _jumpBuffer.Consume();
            newVertical = VerticalMovement.StartJump(newVertical, Config);
        }

        _state = _state with
        {
            Horizontal = newHorizontal,
            Vertical = newVertical
        };

        Velocity = new Vector2(_state.Horizontal.CurrentSpeed, _state.Vertical.CurrentSpeed);
        MoveAndSlide();
    }

    private bool ShouldJump(bool isOnFloor, bool jumpPressed)
    {
        if (_jumpBuffer.IsTriggeredWithin(Config.InputBufferFrames))
        {
            if (isOnFloor)
            {
                return true;
            }
            if (_groundBuffer.IsTriggeredWithin(Config.InputBufferFrames))
            {
                return true;
            }
        }
        return false;
    }

    private InputBuffer RegisterBuffer(System.Func<bool> getter)
    {
        var buffer = new InputBuffer(getter);
        return buffer;
    }
}
