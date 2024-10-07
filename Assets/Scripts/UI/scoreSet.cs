using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetFloat("Player Score").ToString();
    }


}
