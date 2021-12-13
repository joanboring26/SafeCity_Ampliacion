using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : BaseTile
{
    public bool setFireOnStart;
    public void Start()
    {
        Init();
        GridSingleton.getRef().map[currTileX][currTileY] = this;
        if (setFireOnStart)
        {
            SetOnFire();
            Debug.Log("Onfire");
        }
    }

    public void Update()
    {
        if (cState == STATE.BURNING && ((Time.time > GridSingleton.getRef().nextUpdateTime) || (Time.time + GridSingleton.getRef().updateDelayTime == GridSingleton.getRef().nextUpdateTime)))
        {
            GridSingleton.getRef().nextUpdateTime = Time.time + GridSingleton.getRef().updateDelayTime;
            CheckTileDestroy(CurrentBurnStrength);
            SpreadFire(CurrentBurnStrength);
            UpdateFireStatus();
        }
    }

}