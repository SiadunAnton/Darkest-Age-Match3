public abstract class GamePoint
{
    public abstract void Add(Points points, int value);
}

public class WeaponPoint: GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Red += value;
    }
}

public class FoodPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Green += 4;
        points.Red += value;
        points.Blue -= 1;
    }
}

public class FaithPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Blue += value;
    }
}

public class BonusPoint: GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Blue += value + 2;
    }
}

public class NeutralPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Red += 2;
        points.Green += 2;
    }
}

public class LandPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Green += 5 - value;
    }
}

public class ProductPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        points.Blue -= 1;
        points.Red -= 2;
        points.White += value * 3;
    }
}

public class EmptyPoint : GamePoint
{
    public override void Add(Points points, int value)
    {
        
    }
}