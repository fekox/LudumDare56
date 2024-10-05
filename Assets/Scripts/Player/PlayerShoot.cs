using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Player references")]
    [SerializeField] private WeaponSO weapon;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Transform gunTransform;

    [SerializeField] private int currentBullets = 0;

    [Header("Animation reference")]
    [SerializeField] private Animator reloadAnimator;

    [Header("Recoil Setup")]
    [SerializeField] private float maxRecoild;

    [SerializeField] private int weaponID;

    private float minRecoild = 0;

    private int maxBullets = 0;

    private float nextTimeToFire = 0;

    private float reloadingTime;

    private float maxReloadingTime;

    private float recoil;

    private bool isReloading = false;
    private bool isShoting = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        maxReloadingTime = weapon.GetReloadingTime();
        reloadingTime = maxReloadingTime;

        maxBullets = weapon.GetMaxBullets();
        currentBullets = maxBullets;

        recoil = weapon.GetRecoil();
        maxRecoild = -recoil;
    }

    public void ShootLogic() 
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !isReloading) 
        {
            nextTimeToFire = Time.time + 1f/weapon.GetFireRate();
            Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShoting = false;
        }

        if (!isShoting) 
        {
            RemoveRecoil();
        }
    }

    public void Shoot() 
    {
        isShoting = true;

        currentBullets--;

        AddRecoil();

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weapon.GetRange())) 
        {
            Debug.Log(hit.transform.name);

            ObjectsHealthSystem objectGO = hit.transform.GetComponent<ObjectsHealthSystem>();
            
            if (objectGO != null) 
            {
                objectGO.TakeDamage(weapon.GetDamage());
            }
        }
    }

    public void ReloadLogic() 
    {
        if(currentBullets <= 0) 
        {
            isReloading = true;
            reloadAnimator.SetBool("IsReloading", isReloading);
        }

        if(isReloading) 
        {
            reloadingTime -= Time.deltaTime;

            if(reloadingTime <= 0) 
            {
                reloadingTime = maxReloadingTime;
                currentBullets = maxBullets;
                isReloading = false;
                reloadAnimator.SetBool("IsReloading", isReloading);
            }
        }
    }

    public void AddRecoil() 
    {
        float currentRotationX = transform.localEulerAngles.x;

        if (currentRotationX > 180f)
            currentRotationX -= 360f;

        if (maxRecoild <= currentRotationX)
        {
            transform.Rotate(-recoil * Time.deltaTime, 0f, 0f);
        }
    }

    public void RemoveRecoil() 
    {
        float currentRotationX = transform.localEulerAngles.x;

        if (currentRotationX > 180f)
            currentRotationX -= 360f;

        if (minRecoild >= currentRotationX)
        {
            transform.Rotate(recoil * Time.deltaTime, 0f, 0f);
        }
    }
}
