using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private NPCGenerator _npcGenerator;

    private CardType.Type _typeToSpawn = CardType.Type.Random;
    private CardFactory _cardFactory = new CardFactory();

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

    // Генерируем руку игрока на старте
    private void GenerateCardsHardOnNewLocation()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateCard();
        }
    }

    // Генерируем новую карту в руке игрока
    private void GenerateCard()
    {
        _cardFactory.Create(_parentTransform, _typeToSpawn);
        _typeToSpawn = CardType.Type.Random;
    }

    private void SetConcreteCardType(CardType.Type type)
    {
        _typeToSpawn = type;
    }
}
