using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseTile
{

    private void Start()
    {
        Init();
        GridSingleton.getRef().map[currTileX][currTileY] = this;
    }

    public override void CheckTileDestroy(float burnStrength)
    {
        
    }

}
