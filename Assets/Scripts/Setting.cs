using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject[] Tab1;
    public Image[] TabBtnImage1;
    public Sprite[] IdleSprite1, SelectSprite1;
    private void Start()
    {
        TabClick(1);
    }

    public void TabClick(int n)
    {
        for (int i = 0; i < Tab1.Length; i++)
        {
            Tab1[i].SetActive(i == n);
            TabBtnImage1[i].sprite = i == n ? SelectSprite1[i] : IdleSprite1[i];
        }
    }
}
