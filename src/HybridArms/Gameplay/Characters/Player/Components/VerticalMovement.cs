using Godot;

namespace HybridArms.Gameplay.Characters.Player.Components;

public static class VerticalMovement
{
    public static VerticalState Update(
        VerticalState current,
        bool isOnFloor,
        bool jumpPressed,
        bool jumpReleased,
        PlayerConfig config)
    {
        float gravity = current.IsJumping ? config.JumpGravity : config.Gravity;
        float currentSpeed = current.CurrentSpeed;
        bool isJumping = current.IsJumping;

        if (isOnFloor)
        {
            currentSpeed = 0f;
            isJumping = false;
        }
        else
        {
            float speedDelta = config.VerticalSpeed - currentSpeed;
            if (speedDelta < gravity)
            {
                currentSpeed = config.VerticalSpeed;
            }
            else
            {
                currentSpeed += gravity;
                currentSpeed = Mathf.Min(currentSpeed, config.VerticalSpeed);
            }
        }

        if (jumpReleased && isJumping)
        {
            isJumping = false;
        }

        return current with
        {
            IsOnFloor = isOnFloor,
            IsJumping = isJumping,
            CurrentSpeed = currentSpeed
        };
    }

    public static VerticalState StartJump(VerticalState current, PlayerConfig config)
    {
        return current with
        {
            IsJumping = true,
            CurrentSpeed = -config.JumpSpeed
        };
    }
}
