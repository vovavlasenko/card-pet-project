using UnityEngine;
using System;

public class CardFactory
{
    public static event Action<GameObject> OnCardCreated;

    private CardInitializer _cardInitializer = new CardInitializer();

    public void Create(Transform parent, CardType.Type type)
    {
        var cardPrefab = Resources.Load<GameObject>("Card");
        var cardObject = GameObject.Instantiate(cardPrefab, parent);
        _cardInitializer.SetCardType(cardObject, type);
        OnCardCreated?.Invoke(cardObject);
    }

}
