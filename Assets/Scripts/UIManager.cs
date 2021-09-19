using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyPerSecond = null;
    [SerializeField]
    private Text amounttotalmax = null;
    [SerializeField]
    private  Text moneyText = null;
    [SerializeField]
    Animator Computer = null;
    [SerializeField]
    private FirePanel FirePanelTemplate = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;
    [SerializeField]
    private BuildingUpgradePanel buildingupgradePanelTemplate = null;

    private Button btn;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    private List<BuildingUpgradePanel> buildingupgradePanelList = new List<BuildingUpgradePanel>();
    private List<FirePanel> firePanelList = new List<FirePanel>();
    // Start is called before the first fratme update
    void Start()
    {
        UpdateMoneyPanel();
        CreateStaffPanels();
        CreateBuildingPanels();
        FireCreateStaffPanels();
        OnClickComputer();
    }
    public void FireCreateStaffPanels()
    {
        GameObject Firepanel = null;
        FirePanel FirepanelComponent = null;

        foreach (var staff in GameManager.Instance.CurrentUser.staffList)
        {
            Firepanel = Instantiate(FirePanelTemplate.gameObject, FirePanelTemplate.transform.parent);
            FirepanelComponent = Firepanel.GetComponent<FirePanel>();
            FirepanelComponent.SetValue(staff);
            Firepanel.SetActive(true);
            firePanelList.Add(FirepanelComponent);
        }
    }
    public void CreateBuildingPanels()
    {
        GameObject buildingPanel = null;
        BuildingUpgradePanel BuildingpanelComponent = null;

        foreach (var building in GameManager.Instance.CurrentUser.buildingList)
        {
            buildingPanel = Instantiate(buildingupgradePanelTemplate.gameObject, buildingupgradePanelTemplate.transform.parent);
            BuildingpanelComponent = buildingPanel.GetComponent<BuildingUpgradePanel>();
            BuildingpanelComponent.SetValue(building);
            buildingPanel.SetActive(true);
            buildingupgradePanelList.Add(BuildingpanelComponent);
        }
    }
    public void CreateStaffPanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;

        foreach (var staff in GameManager.Instance.CurrentUser.staffList)
        {
            panel = Instantiate(upgradePanelTemplate.gameObject, upgradePanelTemplate.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(staff);
            panel.SetActive(true);
            upgradePanelList.Add(panelComponent);
        }
    }
    public void UpdateImmediate()
    {
        //totalEnergyText.text = string.Format("{0} 에너지", GameManager.Instance.CurrentUser.energy);
        //energyPerSecond.text = string.Format("초당 {0} 에너지 생산", GameManager.Instance.CurrentUser.TotalEps);
    }
    public void OnClickComputer()
    {
        GameManager.Instance.CurrentUser.money += 1;
        Computer.Play("Click");
        UpdateMoneyPanel();
    }

    public void UpdateMoneyPanel()
    {
        moneyText.text = string.Format("{0} 만원", GameManager.Instance.CurrentUser.money);
        moneyPerSecond.text = string.Format("{0} 만/s", GameManager.Instance.CurrentUser.TotalEps);
        amounttotalmax.text = string.Format("{0}/{1} 직원 수", GameManager.Instance.CurrentUser.Totalamount,GameManager.Instance.CurrentUser.MaxAmount);
    }
}
