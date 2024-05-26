using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject monster;

    public static int count = 0;

    bool Created = true;


    private void Update()
    {
        if (Created == true)
        {
            Created = false;
            StartCoroutine(Monster());
        }
    }
    public void CreateMon()
    {
        GameObject mon = Instantiate(monster, this.transform.position, Quaternion.identity);
        mon.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 2, ForceMode2D.Impulse);

        Destroy(mon, 6f);
    }


    IEnumerator Monster()
    {
        CreateMon();
        yield return new WaitForSeconds(2f);
        Created = true;

    }
}
