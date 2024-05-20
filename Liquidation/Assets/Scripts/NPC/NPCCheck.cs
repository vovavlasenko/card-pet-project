using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCheck : NPCParameter
{
    [SerializeField] private NPCModel _npcCharacter;

    // При использовании карты проверки добавляем единицу к значению проверки
    public override void OnConnectedCardUse() 
    {
        if (CurrentAmount < CurrentMaxAmount)
            SetAmount(CurrentAmount += 1);
    }

    // Закрашиваем иконку красным, или зеленым, в зависимости от того, является ли NPC нашей целью
    public override void RefreshDisplayedInfo() 
    {
        for (int i = 0; i < CurrentAmount; i++)
        {
            if (_npcCharacter.IsTarget)
            {
                Icons[i].color = Color.green;
            }

            else
            {
                Icons[i].color = Color.red;
            }
        }
    }

    // Изначальное значение проверки NPC равно нулю
    protected override void SetStartingAmount()
    {
        SetAmount(0);
    }
}
