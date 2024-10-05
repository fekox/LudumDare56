using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Player references")]
    [SerializeField] private WeaponSO[] weapon;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Transform gunTransform;

    [SerializeField] private int currentBullets = 0;

    private int maxBullets = 0;

    private float nextTimeToFire = 0;

    private float reloadingTime;

    private float maxReloadingTime;

    private bool isReloading = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        maxReloadingTime = weapon[0].GetReloadingTime();
        reloadingTime = maxReloadingTime;

        maxBullets = weapon[0].GetMaxBullets();
        currentBullets = maxBullets;
    }

    public void ShootLogic() 
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !isReloading) 
        {
            nextTimeToFire = Time.time + 1f/weapon[0].GetFireRate();
            Shoot();
        } 
    }

    public void Shoot() 
    {
        currentBullets--;

        RaycastHit hit;

        Debug.Log("CurrentBullets: " + currentBullets);

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weapon[0].GetRange())) 
        {
            Debug.Log(hit.transform.name);
        }
    }

    public void ReloadLogic() 
    {
        if(currentBullets <= 0) 
        {
            isReloading = true;
        }

        if(isReloading) 
        {
            reloadingTime -= Time.deltaTime;

            Debug.Log("Reloading time: " + reloadingTime);

            if(reloadingTime <= 0) 
            {
                reloadingTime = maxReloadingTime;
                currentBullets = maxBullets;
                isReloading = false;
            }
        }
    }
}
