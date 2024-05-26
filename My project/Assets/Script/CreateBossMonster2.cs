using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBossMonster2 : MonoBehaviour
{
    public GameObject monster;
    GameObject mon1;
    GameObject mon2;
    bool Created = true;
    Transform bossTransform1;
    Transform bossTransform2;

    private void Update()
    {
        if (Created == true)
        {
            Created = false;
            CreateMon();
        }
    }
    public void CreateMon()
    {
        bossTransform1 = GameObject.Find("enemy_Boss_Tans1").transform;
        mon1 = Instantiate(monster, bossTransform1.position, Quaternion.identity);

        bossTransform2 = GameObject.Find("enemy_Boss_Tans2").transform;
        mon2 = Instantiate(monster, bossTransform2.position, Quaternion.identity);

    }

    IEnumerator Monster()
    {
        mon1.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 1, ForceMode2D.Impulse);
        mon2.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 1, ForceMode2D.Impulse);

        yield return new WaitForSeconds(2f);
        Created = true;

    }
}
