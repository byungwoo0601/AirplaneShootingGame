using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyNomal : MonoBehaviour
{

    GameObject sceneChane;
    public float MaxHp = 10;
    public float CurHp = 10;

    bool attacked = true;

    public GameObject attack;

    [SerializeField] List<GameObject> atkPlaceArr;

    public AudioClip audioDie;
    public AudioClip audioBossDie;

    static AudioSource audioSource;

    private void Start()
    {
        sceneChane = GameObject.Find("SceneChane");
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
    }
    private void Update()
    {
        if (attacked == true)
        {
            attacked = false;
            StartCoroutine(Attack());
        }
    }
    public void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
    public void MonsterDie()
    {
        if(CurHp <= 0)
        {
            PlaySound(audioDie);
            CreateMonster.count++;
            Destroy(this.gameObject);
        }
    }

    public void MonAttack()
    {
        for (int i = 0; i < atkPlaceArr.Count; i++)
        {
            GameObject monAttack = Instantiate(attack, atkPlaceArr[i].transform.position, atkPlaceArr[i].transform.rotation);

            monAttack.GetComponent<Rigidbody2D>().AddForce(atkPlaceArr[i].transform.up * 3, ForceMode2D.Impulse);
            Destroy(monAttack, 8f);

        }
    }
    IEnumerator Attack()
    {
        MonAttack();
        yield return new WaitForSeconds(1.5f);
        attacked = true;
    }

    IEnumerator Damaged()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            StartCoroutine(Damaged());
           
        }
    }

    public void BossDie()
    {
        PlaySound(audioBossDie);
        CreateMonster.count++;

        Destroy(this.gameObject);

        sceneChane.GetComponent<SceneChane>().count -= 1;
    }
}



