using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCheck : NPCParameter
{
    [SerializeField] private NPCModel _npcCharacter;

    // ��� ������������� ����� �������� ��������� ������� � �������� ��������
    public override void OnConnectedCardUse() 
    {
        if (CurrentAmount < CurrentMaxAmount)
            SetAmount(CurrentAmount += 1);
    }

    // ����������� ������ �������, ��� �������, � ����������� �� ����, �������� �� NPC ����� �����
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

    // ����������� �������� �������� NPC ����� ����
    protected override void SetStartingAmount()
    {
        SetAmount(0);
    }
}
