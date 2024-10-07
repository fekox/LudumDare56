using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }


}
