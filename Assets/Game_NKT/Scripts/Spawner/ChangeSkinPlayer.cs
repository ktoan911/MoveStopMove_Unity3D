using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinPlayer : Singleton<ChangeSkinPlayer>
{
    private SkinPantsSO GetPantByID(int id)
    {
        for(int i = 0;   i  <SOManager.Ins.skinPantsS0.Count; i++)
        {
            if (SOManager.Ins.skinPantsS0[i].IDSkin == id) return SOManager.Ins.skinPantsS0[i];
        }

        return SOManager.Ins.skinPantsS0[0];
    }

    private SkinHatSO GetHairByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.skinHairS0.Count; i++)
        {
            if (SOManager.Ins.skinHairS0[i].IDSkin == id) return SOManager.Ins.skinHairS0[i];
        }

        return SOManager.Ins.skinHairS0[0];
    }

    private SkinShieldSO GetShieldByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.skinShieldS0.Count; i++)
        {
            if (SOManager.Ins.skinShieldS0[i].IDSkin == id) return SOManager.Ins.skinShieldS0[i];
        }

        return SOManager.Ins.skinShieldS0[0];
    }

    public void ChangePant(SkinnedMeshRenderer skin, int id)
    {
        skin.material = this.GetPantByID(id).skinPantPrefab;
    }

    public void ChangeHair(Transform posChange, int id)
    {
       
    }
}
