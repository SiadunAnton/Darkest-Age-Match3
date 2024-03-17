using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject _churchPrefab;
    [SerializeField] private GameObject _field;
    [SerializeField] private Button _buyButton;
    [SerializeField] private GameObject _priestButton;
	private Transform _position;

    public bool IsAllowedChurchSpawn = false;

    public void SpawnChurch(Vector3 place)
    {
        Instantiate(_churchPrefab, place, Quaternion.identity, _field.transform);
        IsAllowedChurchSpawn = false;
        _priestButton.SetActive(true);
    }

    public void AllowChurchSpawn()
    {
        if( Score.Instance.Green >=100)
        {
            Score.Instance.BuyForGreenPoints(100);
            IsAllowedChurchSpawn = true;
            _buyButton.enabled = false;
        }
    }
	
	public void SetDestination(GameObject place)
	{
		_position = place.transform;
	}
	
	public void Nothing(){}
}
