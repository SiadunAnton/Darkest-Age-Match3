using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteRandomizer : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetRandomSprite()
    {
        _renderer.sprite = GetRandomSprite();
    }

    private Sprite GetRandomSprite()
    {
        var value = Random.Range(0, _sprites.Count);
        return _sprites[value];
    }
}
