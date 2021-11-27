using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { BURNING, INTACT, DESTROYED}

public class BaseTile : MonoBehaviour
{
    public STATE cState;

    public int currTileX;
    public int currTileY;

    public bool isInit = false;
    public bool isBurnable = false;
    public bool isBeingEvacuated = false;

    public float TileStrengthRemaining;
    public float TileLifeRemaining;
    public float TileStrength;
    public float TileLife;
    
    public float DifficultyEntry;
    public float DifficultyExit;

    public virtual void Init()
    {
        isInit = true;
        if (transform != null)
        {
            Vector2 posVec = GridSingleton.getRef().GiveGridPos(transform.position);
            currTileX = (int)posVec.x;
            currTileY = (int)posVec.y;
            //transform.position
        }
        TileLifeRemaining = TileLife;
        TileStrengthRemaining = TileStrength;
        cState = STATE.INTACT;
        isBeingEvacuated = false;
    }

    public virtual void CheckTileCatchFire(float burnStrength)
    {
        if (isBurnable)
        {
            if (TileStrengthRemaining >= 0)
            {
                TileStrengthRemaining -= burnStrength;
            }
            else
            {
                SetOnFire();
            }
        }
    }

    public virtual void SpreadFire(float fireStrength)
    {
        BaseTile cTile;
        for (int y = -1; y < 2; y++)
        {
            if(currTileY + y >= 0 && currTileY + y < GridSingleton.gridManager.sizeY)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (currTileX + x >= 0 && currTileX + x < GridSingleton.gridManager.sizeX)
                    {
                        cTile = GridSingleton.getRef().map[currTileX + x][currTileY + y];
                        if (cTile.isInit)
                        {
                            cTile.CheckTileCatchFire(fireStrength);
                        }
                    }
                }
            }
        }
    }

    public virtual void SetOnFire()
    {
        cState = STATE.BURNING;
    }

    public virtual void CheckTileDestroy(float burnStrength)
    {
        //Tile is burning here, do checks to spread fire too

    }




    //Definir metodos de interacción
}
