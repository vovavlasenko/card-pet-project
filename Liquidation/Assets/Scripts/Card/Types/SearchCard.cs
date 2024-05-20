using UnityEngine;

public class SearchCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("�����", Color.red);
    }

    public override void OnButtonClick() // ��� ������������� ����� ������, ������ ������ ����� ������
    {
        RequireConcreteCard(CardType.Type.Weapon);
        base.OnButtonClick();
    }

}
