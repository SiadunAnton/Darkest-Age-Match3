using UnityEngine;
using UnityEngine.Events;

public abstract class Swapper : MonoBehaviour
{
    public UnityAction<GameObject, GameObject> OnSwapStart;
    public UnityAction<GameObject, GameObject> OnSwapEnd;
    public bool IsSwapping { get { return _isSwapping; } }

    protected bool _isSwapping = false;

    public abstract void Swap(GameObject first, GameObject second);
}
