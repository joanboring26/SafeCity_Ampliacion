using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { BURNING, INTACT, DESTROYED}

public class BaseTile : MonoBehaviour
{
    public STATE cState;

    int currTileX;
    int currTileY;


    public bool isBurnable = false;
    public bool isBeingEvacuated;

    public float BuildingStrengthRemaining;
    public float BuildingLifeRemaining;
    public float BuildingStrength;
    public float BuildingLife;
    
    public float DifficultyEntry;
    public float DifficultyExit;

    public virtual void Init()
    {
        BuildingLifeRemaining = BuildingLife;
        BuildingStrengthRemaining = BuildingStrength;
        cState = STATE.INTACT;
        isBeingEvacuated = false;
    }

    public virtual void CheckTileCatchFire(float burnStrength)
    {
        if (isBurnable)
        {
            if (BuildingStrengthRemaining >= 0)
            {
                BuildingStrengthRemaining -= burnStrength;
            }
            else
            {
                SetOnFire();
            }
        }
    }

    public virtual void SetOnFire()
    {
        cState = STATE.BURNING;

    }

    public virtual void CheckBuildingDestroy(float burnStrength)
    {
        //Tile is burning here, do checks to spread fire too

    }




    //Definir metodos de interacción
}
