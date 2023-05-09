using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponImage : Singleton<WeaponImage>
{
    private Weapon currentWeapon;

    public int currentID;

    [SerializeField]private Transform spawnPos;

    private void Start()
    {
        currentID = 0;
    }

    public void ChangeWeapon(bool RightLeft)
    {
        if(currentWeapon!= null)
        {
            Destroy(this.currentWeapon);
        }

        for (int i = 0; i < SOManager.Ins.weaponS0.Count; i++)
        {
            if (SOManager.Ins.weaponS0[i].IDWeapon == ChangeWeaponID(RightLeft))
            {
                currentWeapon = Instantiate(SOManager.Ins.weaponS0[i].weaponPrefab,spawnPos.position, Quaternion.identity); 
            }
        }
    }

    public int ChangeWeaponID(bool RightLeft)
    {
        if (RightLeft) currentID++;

        else currentID--;


        if (currentID > SOManager.Ins.weaponS0.Count) currentID = 1;

        else if (currentID < 1) currentID = SOManager.Ins.weaponS0.Count;

        return currentID;
    }


}
