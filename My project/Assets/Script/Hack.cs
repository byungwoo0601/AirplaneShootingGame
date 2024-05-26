using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    public float _fadeTime = 1.5f;
    float time = 0;

    Camera mainCamera;
    Vector3 cameraPos;

    [SerializeField][Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField][Range(0.1f, 3f)] float duration = 0.5f;


    EnemyNomal enemyNomal;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        mainCamera = Camera.main;
        Shake();

    }

    // Update is called once per frame
    void Update()
    {

        if (time < _fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }


    public void Shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x += cameraPosX;
        cameraPos.y += cameraPosY;
        mainCamera.transform.position = cameraPos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            enemyNomal = collision.GetComponent<EnemyNomal>();

            enemyNomal.CurHp -= playerScript.playerBombDamage;

            if(enemyNomal.CurHp <= 0)
            {
                enemyNomal.CurHp = 0;
                enemyNomal.MonsterDie();
            }
        }
        else if (collision.CompareTag("Boss"))
        {
            enemyNomal = collision.GetComponent<EnemyNomal>();

            enemyNomal.CurHp -= playerScript.playerBombDamage;

            if (enemyNomal.CurHp <= 0)
            {
                enemyNomal.CurHp = 0;
                enemyNomal.BossDie();
            }
        }
        else if (collision.CompareTag("MonsterBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
