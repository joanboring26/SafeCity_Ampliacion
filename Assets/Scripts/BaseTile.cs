using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE { BURNING, INTACT, DESTROYED}
public enum TileType { GRASS, BUILDING, ROAD}


public class BaseTile : MonoBehaviour
{
    public STATE cState;
    public TileType cType;

    public int currTileX;
    public int currTileY;

    public bool isInit = false;
    public bool isBurnable = false;
    public bool isBeingEvacuated = false;

    public float TileStrengthRemaining;
    public float TileLifeRemaining;
    public float TileStrength;
    public float TileLife;
    public float CurrentBurnStrength;
    public float TileBurnStrength;
    
    public float DifficultyEntry;
    public float DifficultyExit;

    public float TimeToFirefighters = 2;
    public float FightersPower = 1;
    public bool fireFightersON = false;
    public float FFStress = 0.1f;

    SpriteRenderer fireSpriteRef;

    GameObject fireSprite;
    GameObject waterSprite;
    public GameObject firePrefab;
    public GameObject waterPrefab;
    public GameObject destroyedVisual;
    public GameObject intactVisual;
    public SpriteRenderer buildingSpriteRef;
    public SpriteRenderer bgSpriteRef;

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
            float tileColor = 0.25f + Mathf.Clamp((TileStrengthRemaining / TileStrength), 0, 0.75f);
            buildingSpriteRef.color = new Color(tileColor, tileColor, tileColor, 1);
            if (TileStrengthRemaining >= 0)
            {
                TileStrengthRemaining -= burnStrength;
            }
            else
            {
                SetOnFire();
            }
        }
        //bgSpriteRef.color = new Color(tileColor, tileColor, tileColor, 1);
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
                    if (currTileX + x >= 0 && currTileX + x < GridSingleton.gridManager.sizeX && !fireFightersON && cState == STATE.BURNING)
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
        if (cState == STATE.INTACT)
        {
            
            cState = STATE.BURNING;
            if (fireSprite == null)
            {
                fireSprite = Instantiate(firePrefab, transform.position, transform.rotation);
                fireSpriteRef = fireSprite.GetComponentInChildren<SpriteRenderer>();
                StartCoroutine(GoFirefighters());
                GridSingleton.gridManager.fireFstrength -= FFStress;
                //Fire scaling to be fixed
                //firePrefab.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }

    public IEnumerator GoFirefighters()
    {
        yield return new WaitForSecondsRealtime(TimeToFirefighters - GridSingleton.gridManager.fireFstrength);
        fireFightersON = true;
        //FeedbackVisual
        waterSprite = Instantiate(waterPrefab, transform.position, transform.rotation);
    }

    //Update the strength of the fire
    public void UpdateFireStatus()
    {

        if (fireSprite == null)
        {
            fireSprite = Instantiate(firePrefab, transform.position, transform.rotation);
        }

        if (fireFightersON)
        {
            CurrentBurnStrength -= FightersPower + GridSingleton.gridManager.fireFstrength / 100 ;
            if(CurrentBurnStrength <= 0)
            {
                cState = STATE.INTACT;
                GridSingleton.gridManager.fireFstrength += FFStress - FFStress * 0.25f;
                fireFightersON = false;
                //Quitar feedback
                Destroy(waterSprite);
                Destroy(fireSprite.gameObject);
            }
        }
        else if(CurrentBurnStrength < TileBurnStrength)
        {
            CurrentBurnStrength += 0.15f;
        }

        if(fireSpriteRef != null)
        fireSpriteRef.color = new Color(fireSpriteRef.color.r, fireSpriteRef.color.g, fireSpriteRef.color.b, 0.25f + Mathf.Clamp((CurrentBurnStrength / TileBurnStrength), 0, 0.75f));

    }

    public virtual void CheckTileDestroy(float burnStrength)
    {
        //Tile is burning here
        TileLifeRemaining -= burnStrength;
        if(TileLifeRemaining <= 0 && cState == STATE.BURNING)
        {
            cState = STATE.DESTROYED;
            GridSingleton.gridManager.fireFstrength -= 0.005f;
            Destroy(fireSprite);
            destroyedVisual.SetActive(true);
            intactVisual.SetActive(false);
        }    
    }

    //Definir metodos de interacción
}
