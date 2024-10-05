using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Player references")]
    [SerializeField] private WeaponSO[] weapon;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Transform gunTransform;

    private float nextTimeToFire = 0;

    public void ShootLogic() 
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f/weapon[0].GetFireRate();
            Shoot();
        } 
    }

    public void Shoot() 
    {
        Cursor.lockState = CursorLockMode.Locked;

        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weapon[0].GetRange())) 
        {
            Debug.Log(hit.transform.name);
        }
    }
}
