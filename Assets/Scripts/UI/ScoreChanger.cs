using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{
    [SerializeField] private float _delay = 0.2f;
    [SerializeField] private Score _score;
    [SerializeField] private Text _red;
    [SerializeField] private Text _blue;
    [SerializeField] private Text _white;
    [SerializeField] private Text _green;

    private void Start()
    {
        StartCoroutine(SetScoreProcess());
    }

    IEnumerator SetScoreProcess()
    {
        for (; ; )
        {
            ChangeScore(_red, _score.Red);
            ChangeScore(_blue, _score.Blue);
            ChangeScore(_white, _score.White);
            ChangeScore(_green, _score.Green);
            yield return new WaitForSeconds(_delay);
        }
    }

    private void ChangeScore(Text field, int value)
    {
        int currentScore;
        int.TryParse(field.text, out currentScore);
        if (value == currentScore)
            return;
        if (value < currentScore)
        {
            field.text = (currentScore - 1).ToString();
        }
        else
        {
            field.text = (currentScore + 1).ToString();
        }
    }

}
