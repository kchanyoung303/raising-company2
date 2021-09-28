using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GameManager : monosingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    private Button btn;

    [SerializeField]
    private Transform textpool = null;

    public Transform Pool { get { return textpool; } }

    public User CurrentUser { get { return user; } }

    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.txt";

    public UIManager uiManager { get; private set; }

    public void EarnMoneyPerSecond()
    {
        foreach (Staff staff in user.staffList)
        {
            user.money += staff.ePs * staff.amount;
        }
        uiManager.UpdateMoneyPanel();
    }



    public void MoneyePs()
    {
        foreach (Staff staff in user.staffList)
        {
            user.TotalEps = staff.ePs * staff.amount;
        }
    }

    public void Totalamount1()
    {
        foreach(Staff staff in user.staffList)
        {
            user.Totalamount += staff.amount;
        }
    }
    public void Fireamount()
    {
        foreach (Staff staff in user.staffList)
        {
            if (staff.amount <= 0)
            {
                return;
            }
        }
    }
    public void PlusMaxAmount()
    {
        foreach(Building building in user.buildingList)
        {
            user.maxAmount += building.amount * building.plusmaxamount;
        }
    }
    private void Awake()
    {

        SAVE_PATH = Application.persistentDataPath;
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();
        uiManager = FindObjectOfType<UIManager>();
        print(SAVE_PATH);
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnMoneyPerSecond", 0f, 1f);
        //InvokeRepeating("MoneyePs", 0f, 1f);
        InvokeRepeating("Totalamount1", 0f, 1f);
    }
    private void LoadFromJson()
    {
        string json = "";

        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }

    private void SaveToJson()
    {
        SAVE_PATH = Application.persistentDataPath;
        if (user == null) return;
        string json = JsonUtility.ToJson(user);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}