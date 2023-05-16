using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

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

        int shopItemID = SOManager.Ins.weaponS0[currentIndex].IDWeapon;

        if (hud)
        {
            hud.sprite = SOManager.Ins.weaponS0[currentIndex].hud;

            nameEquipment.text = SOManager.Ins.weaponS0[currentIndex].weaponName;

            bool isUnlocked = Pref.GetBool(PrefConst.WEAPON_PEFIX + shopItemID);

            if (isUnlocked)
            {
                if (shopItemID == Pref.CurWeaponId)
                {
                    if (priceText) priceText.text = "Eqquiped";
                }

                else
                {
                    if (priceText) priceText.text = "Select";
                }
            }

            else
            {
                if (priceText) priceText.text = SOManager.Ins.weaponS0[currentIndex].weaPonPrice.ToString();
            }
        }
    }

    public void BuyWeapon()
    {

        int shopItemID = SOManager.Ins.weaponS0[currentIndex].IDWeapon;

        bool isUnlocked = Pref.GetBool(PrefConst.WEAPON_PEFIX + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurWeaponId) return;

            //nếu ko phải thì thay đổi dữ liệu currentid
            Pref.CurWeaponId = shopItemID;
            player.ChangeWeapon(SOManager.Ins.weaponS0[currentIndex].IDWeapon);
            if (priceText) priceText.text = "Eqquiped";
        }

        else
        {
            if (player.Coins >= SOManager.Ins.weaponS0[currentIndex].weaPonPrice) // check đủ tiền không
            {
                //thay đổi tiền
                player.UpdateCoin(SOManager.Ins.weaponS0[currentIndex].weaPonPrice, false);

                //thay đổi trạng thái thành mở khóa
                Pref.SetBool(PrefConst.WEAPON_PEFIX + shopItemID, true);
                Pref.CurWeaponId = shopItemID;

                player.ChangeWeapon(SOManager.Ins.weaponS0[currentIndex].IDWeapon);
                if (priceText) priceText.text = "Eqquiped";
                this.SetCoinText(player.Coins);
            }
        }
    }

    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }



}
