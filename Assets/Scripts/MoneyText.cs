using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private Text moneyText = null;

    public void Show(float number)
    {
        
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        moneyText = GetComponent<Text>();
        moneyText.text = string.Format("+{0} ¸¸¿ø", number);
        moneyText.DOFade(0f, 0.5f);
        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 100f;
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f).OnComplete(() => Despawn());
    }

    void Start()
    {
    }

    private void Despawn()
    {
        moneyText.DOFade(1f, 0f);
        moneyText.transform.SetParent(GameManager.Instance.Pool);
        moneyText.gameObject.SetActive(false);
    }
}
