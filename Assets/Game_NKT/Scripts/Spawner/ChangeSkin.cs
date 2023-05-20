using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : Singleton<ChangeSkin>
{
    private SkinPantsSO GetPantSOByID(int id)
    {
        for(int i = 0;   i  <SOManager.Ins.skinPantsS0.Count; i++)
        {
            if (SOManager.Ins.skinPantsS0[i].ID == id) return SOManager.Ins.skinPantsS0[i];
        }

        return null;
    }

    private SkinHatSO GetHairSOByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.skinHairS0.Count; i++)
        {
            if (SOManager.Ins.skinHairS0[i].ID == id) return SOManager.Ins.skinHairS0[i];
        }

        return null;
    }

    private SkinShieldSO GetShieldSOByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.skinShieldS0.Count; i++)
        {
            if (SOManager.Ins.skinShieldS0[i].ID == id) return SOManager.Ins.skinShieldS0[i];
        }

        return null;
    }

    public void ChangePant(Characters character, SkinnedMeshRenderer skin, int id)
    {
        SkinPantsSO skinPantSO = this.GetPantSOByID(id);

        if (skinPantSO == null) return;

        Skin pantModelPool = SimplePool.Spawn<Skin>(skinPantSO.skinPantPrefab, Vector3.zero, Quaternion.identity);

        pantModelPool.OnInit(character, skinPantSO.percentUpSpeed);

        skin.material = pantModelPool.pantMaterial;

    }

    public void ChangeModelHair(Transform parentSpawn, int id)
    {
        ClearPastSkin(parentSpawn);

        SkinHatSO skinHairSO = this.GetHairSOByID(id);

        if(skinHairSO == null) return;

        Vector3 localPosition = skinHairSO.skinHatPrefab.transform.localPosition;
        Quaternion localRot = skinHairSO.skinHatPrefab.transform.localRotation;

        Skin hairModelPool = SimplePool.Spawn<Skin>(skinHairSO.skinHatPrefab, Vector3.zero, Quaternion.identity);
        hairModelPool.gameObject.transform.SetParent(parentSpawn);

        hairModelPool.gameObject.transform.localPosition = localPosition;

        hairModelPool.gameObject.transform.localRotation = localRot;
    }

    public void ChangeModelShield(Transform parentSpawn, int id)
    {
        ClearPastSkin(parentSpawn);

        SkinShieldSO skinShieldSO = this.GetShieldSOByID(id);

        if(skinShieldSO == null) return;

        Vector3 localPosition = skinShieldSO.skinShieldPrefab.transform.localPosition;
        Quaternion localRot = skinShieldSO.skinShieldPrefab.transform.localRotation;

        Skin shieldModelPool = SimplePool.Spawn<Skin>(skinShieldSO.skinShieldPrefab, Vector3.zero, Quaternion.identity);
        shieldModelPool.gameObject.transform.SetParent(parentSpawn);

        shieldModelPool.gameObject.transform.localPosition = localPosition;

        shieldModelPool.gameObject.transform.localRotation = localRot;
    }

    private void ClearPastSkin(Transform parentSpawn)
    {
        if (!parentSpawn || parentSpawn.childCount <= 0) return;

        for (int i = 0; i < parentSpawn.childCount; i++)
        {
            var child = parentSpawn.GetChild(i);

            if (child) Destroy(child.gameObject);
        }
    }
}
