using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class ShopWeaponUI : Singleton<ShopWeaponUI>
{

    private Player player;

    private int currentIndex = 0;

    [SerializeField] private TMP_Text description;

    [SerializeField] private Button btnBuy;

    [SerializeField] private TMP_Text coinText;

    public TMP_Text priceText;

    public TMP_Text nameEquipment;
    public Image hud;
    
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

        else if(currentIndex < 0)
        {
            currentIndex = SOManager.Ins.weaponS0.Count - 1;
        }

        SetInfoItem(currentIndex);
    }

    private void SetInfoItem(int currentIndex)
    {

        int shopItemID = SOManager.Ins.weaponS0[currentIndex].ID;

        if (hud)
        {
            hud.sprite = SOManager.Ins.weaponS0[currentIndex].hud;

            nameEquipment.text = SOManager.Ins.weaponS0[currentIndex].weaponName;

            description.text = "+ " + SOManager.Ins.weaponS0[currentIndex].percentUpRange * 100f + "% Attack Range";

            bool isUnlocked = Pref.GetBool(PrefConst.WEAPON_PEFIX + shopItemID);

            if (isUnlocked)
            {
                if (shopItemID == Pref.CurWeaponId)
                {
                    if (priceText) priceText.text = "Eqquiped";

                    btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;
                }

                else
                {
                    if (priceText) priceText.text = "Select";

                    btnBuy.image.sprite = ShopManager.Ins.imageButtonSelect;
                }
            }

            else
            {
                if (priceText) priceText.text = SOManager.Ins.weaponS0[currentIndex].price.ToString();

                btnBuy.image.sprite = ShopManager.Ins.imageButtonBuy;
            }
        }
    }

    public void BuyWeapon()
    {
        //GameManager.Ins.Player.ChangeAttackRange(8);

        int shopItemID = SOManager.Ins.weaponS0[currentIndex].ID;

        bool isUnlocked = Pref.GetBool(PrefConst.WEAPON_PEFIX + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurWeaponId) return;

            //nếu ko phải thì thay đổi dữ liệu currentid
            Pref.CurWeaponId = shopItemID;
            player.ChangeWeapon(SOManager.Ins.weaponS0[currentIndex].ID);

            if (priceText) priceText.text = "Eqquiped";
            btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;
        }

        else
        {
            if (player.Coins >= SOManager.Ins.weaponS0[currentIndex].price) // check đủ tiền không
            {
                //thay đổi tiền
                player.UpdateCoin(SOManager.Ins.weaponS0[currentIndex].price, false);

                //thay đổi trạng thái thành mở khóa
                Pref.SetBool(PrefConst.WEAPON_PEFIX + shopItemID, true);
                Pref.CurWeaponId = shopItemID;

                player.ChangeWeapon(SOManager.Ins.weaponS0[currentIndex].ID);

                if (priceText) priceText.text = "Eqquiped";
                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;

                this.SetCoinText(player.Coins);
            }
        }
    }

    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }



}
