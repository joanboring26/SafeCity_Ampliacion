using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { FIRE, INTACT, DESTROYED}

public class BaseTile : ScriptableObject
{
    public STATE cState;

    public bool isBeingEvacuated;

    public float BuildingStrengthRemaining;
    public float BuildingStrength;
    public float DifficultyEntry;
    public float DifficultyExit;

    public virtual void CheckTileCatchFire()
    {
        
    }

    public virtual void SetOnFire()
    {

    }

    public virtual void CheckTimeDestroy()
    {

    }




    //Definir metodos de interacción
}
