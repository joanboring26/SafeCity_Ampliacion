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
    public GameObject t1, t2, t3;

    private void Start()
    {
        Player = GameObject.Find("Main Camera").GetComponent<PlayerController>();
        timer1 = cooldown1;
        timer2 = cooldown2;
        timer3 = cooldown3;
    }

    public void FixedUpdate()
    {
        if (t1.GetComponent<Text>().text == "0") t1.GetComponent<Text>().text = "";
        if (t2.GetComponent<Text>().text == "0") t2.GetComponent<Text>().text = "";
        if (t3.GetComponent<Text>().text == "0") t3.GetComponent<Text>().text = "";

        if (timer1 >= cooldown1)
            can1 = true;
        else
        {
            can1 = false;
            timer1 += Time.fixedDeltaTime;
            t1.GetComponent<Text>().text = ((int)cooldown1-(int)timer1).ToString();
        }
        if (timer2 >= cooldown2)
            can2 = true;
        else
        {
            can2 = false;
            timer2 += Time.fixedDeltaTime;
            t2.GetComponent<Text>().text = ((int)cooldown2 - (int)timer2).ToString();
        }
        if (timer3 >= cooldown3)
            can3 = true;
        else
        {
            can3 = false;
            timer3 += Time.fixedDeltaTime;
            t3.GetComponent<Text>().text = ((int)cooldown3 - (int)timer3).ToString();
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
            Player.EquipedSkill = Skill.SMALLFIRE;
        }
    }
    public void equipBigFire()
    {
        if (can2)
        {
            Player.EquipedSkill = Skill.BIGFIRE;
        }
    }

    public void equipExplosion()
    {
        if (can3)
        {
            Player.EquipedSkill = Skill.EXPLOSION;
        }
    }
}
