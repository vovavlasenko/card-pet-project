using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : NPCParameter
{
    [SerializeField] private NPCCharacter _npcCharacter;

    public static event Action OnAllHPLost;

    private int _damageAmount;

    public void SetWeaponDamage(int damageAmount)
    {
        _damageAmount = damageAmount;        
    }

    public override void OnConnectedCardUse()
    {
        SetAmount(CurrentAmount -= _damageAmount);
    }

    public override void RefreshDisplayedInfo()
    {
        int hpLost = Icons.Count - CurrentAmount;

        for (int i = 0; i < hpLost; i++)
        {
            Destroy(Icons[Icons.Count - 1].gameObject);
            Icons.RemoveAt(Icons.Count - 1);

            if (Icons.Count == 0)
            {
                OnAllHPLost?.Invoke();
                break;
            }
        }
    }

    protected override void SetStartingAmount()
    {
        SetAmount(CurrentMaxAmount);
    }

    public override Color SetIconColor()
    {
        return Color.red;
    }


}
