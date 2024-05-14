using UnityEngine;

public class SearchCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Поиск", Color.red);
    }

    public override void OnButtonClick() // При использовании карты Поиска, выдаем игроку карту Оружия
    {
        RequireConcreteCard(CardInitializer.Type.Weapon);
        base.OnButtonClick();
    }

}
