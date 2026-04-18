using System;
using Godot;

public partial class Startgame : TextureButton
{
    public override void _Ready()
    {
        Pressed += OnStartButtonPressed;
    }

    private void OnStartButtonPressed()
    {
        if (GetTree().ChangeSceneToFile("res://scenes/levels/gameworld.tscn") is Error err and not Error.Ok)
        {
            GD.PrintErr("切换场景失败: ", err);
        }
    }
}
