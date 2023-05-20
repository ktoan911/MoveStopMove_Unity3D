using UnityEngine;
using UnityEngine.UI;


public class SkinTypeButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(OnButtonSkinTypeClick);
    }

    private void OnButtonSkinTypeClick()
    {
        ShopSkinDialog.Ins.curEquipTypeButton = this.button;

        button.image.color = new Color(0, 0, 0, 0);


    }
}

