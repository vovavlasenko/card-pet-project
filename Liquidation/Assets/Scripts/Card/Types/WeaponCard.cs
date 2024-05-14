using UnityEngine;

public class WeaponCard : Card
{
    private Weapon _weapon = new Weapon();
    private int _damage;

    public override void SetCardDisplay() // ���������� �� ����� �������� � ����� � ����
    {
        CardInterface.SetCardDisplay("������", Color.red);
        _damage = _weapon.SetWeaponDamage();
        CardInterface.SetCardInfo(_damage.ToString());
    }

    public override void OnButtonClick() // ��� ������������� ����� �����, ��������� �������� �������� NPC
    {
        Npc.Health.SetWeaponDamage(_damage);
        Npc.Health.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
