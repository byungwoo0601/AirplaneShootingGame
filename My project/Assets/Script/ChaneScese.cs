using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaneScese : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change", 1.4f);
    }

    public void Change()
    {
        SceneManager.LoadScene("bbung");

    }
}
