using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PetAttack : MonoBehaviour
{
    public GameObject putBullet;
    CreatePet CreatePet;

    bool attacked = true;

    private void Start()
    {
        CreatePet = GameObject.Find("Player").GetComponent<CreatePet>();
    }
    private void Update()
    {
        if (attacked == true)
        {
            attacked = false;
            StartCoroutine(Attack());

        }
    }
    public void PlayerAttack()
    {

            GameObject Attack = Instantiate(putBullet, this.transform.position, this.transform.rotation);

            Attack.GetComponent<Rigidbody2D>().AddForce(this.transform.up * 10, ForceMode2D.Impulse);
            Destroy(Attack, 4f);
        
    }

    IEnumerator Attack()
    {
        PlayerAttack();
        yield return new WaitForSeconds(CreatePet.result_cooldown-CreatePet.cooldown);
        attacked = true;
    }
}
