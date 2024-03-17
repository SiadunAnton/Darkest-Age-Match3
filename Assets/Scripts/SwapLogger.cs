using UnityEngine;

public class SwapLogger : MonoBehaviour
{
    private Swapper _swapper;

    private void Awake()
    {
        _swapper = GetComponent<Swapper>();
        _swapper.OnSwapStart += (first,second) => { NotifyStart(); };
        _swapper.OnSwapEnd += (first, second) => { NotifyEnd(); };
    }

    private void NotifyStart()
    {
        Debug.Log("Swap start");
    }

    private void NotifyEnd()
    {
        Debug.Log("Swap end");
    }
}
