using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerLook playerLook;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerShoot playerShoot;

    void Update()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();
        playerShoot.ShootLogic();
    }
}
