using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascadeFieldInitialization : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tiles = new List<GameObject>();
    [SerializeField] private float _delay = 0.1f;

    private void Start()
    {
        StartCoroutine(RecreateFieldCascade());
    }

    IEnumerator RecreateFieldCascade()
    {
        yield return new WaitForSeconds(2*_delay);
        foreach (var tile in _tiles)
        {
            if (!tile.gameObject.activeSelf)
                continue;
            tile.GetComponent<TileTransparentRecreator>().Recreate();
            yield return new WaitForSeconds(_delay);
        }
    }
}
