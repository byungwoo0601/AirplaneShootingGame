using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerScript : MonoBehaviour
{
    public int playerDamage;
    public int playerSpray;
    public int playerBombDamage;
    public int playerBombNumber;
    public float playerGuidedMissileDamage;
    public int playerGuidedMissileNumber;
    public float playerGuidedMissileCooldown;

    public int playerShield;

    public float moveSpeed = 100f;

    [SerializeField]
    private StageData stageData;

    public GameObject PlayerIdle;
    public GameObject PlayerILeft;
    public GameObject PlayerRight;

    public GameObject lv1_bullet;
    public GameObject lv2_bullet;
    public GameObject hack;
    GameObject Hack;
    public GameObject hack_Result;

    bool attacked = true;


    float time;
    public float _fadeTime = 0.3f;

    public static PlayerScript Instans;

    [SerializeField] List<GameObject> atkPlaceArr;


    public int ScenceCount = 1;

    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        
        if(Instans != null)
        {
            Destroy(gameObject);
        }
        else if(Instans == null)
        {
            Instans = this;
        }

    }

    private void Start()
    {
        PlayerIdle.SetActive(true);
        PlayerILeft.SetActive(false);
        PlayerRight.SetActive(false);
        SetPlayerStat();
    }


    void Update()
    {
        Move();

        if (attacked == true)
        {
            attacked = false;
            StartCoroutine(Attack());

        }
        _Hack();

        
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void SetPlayerStat()
    {
        playerDamage = 2;
        playerSpray = 1;
        playerBombDamage = 100;
        playerBombNumber = 1;
        playerGuidedMissileDamage = 0f;
        playerGuidedMissileNumber = 0;
        playerGuidedMissileCooldown = 0f;
    }



    void Move()
    {
        //playerRb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * moveSpeed * Time.deltaTime;

     
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (Vector3.up * v) + (Vector3.right * h);
        gameObject.transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            PlayerIdle.SetActive(false);
            PlayerILeft.SetActive(true);
            PlayerRight.SetActive(false);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            PlayerIdle.SetActive(false);
            PlayerILeft.SetActive(false);
            PlayerRight.SetActive(true);

        }
        else
        {
            PlayerIdle.SetActive(true);
            PlayerILeft.SetActive(false);
            PlayerRight.SetActive(false);
        }
    }


    IEnumerator Attack()
    {
        PlayerAttack();
        yield return new WaitForSeconds(0.05f);
        attacked = true;
    }

    public void PlayerAttack()
    {
            for (int i = 0; i < MainUiSetting.weaponSprayUpgradeCount; i++)
            {
                GameObject Attack = Instantiate(lv1_bullet, atkPlaceArr[i].transform.position, atkPlaceArr[i].transform.rotation);

                Attack.GetComponent<Rigidbody2D>().AddForce(atkPlaceArr[i].transform.up * 25, ForceMode2D.Impulse);
                Destroy(Attack, 4f);
            }
    }

    public void _Hack()
    {
        Debug.Log("playerBombNumber : " + playerBombNumber);
        Debug.Log("MainUiSetting.BoomNumber : " + MainUiSetting.BoomNumber);
        if (Input.GetKeyDown(KeyCode.Space) && playerBombNumber >= MainUiSetting.BoomNumber)
        {
            Debug.Log("ÇÙ »ç¿ë");

            playerBombNumber--;
            Hack = Instantiate(hack, this.transform.position, Quaternion.identity);
            Hack.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse);


            Invoke("Hack_result", 0.7f);
            Destroy(Hack, 0.7f);
        }
    }
    public void Hack_result()
    {
        GameObject Hack_Result = Instantiate(hack_Result, Hack.transform.position, Quaternion.identity);
        Destroy(Hack_Result, 1.5f);

    }
    public void PlayerDie()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster") || collision.CompareTag("Boss") || collision.CompareTag("MonsterBullet"))
        {
            PlayerDie();
        }
    }


}

