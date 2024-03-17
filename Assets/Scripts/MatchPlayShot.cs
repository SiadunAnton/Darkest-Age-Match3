using UnityEngine;

public class MatchPlayShot : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _match1x;
    [SerializeField] private AudioClip _match2x;
    [SerializeField] private AudioClip _match3x;
    [SerializeField] private AudioClip _match5x;

    public void PlayMatchSound(int combo)
    {
        if(combo == 1)
            _source.PlayOneShot(_match1x);
        else if (combo == 2)
            _source.PlayOneShot(_match2x);
        else if (combo == 3)
            _source.PlayOneShot(_match3x);
        else 
            _source.PlayOneShot(_match5x);
    }
}
