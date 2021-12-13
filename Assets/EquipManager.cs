using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public PlayerController Player;

    private void Start()
    {
       Player = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    public void equipSmallFire()
    {
        Player.EquipedSkill = Skill.SMALLFIRE;
    }

    public void equipBigFire()
    {
        Player.EquipedSkill = Skill.BIGFIRE;
    }

    public void equipExplosion()
    {
        Player.EquipedSkill = Skill.EXPLOSION;
    }
}
