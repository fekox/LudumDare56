using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerLook playerLook;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private List<PlayerShoot> playerShoot;

    [SerializeField] private PlayerCrouch playerCrouch;

    [SerializeField] private ChangePlayerWeapon changePlayerWeapon;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();

        playerShoot[changePlayerWeapon.GetWeaponID()].ShootLogic();
        playerShoot[changePlayerWeapon.GetWeaponID()].ReloadLogic();

        playerCrouch.CrouchLogic();
    }
}
