using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameBreaker : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _textField;
    private EndGameDetector _endGameDetector;

    [Inject]
    public void Construct(EndGameDetector detector)
    {
        _endGameDetector = detector;
    }

    private void Start()
    {
        _endGameDetector.OnWin += WinNotify;
        _endGameDetector.OnLose += LoseNotify;
    }

    private void OnDestroy()
    {
        _endGameDetector.OnWin -= WinNotify;
        _endGameDetector.OnLose -= LoseNotify;
    }

    public void WinNotify()
    {
        BlockGameWithMessage("You Win!!!");
    }

    public void LoseNotify()
    {
        BlockGameWithMessage("You Lose.");
    }

    private void BlockGameWithMessage(string message)
    {
        _panel.SetActive(true);
        _textField.text = message;
    }
}