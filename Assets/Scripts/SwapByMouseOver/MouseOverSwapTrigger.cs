using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverSwapTrigger : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        SwapSelector.Instance.SelectToSwap(gameObject, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SwapSelector.Instance.Reset();
    }
}
