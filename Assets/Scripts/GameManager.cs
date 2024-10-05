using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerLook playerLook;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerShoot playerShoot;

    [SerializeField] private PlayerCrouch playerCrouch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();
        playerShoot.ShootLogic();
        playerShoot.ReloadLogic();
        playerCrouch.CrouchLogic();
    }
}
