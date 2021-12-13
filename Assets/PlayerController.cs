using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Skill { SMALLFIRE, BIGFIRE, EXPLOSION }

public class PlayerController : MonoBehaviour
{

    public Skill EquipedSkill;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 10000.0f);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.transform.GetComponent<BaseTile>())
                {
                    BaseTile clicked = hit.transform.GetComponent<BaseTile>();

                    switch (EquipedSkill)
                    {
                        case Skill.SMALLFIRE:
                            smallFire(clicked);
                            break;

                        case Skill.BIGFIRE:
                            bigFire(clicked);
                            break;

                        case Skill.EXPLOSION:
                            Explosion(clicked);
                            break;

                    }


                }
            }
        }
    }


    public void smallFire(BaseTile selected)
    {
        if (selected.cType == TileType.GRASS) selected.SetOnFire();
    }

    public void bigFire(BaseTile selected)
    {
        if (selected.cType == TileType.GRASS)
        {
            selected.SetOnFire();

            if (GridSingleton.getRef().map[selected.currTileX + 1][selected.currTileY].cType == TileType.GRASS &&
               selected.currTileX + 1 < GridSingleton.getRef().sizeX)
                GridSingleton.getRef().map[selected.currTileX + 1][selected.currTileY].SetOnFire();

            if (GridSingleton.getRef().map[selected.currTileX - 1][selected.currTileY].cType == TileType.GRASS &&
              selected.currTileX - 1 > 0)
                GridSingleton.getRef().map[selected.currTileX - 1][selected.currTileY].SetOnFire();

            if (GridSingleton.getRef().map[selected.currTileX][selected.currTileY + 1].cType == TileType.GRASS &&
               selected.currTileY + 1 < GridSingleton.getRef().sizeY)
                GridSingleton.getRef().map[selected.currTileX][selected.currTileY + 1].SetOnFire();

            if (GridSingleton.getRef().map[selected.currTileX][selected.currTileY - 1].cType == TileType.GRASS &&
              selected.currTileY - 1 > 0)
                GridSingleton.getRef().map[selected.currTileX][selected.currTileY - 1].SetOnFire();
        }

    }

    public void Explosion(BaseTile selected)
    {
        if (selected.cType == TileType.BUILDING)
        {
            selected.SetOnFire();
        }
    }
}
