using UnityEngine;

public class SearchCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("�����", Color.red);
    }

    public override void OnButtonClick() // ��� ������������� ����� ������, ������ ������ ����� ������
    {
        RequireConcreteCard(CardInitializer.Type.Weapon);
        base.OnButtonClick();
    }

}
