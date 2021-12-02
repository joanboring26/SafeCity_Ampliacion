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
        Debug.Log("Update");
        if(cState == STATE.BURNING && ((Time.deltaTime > GridSingleton.getRef().nextUpdateTime) || (Time.time + GridSingleton.getRef().updateDelayTime == GridSingleton.getRef().nextUpdateTime)))
        {
            GridSingleton.getRef().nextUpdateTime = Time.time + GridSingleton.getRef().updateDelayTime;
            CheckTileDestroy(CurrentBurnStrength);
            SpreadFire(CurrentBurnStrength);
            UpdateFireStatus();
        }
    }

}
