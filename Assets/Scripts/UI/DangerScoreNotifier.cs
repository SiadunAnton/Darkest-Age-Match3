using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerScoreNotifier : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private int _value;

    void Start()
    {
        StartCoroutine(CheckValue());
    }


    IEnumerator CheckValue()
    {
        for (; ; )
        {
            int score;
            int.TryParse(_score.text, out score);
            if (score <= _value)
            {
                _score.color = Color.red;
            }
            else
            {
                _score.color = Color.white;
            }
            yield return new WaitForSecondsRealtime(0.15f);
        }
    }
}
