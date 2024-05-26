using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChane : MonoBehaviour
{
    public int count;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
            Invoke("Chane", 1f);
    }


    public void Chane()
    {
        SceneManager.LoadScene(nextSceneName);

    }
}

