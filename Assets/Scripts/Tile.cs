using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SwapSelector.Instance.SelectToSwap(gameObject, false);
    }
}
