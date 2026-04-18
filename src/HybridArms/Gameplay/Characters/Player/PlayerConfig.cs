using Godot;

namespace HybridArms.Gameplay.Characters.Player;

[GlobalClass]
public partial class PlayerConfig : Resource
{
    [ExportGroup("Horizontal Movement")]
    [Export] public float HorizontalSpeed { get; set; } = 512f;
    [Export] public float HorizontalAcceleration { get; set; } = 256f;
    [Export] public float HorizontalAirAcceleration { get; set; } = 64f;

    [ExportGroup("Vertical Movement")]
    [Export] public float VerticalSpeed { get; set; } = 1024f;
    [Export] public float Gravity { get; set; } = 256f;
    [Export] public float JumpSpeed { get; set; } = 1280f;
    [Export] public float JumpGravity { get; set; } = 64f;

    [ExportGroup("Input")]
    [Export] public int InputBufferFrames { get; set; } = 5;
}
