using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePanel : MonoBehaviour
{
    #region ½ºÅÜ º¯¼ö
    [SerializeField] private Image staffImage = null;
    [SerializeField] private Text staffName = null;
    [SerializeField] private Text firepriceText = null;
    [SerializeField] private Text amountText = null;
    [SerializeField] private Button purchaseButtonfire = null;
    [SerializeField] private Sprite[] staffSprite = null;
    private  Staff staff = null;
    private int staffNumber = 0;


    #endregion

    private void Update()
    {
        amountText.text = string.Format("{0}", staff.amount);

    }

    public void LockFire()
    {

        staff = GameManager.Instance.CurrentUser.staffList[staffNumber];
    }

    public void SetValue(Staff staff)
    {
        firepriceText.text = string.Format("<color=#ff0000>ÅðÁ÷±Ý</color> {0} ¸¸¿ø", staff.fireprice);
        staffImage.sprite = staffSprite[staff.imageNumber];
        staffName.text = staff.name;
        amountText.text = string.Format("{0}", staff.amount);
        this.staff = staff;
    }
    public void OnClickpurchase1()
    {
        if(staff.amount<=0)
        {
            return;
        }
        if (GameManager.Instance.CurrentUser.money < staff.fireprice)
        {
            return;
        }
        GameManager.Instance.CurrentUser.money -= staff.fireprice;
        Staff staffInList = GameManager.Instance.CurrentUser.staffList.Find((x) => x == staff);
        staffInList.amount--;
        staffInList.price = (long)staffInList.price - 30;
        amountText.text = string.Format("{0}", staffInList.amount);
        firepriceText.text = string.Format("<color=#ff0000>ÅðÁ÷±Ý</color> {0} ¸¸¿ø", staffInList.fireprice);
        GameManager.Instance.uiManager.UpdateMoneyPanel();
    }
}
