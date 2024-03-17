using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private RuleCreator _ruleCreator;
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
