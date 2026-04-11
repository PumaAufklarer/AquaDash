using Godot;
using System;

public class InputBuffer
{
    private readonly Func<bool> _inputGetter;
    private int _lastTrigger = 0xFFFF;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="getter">输入检查表达式，例如 () => Input.IsActionJustPressed("jump")</param>
    public InputBuffer(Func<bool> getter)
    {
        _inputGetter = getter;
    }

    /// <summary>
    /// 在每帧 _PhysicsProcess 中调用，用于扫描输入
    /// </summary>
    public void Update()
    {
        if (_inputGetter())
        {
            _lastTrigger = 0;
        }
        else
        {
            _lastTrigger += 1;
        }
    }

    /// <summary>
    /// 检查在“容差时间”内是否触发过输入
    /// </summary>
    public bool IsTriggeredWithin(int gap)
    {
        if (_lastTrigger <= gap)
        {
            return true;
        }
        return false;
    }

    public void Consume()
    {
        _lastTrigger = 0xFFFF;
    }
}