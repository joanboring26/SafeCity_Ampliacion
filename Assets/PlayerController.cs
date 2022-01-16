using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Skill { SMALLFIRE, BIGFIRE, EXPLOSION, NONE }

public class PlayerController : MonoBehaviour
{
    public float time_limit;
    public float timer;
    public int itimer;
    public bool started = false;
    public bool finished = false;

    public Skill EquipedSkill;

    public EquipManager em;
    public Text t;
    

    void FixedUpdate()
    {
        if (started)
            timer += Time.fixedDeltaTime;
        if (timer >= time_limit)
            finished = true;
        if (finished)
            started = false;
        itimer = (int) timer;
        t.text = "Timer: " + itimer.ToString();

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

                    if (!started) started = true;

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
                    em.Player.EquipedSkill = Skill.NONE;


                }
            }
        }
    }


    public void smallFire(BaseTile selected)
    {
        if (selected.cType == TileType.GRASS)
        {
            selected.SetOnFire();
            em.timer1 = 0;
        }
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

            em.timer2 = 0;
        }

    }

    public void Explosion(BaseTile selected)
    {
        if (selected.cType == TileType.BUILDING)
        {
            em.timer3 = 0;
            selected.SetOnFire();
        }
    }
}
