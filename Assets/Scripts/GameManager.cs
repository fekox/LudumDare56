using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private PlayerLook playerLook;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerCrouch playerCrouch;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private PlayerPointsSystem playerPointsSystem;

    [SerializeField] private PlayerVoice playerVoice;
 
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

    [Header("Setup Dificult")]
    [SerializeField] private int pointToIncreaseDificult;

    [SerializeField] private spawnerGenerator spawnGenerator;
    
    [SerializeField] private SpawnLimiter spawnLimiter;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    private bool isLivingActive;
    private bool isBathroomActive;
    private bool isKitchenActive;

    private spawnerGenerator respawnerGenerator;

    public bool isPaused;


    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        respawnerGenerator = GameObject.FindGameObjectWithTag("respawnerGenerator").GetComponent<spawnerGenerator>();
    }

    void Update()
    {
        PauseLogic();
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

        canvasUI.UpdateUIText();

        playerVoice.PlayerVoiceLogic();

        CheckKitchen();
        CheckBathroom();
        CheckLiving();

        IncreaseDificult();
        
    }
    
    public void PauseLogic() 
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    private void ActiveKitchen() 
    {
        rooms[1].SetActive(true);

        foreach (Transform child in rooms[1].transform)
        {
            if (child.tag == "respawnLocation")
            {
                respawnerGenerator.AddNewSpawner(child.gameObject);
            }
        }

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

        foreach (Transform child in rooms[2].transform)
        {
            if (child.tag == "respawnLocation")
            {
                respawnerGenerator.AddNewSpawner(child.gameObject);
            }
        }

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

        foreach (Transform child in rooms[3].transform)
        {
            if (child.tag == "respawnLocation")
            {
                respawnerGenerator.AddNewSpawner(child.gameObject);
            }
        }

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

    private void IncreaseDificult() 
    {
        if (playerPointsSystem.GetCurrentPoints() >= pointToIncreaseDificult)
        {
            pointToIncreaseDificult *= 2;
            spawnGenerator.DecreaseTimeUntilSameSpotRespawn(1);

            spawnGenerator.DecreaseIntervalSpawn(3);

            spawnLimiter.IncreaseSpawnLimit(10);

            CheckLimit();
        }
    }

    private void CheckLimit() 
    {
        if (spawnGenerator.GetTimeUntilSameSpotRespawn() <= 15) 
        {
            spawnGenerator.SetTimeUntilSameSpotRespawn(15);
        }

        if (spawnGenerator.GetIntervalSpawn() <= 7)
        {
            spawnGenerator.SetIntervalSpawn(7);
        }

        if (spawnLimiter.GetSpawnLimit() >= 126)
        {
            spawnLimiter.SetSpawnLimit(126);
        }
    }

    public void Resume() 
    {
        isPaused = false;
    }

    public void ReturnMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
