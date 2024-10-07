using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointsSystem : MonoBehaviour
{
    [SerializeField] private int currentPoints;

    [SerializeField] private int pointsPerAnt;
    [SerializeField] private int pointsPerObject;
    [SerializeField] private int pointsPerAnthill;

    public void SetCurrentPoints(int number) 
    {
        currentPoints = number;
    }

    public int GetCurrentPoints() 
    {
        return currentPoints;
    }

    public void AddPoints(int number) 
    {
        currentPoints += number;
    }

    public void RemovePoints(int number) 
    {
        currentPoints -= number;
    }

    public int GetPointsPerAnt() 
    {
        return pointsPerAnt;
    }

    public int GetPointsPerObject() 
    {
        return pointsPerObject;
    }

    public int GetPointsPerAnthill() 
    {
        return pointsPerAnthill;
    }

}