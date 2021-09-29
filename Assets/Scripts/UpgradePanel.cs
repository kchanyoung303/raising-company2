using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradePanel : MonoBehaviour
{
    #region 스텝 변수
    [SerializeField] private Image staffImage = null;
    [SerializeField] private Text staffName = null;
    [SerializeField] private Text priceText = null;
    [SerializeField] private Text amountText = null;
    [SerializeField] private Text staffePsText = null;
    [SerializeField] private Text stafftotalePsText = null;
    [SerializeField] private Button purchaseButton = null;
    [SerializeField] private Sprite[] staffSprite = null;

    private Staff staff = null;
    #endregion

    private int staffNumber = 0;
    private Sprite[] staffSpriteArray;


    private void Update()
    {
        amountText.text = string.Format("{0}", staff.amount);
        priceText.text = string.Format("{0} 만원", staff.price);
    }
    public void SetValue(Staff staff)
    {
        staffImage.sprite = staffSprite[staff.imageNumber];
        staffName.text = staff.name;
        priceText.text = string.Format("{0} 만원", staff.price);
        amountText.text = string.Format("{0}", staff.amount);
        staffePsText.text = string.Format("+{0} 만/s", staff.ePs);
        stafftotalePsText.text = string.Format("total +{0} 만/s", staff.ePs * staff.amount);
        this.staff = staff;
        
    }
    public void OnClickpurchase()
    {
        amountText.text = string.Format("{0}", staff.amount);

        if (GameManager.Instance.CurrentUser.totalamount + 1 > GameManager.Instance.CurrentUser.maxAmount) return;
        if (GameManager.Instance.CurrentUser.money<staff.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.money -= staff.price;
        Staff staffInList= GameManager.Instance.CurrentUser.staffList.Find((x)=>x==staff);
        staffInList.amount++;
        staffInList.price = (long)(staffInList.amount<10?(staffInList.price+4+5)*1.2:(staffInList.price+4+6)*1.2) ;
        amountText.text = string.Format("{0}", staffInList.amount);
        staffePsText.text = string.Format("+{0} 만/s", staffInList.ePs);
        stafftotalePsText.text = string.Format("total +{0} 만/s", staffInList.ePs * staffInList.amount);
        priceText.text = string.Format("{0} 만원", staffInList.price);
        GameManager.Instance.uiManager.UpdateMoneyPanel();
    }
}
