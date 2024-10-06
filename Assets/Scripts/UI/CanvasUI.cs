using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private PlayerPointsSystem playerPointsSystem;

    [Header("Text references")]
    [SerializeField] private TextMeshProUGUI pointsPerObjectText;

    [SerializeField] private TextMeshProUGUI pointsPerAntText;

    [SerializeField] private TextMeshProUGUI pointsPerAnthillText;

    [Header("Prefabs references")]
    [SerializeField] private GameObject perObjectTextPrebaf;
    [SerializeField] private GameObject perAntTextPrebaf;
    [SerializeField] private GameObject perAnthillTextPrebaf;

    public void UpdatePointText()
    {
        pointsText.text = "Points: " + playerPointsSystem.GetCurrentPoints();

        pointsPerObjectText.text = "+ " + playerPointsSystem.GetPointsPerObject();
        
        pointsPerAntText.text = "+ " + playerPointsSystem.GetPointsPerAnt();

        pointsPerAnthillText.text = "+ " + playerPointsSystem.GetPointsPerObject();
    }

    public void SpawnPerObjectText()
    {
        GameObject gameObject = Instantiate(perObjectTextPrebaf);

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

        StartCoroutine(DestroyPerAnthillText(gameObject));
    }

    private IEnumerator DestroyPerAnthillText(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);

        playerPointsSystem.AddPoints(playerPointsSystem.GetPointsPerAnthill());
        Destroy(gameObject);
    }
}
