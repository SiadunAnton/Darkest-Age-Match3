using UnityEngine;

public class Panel : MonoBehaviour
{

    public void Reverse()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
