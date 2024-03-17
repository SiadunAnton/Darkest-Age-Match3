using UnityEngine;

public class SwapSelector : MonoBehaviour
{
    public static SwapSelector Instance;


    [SerializeField] private float _distance = 0.32f;

    private Swapper _swapper;
    private GameObject _cell;
    private Color _color;

    private void Awake()
    {
        Instance = GetComponent<SwapSelector>();
        _swapper = GetComponent<Swapper>();
    }

    public void Reset()
    {
        if (_cell == null)
            return;

        DrawCellInactive();
        _cell = null;
    }

    public void SelectToSwap(GameObject swapped,bool isCellNeedToBeDefined)
    {
        if (_swapper.IsSwapping)
            return;

        if (_cell == null || _cell == swapped )
        {
            if( !isCellNeedToBeDefined)
            {
                _cell = swapped;
                DrawCellActive();
            }
            else
            {
                return;
            }
        }
        else
        {
            if ( Vector2.Distance(_cell.transform.position, swapped.transform.position) > _distance )
            {
                Reset();
                return;
            }

            _swapper.Swap(_cell, swapped);
            Reset();
        }
    }

    private void DrawCellActive()
    {
        _color = _cell.GetComponent<SpriteRenderer>().color;
        _cell.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    private void DrawCellInactive()
    {
        _cell.GetComponent<SpriteRenderer>().color = _color;
    }
}
