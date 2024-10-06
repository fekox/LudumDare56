using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
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

    [Header("Spawn points")]
    [SerializeField] private List<GameObject> rooms;

    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject door3;
    [SerializeField] private GameObject door4;
    [SerializeField] private GameObject door5;

    private bool isLivingActive;
    private bool isBathroomActive;
    private bool isKitchenActive;


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

        CheckKitchen();
        CheckBathroom();
        CheckLiving();
    }
    
    private void ActiveKitchen() 
    {
        rooms[1].SetActive(true);
        isKitchenActive = true;
    }

    private void CheckKitchen() 
    {
        if (!isKitchenActive) 
        {
            if (door3.IsDestroyed() || door4.IsDestroyed() || door5.IsDestroyed())
            {
                ActiveKitchen();
            }
        }
    }

    private void ActiveBathroom() 
    {
        rooms[2].SetActive(true);
        isBathroomActive = true;
    }

    private void CheckBathroom() 
    {
        if (!isBathroomActive)
        {
            if (door2.IsDestroyed() || door5.IsDestroyed())
            {
                ActiveBathroom();
            }
        }
    }

    private void ActiveLivingroom() 
    {
        rooms[3].SetActive(true);
        isLivingActive = true;
    }

    private void CheckLiving()
    {
        if (!isLivingActive)
        {
            if (door1.IsDestroyed() || door2.IsDestroyed() || door3.IsDestroyed())
            {
                ActiveLivingroom();
            }
        }
    }
}
