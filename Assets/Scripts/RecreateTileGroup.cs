using System.Collections.Generic;
using UnityEngine;

public static class RecreateTileGroup 
{
    public static void RecreateGroup(List<GameObject> group)
    {
        var tilesWithPS = new List<TileTransparentRecreator>();
        var other = new List<TileTransparentRecreator>();

        foreach (var tile in group)
        {
            var recreator = tile.GetComponent<TileTransparentRecreator>();

            if (recreator.ParticleSystemDuration() != 0f)
            {
                tilesWithPS.Add(recreator);
            }
            else
            {
                other.Add(recreator);
            }
        }
        if(tilesWithPS.Count == 0f)
        {
            foreach (var tile in other)
            {
                tile.Recreate();
            }
            return;
        }
        foreach(var tilePS in tilesWithPS)
        {
            tilePS.Recreate();
            foreach(var tile in other)
            {
                tile.Recreate(tilePS.ParticleSystemDuration());
            }
        }
    }
}
