using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Builder _builder;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_builder.IsAllowedChurchSpawn)
        {
            _builder.SpawnChurch(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
