using UnityEngine;

public class WeaponCard : Card
{
    private Weapon _weapon = new Weapon();
    private int _damage;

    public override void SetCardDisplay() // Отображаем на карте значение её атаки и цвет
    {
        CardInterface.SetCardDisplay("Оружие", Color.red);
        _damage = _weapon.SetWeaponDamage();
        CardInterface.SetCardInfo(_damage.ToString());
    }

    public override void OnButtonClick() // При использовании карты атаки, уменьшаем значение здоровья NPC
    {
        Npc.Health.SetWeaponDamage(_damage);
        Npc.Health.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
