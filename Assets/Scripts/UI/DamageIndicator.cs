using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private Vector3 damageLocation;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform damageImact;

    [SerializeField] private CanvasGroup damageImpactCanvas;
    [SerializeField] private float startFadeTime;
    [SerializeField] private float fadeTime;

    private float maxFadeTime;

    private void Start()
    {
        maxFadeTime = fadeTime;
    }

    private void Update() 
    {
        if(startFadeTime > 0) 
        {
            startFadeTime -= Time.deltaTime;
        }

        else 
        {
            fadeTime -= Time.deltaTime;
            damageImpactCanvas.alpha = fadeTime / maxFadeTime;

            if (fadeTime <= 0) 
            {
                Destroy(gameObject);
            }
        }

        damageLocation.y = playerTransform.position.y;
        Vector3 direction = (damageLocation - playerTransform.position).normalized;
        float angle = Vector3.SignedAngle(direction, playerTransform.forward, Vector3.up);
        damageImact.transform.localEulerAngles = new Vector3(0,0, angle);
    }

    public void SetDamageLocation(Vector3 damage) 
    {
        damageLocation = damage;
    }
}
