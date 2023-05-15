using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopWeaponUI : Singleton<ShopWeaponUI>
{

    private Player player;

    public TMP_Text priceText;

    [SerializeField] private TMP_Text coinText;

    public TMP_Text nameEquipment;
    public Image hud;

    private int currentIndex = 0;


    private void Start()
    {
        SetInfoItem(currentIndex);

        player = GameManager.Ins.Player;
    }

    // Phương thức để thay đổi sprite
    public void ChangeNextItem()
    {
        currentIndex++;

        ChangeToNextSprite();
    }
    
    public void ChangeBackItem()
    {
        currentIndex--;

        ChangeToNextSprite();
    }

    private void ChangeToNextSprite()
    {
        hud.sprite = null;

        // Nếu chỉ số vượt quá số lượng sprite trong danh sách, quay trở lại sprite đầu tiên
        if (currentIndex >= SOManager.Ins.weaponS0.Count)
        {
            currentIndex = 0;
        }

        else if(currentIndex <=0)
        {
            currentIndex = SOManager.Ins.weaponS0.Count - 1;
        }

        SetInfoItem(currentIndex);
    }

    private void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.weaponS0[currentIndex].hud;

        priceText.text = SOManager.Ins.weaponS0[currentIndex].weaPonPrice.ToString();

        nameEquipment.text = SOManager.Ins.weaponS0[currentIndex].weaponName;
    }

    public void BuyWeapon()
    {
        if (player == null) Debug.Log(1);


        if(player.Coins >= SOManager.Ins.weaponS0[currentIndex].weaPonPrice)
        {
            player.Coins -= SOManager.Ins.weaponS0[currentIndex].weaPonPrice;

            player.ChangeWeapon(currentIndex);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);


        }

        else { }
    }

    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }







    public void UpdateUI(ShopWeaponItem item, int shopItemID)
    {
        if(item == null ) return;

        if(hud)
        {
            hud.sprite = item.hud;

            bool isUnlocked = Pref.GetBool(PrefConst.WEAPON_PEFIX + shopItemID);

            if (isUnlocked)
            {
                if(shopItemID == Pref.CurWeaponId)
                {
                    if (priceText) priceText.text = "Active";
                }

                else
                {
                    if (priceText) priceText.text = "OWNED";
                }
            }

            else
            {
                if (priceText) priceText.text= item.price.ToString();
            }
        }
    }

}
