using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("ProgramingFacundo");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

}
