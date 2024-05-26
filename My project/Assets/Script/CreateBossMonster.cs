using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class CreateBossMonster : MonoBehaviour
{
    public GameObject monster;
    GameObject mon;
    bool Created = true;
    Transform bossTransform;


    private void Update()
    {
        if (Created == true && CreateMonster.count == 5)
        {
            Created = false;
            CreateMon();
        }
    }
    public void CreateMon()
    {
        bossTransform = GameObject.Find("enemy_Boss_Tans").transform;
        mon = Instantiate(monster, bossTransform.position, Quaternion.identity);

    }

}
