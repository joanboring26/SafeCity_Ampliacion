using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseTile
{
    public void Start()
    {
        Init();
        GridSingleton.getRef().map[currTileX][currTileY] = this;
    }

    public void Update()
    {
        if(cState == STATE.BURNING && ((Time.deltaTime > GridSingleton.nextUpdateTime) || (Time.time + GridSingleton.updateDelayTime == GridSingleton.nextUpdateTime)))
        {
            GridSingleton.nextUpdateTime = Time.time + GridSingleton.updateDelayTime;
            CheckTileDestroy(CurrentBurnStrength);
            SpreadFire(CurrentBurnStrength);
            UpdateFireStatus();
        }
    }

}
