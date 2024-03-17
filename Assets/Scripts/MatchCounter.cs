using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchCounter : MonoBehaviour
{
    public UnityAction<List<GameObject>> OnMatch;
    public UnityAction OnMatchEnd;

    [SerializeField] private MatchPlayShot _matchSoundPlayer;
    [SerializeField] private List<MatchController> _controllers;
    [SerializeField] private float _delay = 0.1f;

    private List<GameObject> _checking = new List<GameObject>();
    public int Combo = 0;

    private void Start()
    {
        OnMatch += MatchListener;
        OnMatch += (x) => _matchSoundPlayer.PlayMatchSound(++Combo);

        foreach (var controller in _controllers)
        {
            controller.OnMatch += OnMatch;
        }
    }

    private void MatchListener(List<GameObject> checking)
    {
        foreach(var tile in checking)
        {
            _checking.Add(tile);
        }
        StopAllCoroutines();
        StartCoroutine(TimerForEndMatch());
    }

    IEnumerator TimerForEndMatch()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(_delay);
            var matchEnded = true;
            foreach(var tile in _checking )
            {
                if(tile.GetComponent<TileTransparentRecreator>().isMatching)
                {
                    matchEnded = false;
                }
            }
            if (matchEnded)
            {
                _checking.Clear();
                Combo = 0;
                OnMatchEnd?.Invoke();
                yield break;
            }
        }
    }

}
