using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassMusic : MonoBehaviour
{
   private void Start()
    {    
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1f)
        {
            Destroy(this.gameObject);
            
        }
        else //
        {
            if (SceneManager.GetActiveScene().buildIndex > 2)
            {
                Destroy(this.gameObject);
                
            }
            else if (SceneManager.GetActiveScene().buildIndex < 3)
            {
                DontDestroyOnLoad(this.gameObject);
                
            }
        }
    }
    private void Update()
    {
        
        if (SceneManager.GetActiveScene().buildIndex>2)
        {
            Destroy(this.gameObject);
        }

    }
}
