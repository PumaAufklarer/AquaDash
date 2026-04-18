using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerControl : CharacterBody2D
{
    // Horizontal movement config
    public int horizontalSpeed = 512;
    public int horizontalAccPerFrame = 256;
    public int horizontalOnAirAccPerFrame = 64;

    // Vertical movement config
    public int verticalSpeed = 1024;
    public int gravity = 256;
    public int jumpSpeed = 1280;
    public int jumpGravity = 64;

    private PlayerState _currentState;

    public InputBuffer groundBuffer;
    public InputBuffer jumpBuffer;

    private List<InputBuffer> _inputBufferList = [];

    public override void _Ready()
    {
        groundBuffer = _registerInputBuffer(() => IsOnFloor());
        jumpBuffer = _registerInputBuffer(() => Input.IsActionJustPressed("move_jump"));

        ChangeState(new GroundState(this));
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (var buffer in _inputBufferList)
        {
            buffer.Update();
        }
        _currentState?.Update();
        MoveAndSlide();
    }

    public void ChangeState(PlayerState newState)
    {
        var newStateName = newState.GetType().Name;
        GD.Print($"Change state to {newStateName}");
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    private InputBuffer _registerInputBuffer(Func<bool> getter)
    {
        var buffer = new InputBuffer(getter);
        _inputBufferList.Add(buffer);
        return buffer;
    }
}

public abstract partial class PlayerState : RefCounted
{
    protected PlayerControl player;

    public PlayerState(PlayerControl _player) { player = _player; }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}

public partial class GroundState : PlayerState
{
    public GroundState(PlayerControl _player) : base(_player) { }

    public override void Update()
    {
        HorizontalMove(player, player.horizontalAccPerFrame);

        if (!player.IsOnFloor())
        {
            player.ChangeState(new AirState(player));
        }

        if (player.jumpBuffer.IsTriggeredWithin(5))
        {
            player.jumpBuffer.Consume();
            player.ChangeState(new JumpState(player));
        }
    }

    public static void HorizontalMove(PlayerControl player, int horizontalAccPerFrame)
    {
        float moveDir = Input.GetAxis("move_left", "move_right");
        float targetHorizontalSpeed = moveDir * player.horizontalSpeed;
        float currentHorizontalSpeed = player.Velocity.X;
        float deltaHorizontalSpeed = targetHorizontalSpeed - currentHorizontalSpeed;
        if (Mathf.Abs(deltaHorizontalSpeed) < horizontalAccPerFrame)
        {
            currentHorizontalSpeed = targetHorizontalSpeed;
        }
        else
        {
            currentHorizontalSpeed += Mathf.Sign(deltaHorizontalSpeed) * horizontalAccPerFrame;
            currentHorizontalSpeed = Mathf.Clamp(currentHorizontalSpeed, -player.horizontalSpeed, player.horizontalSpeed);
        }
        player.Velocity = new Vector2(currentHorizontalSpeed, player.Velocity.Y);
    }
}

public partial class JumpState : PlayerState
{
    public JumpState(PlayerControl _player) : base(_player) { }

    public override void Enter()
    {
        player.Velocity = new Vector2(player.Velocity.X, -player.jumpSpeed);
    }

    public override void Update()
    {
        GroundState.HorizontalMove(player, player.horizontalOnAirAccPerFrame);
        AirState.VerticalMove(player, player.jumpGravity);

        if (Input.IsActionJustReleased("move_jump"))
        {
            player.ChangeState(new AirState(player));
        }
        if (player.IsOnFloor())
        {
            player.ChangeState(new GroundState(player));
        }
    }
}

public partial class AirState : PlayerState
{
    public AirState(PlayerControl _player) : base(_player) { }

    public override void Update()
    {
        GroundState.HorizontalMove(player, player.horizontalOnAirAccPerFrame);
        VerticalMove(player, player.gravity);

        if (player.groundBuffer.IsTriggeredWithin(5) && Input.IsActionJustPressed("move_jump"))
        {
            player.groundBuffer.Consume();
            player.ChangeState(new JumpState(player));
        }
        if (player.IsOnFloor())
        {
            player.ChangeState(new GroundState(player));
        }
    }

    public static void VerticalMove(PlayerControl player, int gravityAcc)
    {
        float currentVerticalSpeed = player.Velocity.Y;
        float deltaVerticalSpeed = player.verticalSpeed - currentVerticalSpeed;
        if (deltaVerticalSpeed < gravityAcc)
        {
            currentVerticalSpeed = player.verticalSpeed;
        }
        else
        {
            currentVerticalSpeed += gravityAcc;
            currentVerticalSpeed = Mathf.Min(currentVerticalSpeed, player.verticalSpeed);
        }
        player.Velocity = new Vector2(player.Velocity.X, currentVerticalSpeed);
    }
}
