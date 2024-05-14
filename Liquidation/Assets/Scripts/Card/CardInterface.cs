using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cardName;
    [SerializeField] private TextMeshProUGUI _cardInfo;
    [SerializeField] private Image _cardImage;

    public Color CardColor { get; private set; }


    public void SetCardDisplay(string text, Color color)
    {
        _cardName.SetText(text);
        CardColor = color;
        _cardImage.color = CardColor;
    }

    public void SetCardInfo(string info)
    {
        _cardInfo.gameObject.SetActive(true);
        _cardInfo.SetText(info);
    }

}
