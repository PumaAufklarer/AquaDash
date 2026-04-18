using Godot;

namespace HybridArms.Gameplay.Characters.Player.Components;

public static class HorizontalMovement
{
    public static HorizontalState Update(
        HorizontalState current,
        float moveDirection,
        PlayerConfig config,
        bool isOnFloor)
    {
        float acceleration = isOnFloor ? config.HorizontalAcceleration : config.HorizontalAirAcceleration;
        float targetSpeed = moveDirection * config.HorizontalSpeed;
        float currentSpeed = current.CurrentSpeed;
        float speedDelta = targetSpeed - currentSpeed;

        if (Mathf.Abs(speedDelta) < acceleration)
        {
            currentSpeed = targetSpeed;
        }
        else
        {
            currentSpeed += Mathf.Sign(speedDelta) * acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, -config.HorizontalSpeed, config.HorizontalSpeed);
        }

        return current with
        {
            MoveDirection = moveDirection,
            CurrentSpeed = currentSpeed
        };
    }
}
