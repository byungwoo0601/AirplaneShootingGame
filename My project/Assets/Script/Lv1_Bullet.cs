using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1_Bullet : MonoBehaviour
{
    PlayerScript playerScript;
    EnemyNomal enemyNomal;
    EnemyNomal enemyBoss;

    public float Lv1_damage;
    
    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();

        Lv1_damage = playerScript.playerDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            enemyNomal = collision.GetComponent<EnemyNomal>();
            enemyNomal.CurHp -= Lv1_damage;

            if(enemyNomal.CurHp <= 0)
            {
                enemyNomal.CurHp = 0;
                enemyNomal.MonsterDie();
                
            }
            Destroy(this.gameObject);

        }
        else if (collision.CompareTag("Boss"))
        {
            enemyBoss = collision.GetComponent<EnemyNomal>();
            enemyBoss.CurHp -= Lv1_damage;

            if (enemyBoss.CurHp <= 0)
            {
                enemyBoss.CurHp = 0;
                enemyBoss.BossDie();


            }
            Destroy(this.gameObject);
        }
    }
}
