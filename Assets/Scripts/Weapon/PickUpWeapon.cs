using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private WeaponSO weapon;

    [SerializeField] private ChangePlayerWeapon playerWeapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerWeapon.CheckWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
