using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerLook playerLook;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerCrouch playerCrouch;

    [SerializeField] private PlayerHealth playerHealth;

    [Header("Weapons references")]

    [SerializeField] private ChangePlayerWeapon changePlayerWeapon;

    [SerializeField] private List<PlayerShoot> playerShoot;

    [SerializeField] private List<PickUpWeapon> pickUpWeapon;

    [Header("Canvas references")]

    [SerializeField] private CanvasUI canvasUI;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerLook.LookLogic();
        playerMovement.MovementLogic();

        playerHealth.TakeDamageLogic();

        for (int i = 0; i < pickUpWeapon.Count; i++) 
        {
            if (pickUpWeapon[i] == null)
            {
                pickUpWeapon.Remove(pickUpWeapon[i]);
            }

            else 
            {
                pickUpWeapon[i].PickUpLogic();
            }
        }

        playerShoot[changePlayerWeapon.GetWeaponID()].ShootLogic();
        playerShoot[changePlayerWeapon.GetWeaponID()].ReloadLogic();

        playerCrouch.CrouchLogic();

        canvasUI.UpdatePointText();
    }
}
