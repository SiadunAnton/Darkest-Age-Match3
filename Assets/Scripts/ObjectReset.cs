using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    [SerializeField] private GameObject _reference;

    private void Awake()
    {
        ResetReference(ref _reference);
    }

    private void ResetReference(ref GameObject reference)
    {
        reference = new GameObject("noname");
    }
}
