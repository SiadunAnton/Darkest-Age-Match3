using System.Collections;
using UnityEngine;

public class SmoothSwapper : Swapper
{
    [SerializeField] private float _delay = 0.015f;

    public override void Swap(GameObject first, GameObject second)
    {
        StartCoroutine(SwapPositionsWay(first, second));
    }

    protected virtual IEnumerator SwapPositionsWay(GameObject first, GameObject second)
    {
        OnSwapStart?.Invoke(first,second);
        _isSwapping = true;

        var firstFinalPos = second.transform.position;
        var secondFinalPos = first.transform.position;
        for (int i = 1; i < 6; i++)
        {
            first.transform.position = new Vector2(Mathf.Lerp(first.transform.position.x, firstFinalPos.x, i * 0.2f),
                Mathf.Lerp(first.transform.position.y, firstFinalPos.y, i * 0.2f));
            second.transform.position = new Vector2(Mathf.Lerp(second.transform.position.x, secondFinalPos.x, i * 0.2f),
                Mathf.Lerp(second.transform.position.y, secondFinalPos.y, i * 0.2f));
            yield return new WaitForSecondsRealtime(_delay);
        }
        _isSwapping = false;
        OnSwapEnd?.Invoke(first, second);
    }
}
