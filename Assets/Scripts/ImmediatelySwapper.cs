using UnityEngine;

public sealed class ImmediatelySwapper : Swapper
{
    public override void Swap(GameObject first, GameObject second)
    {
        if (_isSwapping)
            return;
        _isSwapping = true;

        var secPosition = first.transform.position;
        first.transform.position = second.transform.position;
        second.transform.position = secPosition;

        _isSwapping = false;
    }
}
