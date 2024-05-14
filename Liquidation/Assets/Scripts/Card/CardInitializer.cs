using UnityEngine;

public class CardInitializer 
{
    public enum Type { Empty, Theft, Bribe, Search, Weapon, Alibi, Check, Distraction, Moving }
    public Type CurrentType;

    // Присваиваем карте рандомный тип
    public void SetRandomCardType(GameObject card)
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
    public void SetConcreteType(GameObject card, Type cardType)
    {
        switch(cardType)
        {
            case Type.Weapon:
                card.AddComponent(typeof(WeaponCard));
                    break;
            case Type.Bribe:
                card.AddComponent(typeof(BribeCard));
                break;
        }
        
    }
        
}
