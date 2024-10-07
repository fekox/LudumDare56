using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class ChangePlayerWeapon : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> AllWeapons;

    [SerializeField] private List<GameObject> AllWeaponsGO;

    [SerializeField] private int currentWeaponID = 0;

    private int currentWeaponIndex;

    private List<bool> weaponStock;
    private List<int> weaponIDList;

    public void Start()
    {
        currentWeaponIndex = 0;
        weaponStock = new List<bool>();
        weaponIDList = new List<int>();

        for (int i = 0; i < AllWeapons.Count; i++)
        {
            weaponStock.Add(false);
            weaponIDList.Add(0);
        }
        weaponStock[0] = true;
        
    }

    public void Update()
    {
        //Get Input From The Mouse Wheel
        // if mouse wheel gives a positive value add 1 to WeaponNumber
        // if it gives a negative value decrease WeaponNumber with 1
   
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                for (int i = 0; i < AllWeapons.Count; i++)
                {
                    int numberToChange=(currentWeaponIndex+i+1)%(AllWeapons.Count);

                    if (weaponStock[numberToChange] ==true)
                    {
                        currentWeaponIndex = numberToChange;
                        ChangeWeapon();
                        break;
                    }
               
                }

        }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                for (int i = 0; i < AllWeapons.Count; i++)
                {
                    int numberToChange = (AllWeapons.Count*2+currentWeaponIndex - i-1) % (AllWeapons.Count);


                if (weaponStock[numberToChange] == true)
                    {
                        currentWeaponIndex = numberToChange;
                        ChangeWeapon();
                        break;
                    }

                }

        }


        
    }

    public void ChangeWeapon() 
    {
        for (int i = 0; i < AllWeaponsGO.Count; i++)
        {
            if (AllWeaponsGO[i].GetComponent<Renderer>() != null)
            {
                AllWeaponsGO[i].GetComponent<Renderer>().enabled = false;
            }

            for (int j = 0; j < AllWeaponsGO[i].transform.childCount; j++)
            {

                AllWeaponsGO[i].transform.GetChild(j).gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        SetWeaponID(weaponIDList[currentWeaponIndex]);


        if (AllWeaponsGO[currentWeaponIndex].GetComponent<Renderer>()!=null)
        {
            AllWeaponsGO[currentWeaponIndex].GetComponent<Renderer>().enabled = true;
        }

        for (int j = 0; j < AllWeaponsGO[currentWeaponIndex].transform.childCount; j++)
        {

            AllWeaponsGO[currentWeaponIndex].transform.GetChild(j).gameObject.GetComponent<Renderer>().enabled = true;

        }

    }

    public void CheckWeapon(WeaponSO weapon)
    {
        for (int i = 0; i < AllWeaponsGO.Count; i++)
        {
            if (AllWeaponsGO[i].GetComponent<Renderer>() != null)
            {
                AllWeaponsGO[i].GetComponent<Renderer>().enabled = false;
            }

            for (int j = 0; j < AllWeaponsGO[i].transform.childCount; j++)
            {

                AllWeaponsGO[i].transform.GetChild(j).gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        for (int i = 0; i < AllWeapons.Count; i++)
        {
            if (AllWeapons[i].GetWeaponType() == weapon.GetWeaponType())
            {
                weaponStock[i] = true;
                weaponIDList[i] = weapon.GetID();
                SetWeaponID(weapon.GetID());
                AllWeaponsGO[i].SetActive(true);

                if (AllWeaponsGO[i].GetComponent<Renderer>() != null)
                {
                    AllWeaponsGO[i].GetComponent<Renderer>().enabled = true;
                }

                for (int j = 0; j < AllWeaponsGO[i].transform.childCount; j++)
                {

                    AllWeaponsGO[i].transform.GetChild(j).gameObject.GetComponent<Renderer>().enabled = true;  
                }
                

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
