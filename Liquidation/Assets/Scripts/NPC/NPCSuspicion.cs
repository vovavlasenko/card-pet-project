using UnityEngine;

public class NPCSuspicion : NPCParameter
{
    private int _cardsUntilSuspicionIncrease = 3;

    private void OnEnable()
    {
        Card.OnCardPlayed += OnAnyCardUse;
    }

    private void OnDisable()
    {
        Card.OnCardPlayed -= OnAnyCardUse;
    }

    protected override void SetStartingAmount() // ����������� �������� ���������������� NPC ����� ����
    {
        SetAmount(0);
    }

    public override void OnConnectedCardUse() // �������� ���������������� NPC � ������ ���������� ����� �����
    {
        SetAmount(CurrentAmount -= 1);
    }

    private void OnAnyCardUse() // �������� ���������������� NPC ����� ������ ���� ����, ����������� �������
    {
        _cardsUntilSuspicionIncrease--;

        if (_cardsUntilSuspicionIncrease == 0)
        {
            SetAmount(CurrentAmount += 1);
            _cardsUntilSuspicionIncrease = 3;
        }
    }

    public override void RefreshDisplayedInfo() // ����������� ������ ��� ����������� ������ ���������������� NPC
    {
        for (int i = 0; i < Icons.Count; i++)
        {
            if (i < CurrentAmount)
            {
                Icons[i].color = Color.red;
            }

            else
            {
                Icons[i].color = Color.white;
            }
        }

    }
}
