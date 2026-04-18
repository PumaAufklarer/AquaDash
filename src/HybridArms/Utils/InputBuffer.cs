using System;

namespace HybridArms.Utils;

public class InputBuffer
{
    private readonly Func<bool> _inputGetter;
    private int _lastTrigger = 0xFFFF;

    public InputBuffer(Func<bool> getter)
    {
        _inputGetter = getter;
    }

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

    public bool IsTriggeredWithin(int frameGap)
    {
        return _lastTrigger <= frameGap;
    }

    public void Consume()
    {
        _lastTrigger = 0xFFFF;
    }
}
