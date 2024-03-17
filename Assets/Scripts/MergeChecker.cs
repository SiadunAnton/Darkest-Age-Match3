using System.Collections.Generic;
using UnityEngine;

public class MergeChecker 
{
    private float _distance = 0.7f;

    private List<GameObject> _logicBlock = new List<GameObject>();
    public Color Color;
    public Sprite Sprite;
    private GameObject _gameObject;

    public MergeChecker(GameObject owner, Sprite sprite)
    {
        _gameObject = owner;
        Sprite = sprite;
    }

    public List<GameObject> GetMerged()
    {
        _logicBlock.Clear();
        Sprite = _gameObject.GetComponent<SpriteRenderer>().sprite;
        _logicBlock.Add(_gameObject);
        Merge(_gameObject);
        return _logicBlock;
    }

    private void Merge(GameObject target)
    {
        Remerge(target, Vector2.up);
        Remerge(target, Vector2.down);
        Remerge(target, Vector2.left);
        Remerge(target, Vector2.right);
    }

    private void Remerge( GameObject target, Vector2 direction)
    {
        var position = (Vector2)target.transform.position;
        var nearTile = GetObjectInDirection(position, direction);

        if ( nearTile != null)
        {
            if (TileExistInList(nearTile, _logicBlock) || !IsSuitableTile(nearTile))
                return;

            _logicBlock.Add(nearTile);
            Merge(nearTile);
        }
    }

    private GameObject GetObjectInDirection(Vector2 position, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(position + _distance * direction, direction, 0.02f);

        if (hit.transform != null)
            return hit.transform.gameObject;
        return null;
    }

    private bool TileExistInList(GameObject tile, List<GameObject> list)
    {
        foreach(var listCell in list)
        {
            if (listCell == tile)
                return true;
        }
        return false;
    }

    private bool IsSuitableTile(GameObject tile)
    {
        return tile.GetComponent<SpriteRenderer>().sprite == Sprite;
    }
}
