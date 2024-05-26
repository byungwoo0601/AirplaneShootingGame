using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petAttackManager : MonoBehaviour
{
    CreatePet createPet;
    private void Start()
    {
        createPet = GameObject.Find("Player").GetComponent<CreatePet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.GetComponent<EnemyNomal>().CurHp =- createPet.damege;

            if(collision.GetComponent<EnemyNomal>().CurHp <= 0)
            {
                collision.GetComponent<EnemyNomal>().CurHp = 0;
                collision.GetComponent<EnemyNomal>().MonsterDie();
            }
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<EnemyNomal>().CurHp = -createPet.damege;

            if (collision.GetComponent<EnemyNomal>().CurHp <= 0)
            {
                collision.GetComponent<EnemyNomal>().CurHp = 0;
                collision.GetComponent<EnemyNomal>().MonsterDie();
                collision.GetComponent<EnemyNomal>().BossDie();
            }
        }
    }
}
