using System.Collections.Generic;
using System;

[System.Serializable]

public class User
{
    public string nickname;
    public long money;
    public int maxAmount = 10;
    public float totalEps;
    public float plusmaxAmount;
    public float endplusmaxAmount;
    public int totalamount;
    public List<Staff> staffList = new List<Staff>();
    public List<Building> buildingList = new List<Building>();

    
    public float mouseEps
    {
        get
        {
            return (float)(1f > Math.Round(TotalEps * 0.01f) ? 1f : Math.Round(TotalEps * 0.01f));
        }
    }


    public float TotalEps
    {

        get
        {
            totalEps = 0f;
            foreach (Staff staff in staffList)
            {
                totalEps += staff.ePs * staff.amount;
            }
            return totalEps;
        }
        set
        {

        }
    }

    public float MaxAmount
    {
        get
        {
            maxAmount = 10;
            foreach(Building building in buildingList)
            {
                maxAmount += building.amount*building.plusmaxamount;
            }
            return maxAmount;
        }
    }
    public float Totalamount
    {
        get
        {
            totalamount = 0;
            foreach (Staff staff in staffList)
            {
                totalamount += staff.amount;
            }
            return totalamount;
        }
        set
        {

        }
    }
}
