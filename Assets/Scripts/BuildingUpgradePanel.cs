using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgradePanel : MonoBehaviour
{
    #region 빌딩 변수
    [SerializeField] private Image buildingImage = null;
    [SerializeField] private Text buildingName = null;
    [SerializeField] private Text buildingpriceText = null;
    [SerializeField] private Text buildingamountText = null;
    [SerializeField] private Button purchaseButton1 = null;
    [SerializeField] private Text PlusAmount = null;
    [SerializeField] private Sprite[] buildingSprite = null;
    private Building building = null;
    #endregion

    public void SetValue(Building building)
    {
        PlusAmount.text = string.Format("+{0} 직원수", building.plusmaxamount);
        this.building = building;
        buildingImage.sprite = buildingSprite[building.imageNumber];
        buildingName.text = building.name;
        buildingpriceText.text = string.Format("{0} 만원", building.price);
        buildingamountText.text = string.Format("{0}", building.amount);
    }
     
    public void OnClickbuildingpurchase()
    {
        if (GameManager.Instance.CurrentUser.money < building.price) return;

            GameManager.Instance.PlusMaxAmount();
            GameManager.Instance.CurrentUser.money -= building.price;
            Building buildingInList = GameManager.Instance.CurrentUser.buildingList.Find((x) => x == building);
            buildingInList.amount++;
            buildingInList.price = (long)(buildingInList.price * 2f);
            buildingamountText.text = string.Format("{0}", buildingInList.amount);
            buildingpriceText.text = string.Format("{0} 만원", buildingInList.price);
            PlusAmount.text = string.Format("+{0} 직원수", buildingInList.plusmaxamount);
            GameManager.Instance.uiManager.UpdateMoneyPanel();
    }
}
