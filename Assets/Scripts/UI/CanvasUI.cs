using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private TextMeshProUGUI currentBulletsText;


    [SerializeField] private PlayerPointsSystem playerPointsSystem;

    [SerializeField] private PlayerShoot playerShoot;


    [Header("Prefabs references")]
    [SerializeField] private GameObject perObjectTextPrebaf;
    [SerializeField] private GameObject perAntTextPrebaf;
    [SerializeField] private GameObject perAnthillTextPrebaf;

    public void UpdateUIText()
    {
        pointsText.text = "Points: " + playerPointsSystem.GetCurrentPoints();

        currentBulletsText.text = "Bullets: " + playerShoot.GetCurrentBullets();
    }

    public void SpawnPerObjectText()
    {
        GameObject gameObject = Instantiate(perObjectTextPrebaf);

        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + playerPointsSystem.GetPointsPerObject();

        StartCoroutine(DestroyPerObjectText(gameObject));
    }

    private IEnumerator DestroyPerObjectText(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);

        playerPointsSystem.AddPoints(playerPointsSystem.GetPointsPerObject());
        Destroy(gameObject);
    }




    public void SpawnPerAntText()
    {
        GameObject gameObject = Instantiate(perAntTextPrebaf);

        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + playerPointsSystem.GetPointsPerAnt();

        StartCoroutine(DestroyPerAntText(gameObject));
    }

    private IEnumerator DestroyPerAntText(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);

        playerPointsSystem.AddPoints(playerPointsSystem.GetPointsPerAnt());
        Destroy(gameObject);
    }





    public void SpawnPerAnthillText()
    {
        GameObject gameObject = Instantiate(perAnthillTextPrebaf);

        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "+ " + playerPointsSystem.GetPointsPerAnthill();


        StartCoroutine(DestroyPerAnthillText(gameObject));
    }

    private IEnumerator DestroyPerAnthillText(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);

        playerPointsSystem.AddPoints(playerPointsSystem.GetPointsPerAnthill());
        Destroy(gameObject);
    }
}
