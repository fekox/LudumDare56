using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Player references")]
    [SerializeField] private WeaponSO weapon;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Transform gunTransform;

    [SerializeField] private PlayerPointsSystem playerPointsSystem;

    [Header("Weapon setup")]

    [SerializeField] private int currentBullets = 0;

    [SerializeField] private int weaponID;

    [Header("Animation reference")]
    [SerializeField] private Animator reloadAnimator;

    [Header("CanvasUI reference")]
    [SerializeField] private CanvasUI canvasUI;

    private int maxBullets = 0;

    private float nextTimeToFire = 0;

    private float reloadingTime;

    private float maxReloadingTime;

    private bool isReloading = false;
    private bool isShoting = false;

    private void Start()
    {
        maxReloadingTime = weapon.GetReloadingTime();
        reloadingTime = maxReloadingTime;

        maxBullets = weapon.GetMaxBullets();
        currentBullets = maxBullets;
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
            reloadAnimator.SetBool("IsRecoil", isShoting);
        }
    }

    public void Shoot() 
    {
        isShoting = true;

        currentBullets--;

        reloadAnimator.SetBool("IsRecoil", isShoting);

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weapon.GetRange())) 
        {
            Debug.Log(hit.transform.name);

            ObjectsHealthSystem objectGO = hit.transform.GetComponent<ObjectsHealthSystem>();
            
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

            Spawner spawner = hit.transform.GetComponent<Spawner>();

            if (objectGO != null) 
            {
                canvasUI.SpawnPerObjectText();
                objectGO.TakeDamage(weapon.GetDamage());
            }

            if (spawner != null)
            {
                spawner.TakeDamage(weapon.GetDamage());
            }

            if (enemy != null)
            {
                canvasUI.SpawnPerAntText();
                enemy.Die();
            }

            if(hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(-hit.normal * weapon.GetImpactForce());
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
}
