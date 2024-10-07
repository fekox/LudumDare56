using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoice : MonoBehaviour
{
    [SerializeField] private float timer;

    private float maxTimer;

    private void Start()
    {
        maxTimer = timer;
    }

    public void PlayerVoiceLogic()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = maxTimer;

            int value = Random.Range(0, 2);

            switch (value)
            {
                case 0:
                    FindAnyObjectByType<AudioManager>().Play("Voice1");
                    break;

                case 1:
                    FindAnyObjectByType<AudioManager>().Play("Voice2");
                    break;

                default:
                    break;
            }
        }
    }
}
