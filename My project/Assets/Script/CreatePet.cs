using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CreatePet : MonoBehaviour
{
    //[SerializeField] List<GameObject> pet;

    public GameObject Pet1;

    public GameObject Pet2;

    public int num = 0;
    public int damege = 5;
    public int cooldown = 0;
    public int result_cooldown = 10;

    public float moveSpeed = 100.0f;

    public void PetCreate()
    {
        if (Pet1.gameObject.activeSelf == false)
        {
            Pet1.SetActive(true);
        }
        else if (Pet1.gameObject.activeSelf == true)
        {
            Pet2.SetActive(true);
        }

    }
}

