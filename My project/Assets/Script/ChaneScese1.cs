using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaneScese1 : MonoBehaviour
{
    // Start is called before the first frame update
    int count;


    void Start()
    {
        count = PlayerPrefs.GetInt("count", count);

        if(count == 1)
        {
            count = 2;
            Invoke("Change", 1.4f);
            PlayerPrefs.SetInt("count", count);
        }
        else if(count == 2)
        {
            Change1();
        }
    }

    public void Change()
    {
        SceneManager.LoadScene("Game2");
    }
    public void Change1()
    {
        SceneManager.LoadScene("bbung");
    }
}
