using System.Collections.Generic;
using UnityEngine;

public class PriestMerge : MonoBehaviour
{
    [SerializeField] private MatchController _matchController;
    [SerializeField] public float _delta = 0.7f;
    private Sprite _sprite;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject center;

    public void BindWithTile(GameObject owner, GameObject effect)
    {
        _sprite = owner.GetComponent<SpriteRenderer>().sprite;
        _matchController = GetComponent<MatchController>();
        _effect = effect;
        center = owner;
        _matchController.OnMatch += (x) => { Activate(); };
        Debug.Log("Priest Binded!");
    }

    public void Activate()
    {
        var nearTiles = new List<SpriteRenderer>();

        var position = (Vector2) center.transform.position;

        for(int x = -1 ; x < 2; x++ )
        {
            for (int y = -1; y < 2; y++)
            {                
                RaycastHit2D hit = Physics2D.Raycast(position +  _delta*new Vector2(x,y) , new Vector2(x, y));
                Tile tile;
                if(hit.transform != null && hit.transform.gameObject.TryGetComponent<Tile>(out tile))
                {
                    nearTiles.Add(hit.transform.gameObject.GetComponent<SpriteRenderer>());
                }
                
            }
        }
        
        DestroyImmediate(_effect);
        
        foreach (var tile in nearTiles)
        {
            tile.gameObject.GetComponent<TileRecreator>().Recreate();
        }
        Score.Instance.AddScoreBySprite(_sprite, nearTiles.Count*3);
    }
}
