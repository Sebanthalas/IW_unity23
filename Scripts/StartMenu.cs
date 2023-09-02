using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
    
{
    
    [SerializeField] private AudioSource stSoundEffect;
    public void StartGame()
    {
        stSoundEffect.Play();
        Invoke("goNextLevel", 1f);
        
    }
    private void goNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
