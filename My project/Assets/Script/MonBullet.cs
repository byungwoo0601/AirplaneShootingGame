using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonBullet : MonoBehaviour
{

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asdasd");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¥Í¿”");
            Destroy(player);
        }
    }
}
