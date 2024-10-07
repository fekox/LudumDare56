using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [Header("Weapon references")]
    [SerializeField] private WeaponSO weapon;

    [Header("Player references")]
    [SerializeField] private ChangePlayerWeapon playerWeapon;

    [SerializeField] private PlayerPointsSystem playerPoints;

    [Header("Weapon setup")]
    [SerializeField] private bool canPickup = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }

    public void PickUpLogic() 
    {
       // Debug.Log("weapon name"+ weapon+" weapon cost " + weapon.GetCost());
       // Debug.Log("can pickup "+ canPickup);
        if (canPickup && Input.GetKeyDown(KeyCode.E) 
            && weapon.GetCost() <= playerPoints.GetCurrentPoints()) 
        {
            playerWeapon.CheckWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
