using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayButton() 
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CreditsButton() 
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitButton() 
    {
        Application.Quit();
    }
}
