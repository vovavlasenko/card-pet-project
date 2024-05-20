using UnityEngine;

public class CardInitializer 
{
    public void SetCardType(GameObject card, CardType.Type type)
    {
        if (type == CardType.Type.Random)
        {
            SetRandomCardType(card);
        }

        else
        {
            SetConcreteType(card, type);
        }
    }

    // Присваиваем карте рандомный тип
    private void SetRandomCardType(GameObject card)
    {
        int rand = Random.Range(0, 100);
        {
            if (rand < 15)
            {
                card.AddComponent(typeof(TheftCard));
            }

            else if (rand > 14 && rand < 30)
            {
                card.AddComponent(typeof(SearchCard));
            }

            else if (rand > 29 && rand < 40)
            {
                card.AddComponent(typeof(AlibiCard));
            }

            else if (rand > 39 && rand < 50)
            {
                card.AddComponent(typeof(CheckCard));
            }

            else
            {
                card.AddComponent(typeof(DistractionCard));
            }

        }
    }

    // Присваиваем карте конкретный тип
    private void SetConcreteType(GameObject card, CardType.Type cardType)
    {
        switch(cardType)
        {
            case CardType.Type.Weapon:
                card.AddComponent(typeof(WeaponCard));
                    break;
            case CardType.Type.Bribe:
                card.AddComponent(typeof(BribeCard));
                break;
        }
        
    }
        
}
