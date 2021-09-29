using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Text txtTitle;
    private string m_Message;
    private float m_Speed = 0.15f;
    [SerializeField] private RectTransform Panel;
    void Start()
    {
        m_Message = @" RAISING
COMPANY
2";

        StartCoroutine(Typing(txtTitle, m_Message, m_Speed));
    }

    IEnumerator Typing(Text txtTitle, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            txtTitle.text = message.Substring(0 , i + 1);
            yield return new WaitForSeconds(speed);
        }
        UpDown();
        yield break;
    }
    public void UpDown()
    {
        Panel.DOLocalMoveY(100, 1).SetLoops(-1, LoopType.Yoyo);
    }
    public void BtnStart()
    {
        SceneManager.LoadScene(1);
    }
}
