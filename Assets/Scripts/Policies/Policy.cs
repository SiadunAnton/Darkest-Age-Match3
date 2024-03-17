using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Policy : MonoBehaviour
{
    [SerializeField] private List<Policy> _required = new List<Policy>();
    [SerializeField] private int _price;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    public string Name;

    public bool isActive = false;

    private void Start()
    {
        _button.onClick.AddListener(Activate);
    }

    public void Activate()
    {
        if(Condition())
        {
            Buy();
            isActive = true;
            _button.enabled = false;
            Score.Instance.Policies.Add(this);
            _image.color = Color.gray;
        }
    }

    public bool CheckRequired()
    {
        if (_required.Count == 0)
            return true;
        foreach(var policy in _required)
        {
            if (!policy.isActive)
                return false;
        }
        return true;
    }

    protected virtual bool Condition()
    {
        return Score.Instance.Red >= _price && CheckRequired();
    }

    protected virtual void Buy()
    {
        Score.Instance.BuyForRedPoints(_price);
    }
}
