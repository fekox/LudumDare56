using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextSpawnPosition : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    public int maxXPosition;
    public int minXPosition;

    private void OnEnable()
    {
        rectTransform.anchoredPosition = new Vector2(Random.Range(minXPosition, maxXPosition), 0);
    }
}
