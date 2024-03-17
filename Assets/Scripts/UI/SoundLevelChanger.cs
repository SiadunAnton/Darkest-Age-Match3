using UnityEngine;
using UnityEngine.UI;

public class SoundLevelChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _player;
    [SerializeField] private Scrollbar _scrollbar;

    private void Start()
    {
        _player.volume = PlayerPrefs.GetFloat(gameObject.name);
        _scrollbar.value = PlayerPrefs.GetFloat(gameObject.name);
        _scrollbar.onValueChanged.AddListener((x) => SetVolume(x));
    }

    private void SetVolume(float level)
    {
        PlayerPrefs.SetFloat(gameObject.name,level);
        _player.volume = level;
    }
}
