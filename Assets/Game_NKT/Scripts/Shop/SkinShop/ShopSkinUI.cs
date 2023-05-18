using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ShopSkinUI<T> : MonoBehaviour where T : ParentSO
{
    public Image hud;

    public int shopItemID;

    public T skinSO;

    public UnityAction<string> ShopSkinItemAction;

    public virtual void SetInfoItem(int currentIndex)
    {

    }
}
