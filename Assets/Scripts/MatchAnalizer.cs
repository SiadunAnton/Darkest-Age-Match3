using System.Collections.Generic;
using UnityEngine;

public static class MatchAnalizer 
{
    public static bool IsMatch(List<GameObject> merged)
    {
        List<float> heights = new List<float>();
        List<float> widths = new List<float>();
        foreach(var tile in merged)
        {
            var tileY = tile.transform.position.y;
            var tileX = tile.transform.position.x;

            if(!heights.Exists(x => x == tileY))
            {
                heights.Add(tileY);
            }
            if (!widths.Exists(x => x == tileX))
            {
                widths.Add(tileX);
            }
        }
        return heights.Count >= 3 || widths.Count >= 3;
    }
}
