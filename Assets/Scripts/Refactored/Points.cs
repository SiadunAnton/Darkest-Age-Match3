using System;

[Serializable]
public class Points 
{
    public Points(int startScore)
    {
        Red = Blue = White = Green = startScore;
    }

    public Points()
    {

    }

    public int Red;
    public int Blue;
    public int White;
    public int Green;
}
