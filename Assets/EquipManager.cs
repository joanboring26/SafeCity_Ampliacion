using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public PlayerController Player;

    public bool can1, can2, can3;

    public float cooldown1;
    public float cooldown2;
    public float cooldown3;

    public float timer1;
    public float timer2;
    public float timer3;

    public GameObject b1, b2, b3;

    private void Start()
    {
        Player = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    public void Update()
    {
        if (timer1 >= cooldown1)
            can1 = true;
        else
        {
            can1 = false;
            timer1 += Time.fixedDeltaTime;
        }
        if (timer2 >= cooldown2)
            can2 = true;
        else
        {
            can2 = false;
            timer2 += Time.fixedDeltaTime;
        }
        if (timer3 >= cooldown3)
            can3 = true;
        else
        {
            can3 = false;
            timer3 += Time.fixedDeltaTime;
        }

        if (can1)
            b1.GetComponent<Button>().enabled = true;
        else
            b1.GetComponent<Button>().enabled = false;

        if (can2)
            b2.GetComponent<Button>().enabled = true;
        else
            b2.GetComponent<Button>().enabled = false;

        if (can3)
            b3.GetComponent<Button>().enabled = true;
        else
            b3.GetComponent<Button>().enabled = false;

    }

    public void equipSmallFire()
    {
        if (can1)
        {
            timer1 = 0;
            can1 = false;
            Player.EquipedSkill = Skill.SMALLFIRE;
        }
    }
    public void equipBigFire()
    {
        if (can2)
        {
            timer2 = 0;
            can2 = false;
            Player.EquipedSkill = Skill.BIGFIRE;
        }
    }

    public void equipExplosion()
    {
        if (can3)
        {
            timer3 = 0;
            can3 = false;
            Player.EquipedSkill = Skill.EXPLOSION;
        }
    }
}
