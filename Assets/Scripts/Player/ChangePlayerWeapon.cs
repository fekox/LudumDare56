using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ChangePlayerWeapon : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> AllWeapons;

    [SerializeField] private List<GameObject> AllWeaponsGO;

    [SerializeField] private int currentWeaponID = 0;

    public void CheckWeapon(WeaponSO weapon) 
    {
        for (int i = 0; i < AllWeaponsGO.Count; i++)
        {
            AllWeaponsGO[i].SetActive(false);
        }

        for (int i = 0; i < AllWeapons.Count; i++) 
        {
            if (AllWeapons[i].GetWeaponType() == weapon.GetWeaponType()) 
            {
                SetWeaponID(weapon.GetID());
                AllWeaponsGO[i].SetActive(true);
            }
        }
    }

    public void SetWeaponID(int number)
    {
        currentWeaponID = number;
    }

    public int GetWeaponID() 
    {
        return currentWeaponID;
    }
}
