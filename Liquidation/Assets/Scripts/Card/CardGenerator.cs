using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private NPCGenerator _npcGenerator;

    private CardInitializer _cardInitializer = new CardInitializer();
    private CardInitializer.Type _concreteType = CardInitializer.Type.Empty;

    private void Start()
    {
        GenerateCardsHardOnNewLocation();
    }

    private void OnEnable()
    {
        Card.OnCardPlayed += GenerateCard;
        Card.OnConcreteCardToGenerate += SetConcreteCardType;
    }

    private void OnDisable()
    {
        Card.OnCardPlayed -= GenerateCard;
    }

    private void GenerateCardsHardOnNewLocation()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateCard();
        }
    }

    // √енерируем новую карту в руке игрока
    private void GenerateCard()
    {
        var card = Instantiate(_cardPrefab, _parentTransform);

        if (_concreteType == CardInitializer.Type.Empty)
        {
            _cardInitializer.SetRandomCardType(card);
        }

        else
        {
            _cardInitializer.SetConcreteType(card, _concreteType);
            _concreteType = CardInitializer.Type.Empty;
        }

        if (_npcGenerator.CurrentNPC != null)
        {
            card.GetComponent<Card>().SetNPCCharacter(_npcGenerator.CurrentNPC);
        }
    }

    // «адаем дл€ генерации конкретный тип карты
    public void SetConcreteCardType(CardInitializer.Type type) 
    {
        _concreteType = type;
    }
}
