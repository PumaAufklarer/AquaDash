namespace HybridArms.Gameplay.Characters.Player;

public partial record PlayerState(
    HorizontalState Horizontal,
    VerticalState Vertical
);

public partial record HorizontalState(
    float MoveDirection,
    float CurrentSpeed
);

public partial record VerticalState(
    bool IsOnFloor,
    bool IsJumping,
    float CurrentSpeed
);
