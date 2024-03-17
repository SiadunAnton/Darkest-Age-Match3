using UnityEngine;
using System.Collections.Generic;
using System;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int Forfeit = 1;
    public int Red { get { return _points.Red; } }
    public int Blue { get { return _points.Blue; }  }
    public int White { get { return _points.White; } }
    public int Green { get { return _points.Green; } }

    [SerializeField] public List<Policy> Policies = new List<Policy>();
    [SerializeField] private int _startScore = 7;
    [SerializeField] private Sprite _weapon;
    [SerializeField] private Sprite _food;
    [SerializeField] private Sprite _faith;
    [SerializeField] private Sprite _bonus;
    [SerializeField] private Sprite _neutral;
    [SerializeField] private Sprite _land;
    [SerializeField] private Sprite _product;

    private Points _points;

    private void Awake()
    {
        _points = new Points(_startScore);
        Instance = GetComponent<Score>();
    }
    
    public void BuyForRedPoints(int value)
    {
        _points.Red -= value;
    }

    public void BuyForGreenPoints(int value)
    {
        _points.Green -= value;
    }

    public void BuyForWhitePoints(int value)
    {
        _points.White -= value;
    }

    public void BuyForBluePoints(int value)
    {
        _points.Blue -= value;
    }

    public bool isLost()
    {
        return _points.Red < 0 || _points.Blue < 0 || _points.White < 0 || _points.Green < 0;
    }

    public void Penalty()
    {
        _points.Red -= Forfeit;
        _points.White -= Forfeit;
        _points.Blue -= Forfeit;
        _points.Green -= Forfeit;
    }

    public void AddScoreBySprite(Sprite sprite,int value)
    {
        GamePoint point = new EmptyPoint();

        if(sprite == _weapon)
        {
            HusbandryPolicy();
            point = new WeaponPoint();
        }
        if (sprite == _food)
        {
            HusbandryPolicy();
            point = new FoodPoint();
        }
        if (sprite == _faith)
        {
            HusbandryPolicy();
            NaturePolicy();
            point = new FaithPoint();
            
        }
        if (sprite == _bonus)
        {
            HusbandryPolicy();
            NaturePolicy();
            point = new BonusPoint();
        }
        if (sprite == _neutral)
        {
            HusbandryPolicy();
            CleanWaterPolicy(value);
            point = new NeutralPoint();
        }
        if (sprite == _land)
        {
            HusbandryPolicy();
            RevolutionPolicy(value);
            point = new LandPoint();
        }
        if (sprite == _product)
        {
            HusbandryPolicy();
            point = new ProductPoint();
        }

        point.Add(_points,value);
    }

    private void NaturePolicy()
    {
        if (Policies.Exists(x => x.Name == "Nature_policy"))
            _points.Blue += 5;
    }

    private void CleanWaterPolicy(int value)
    {
        if (Policies.Exists(x => x.Name == "CleanWater_policy"))
            _points.White += 2 * value;
        else
            _points.White += -2;
    }

    private void HusbandryPolicy()
    {
        if (Policies.Exists(x => x.Name == "Husbandry_policy"))
        {
            _points.Red += 1;
            _points.Green += 1;
        }
    }

    private void RevolutionPolicy(int value)
    {
        if (Policies.Exists(x => x.Name == "Revolution_policy"))
        {
            _points.Red += 3 * value;
            _points.Green += 4 * value + 5;
        }
    }
}
