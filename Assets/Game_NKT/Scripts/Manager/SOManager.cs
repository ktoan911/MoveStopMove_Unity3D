using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SOManager : Singleton<SOManager>
{
    public List<WeaponSO> weaponS0 = new List<WeaponSO>();

    public List<SkinPantsSO> skinPantsS0 = new List<SkinPantsSO>();

    public List<SkinHatSO> skinHairS0 = new List<SkinHatSO>();

    public List<SkinShieldSO> skinShieldS0 = new List<SkinShieldSO>();

}
