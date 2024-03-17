using UnityEngine;

public class FieldLocker : MonoBehaviour
{
    [SerializeField] private MatchCounter _counter;
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        _counter.OnMatch += (x) =>  Lock();
        _counter.OnMatchEnd += Unlock;
    }

    private void Lock()
    {
        _panel.SetActive(true);
    }

    private void Unlock()
    {
        _panel.SetActive(false);
    }
}
