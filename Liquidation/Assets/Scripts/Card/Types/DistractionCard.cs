using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Отвлечение", RandomDistractionColor());
    }

    private Color RandomDistractionColor()
    {
        int r = Random.Range(0, 3);
       
        if (r == 0)
        {
            return Color.green;
        }

        else if (r == 1)
        {
            return Color.white;
        }

        else
        {
            return Color.magenta;
        }
    }

    public override void OnButtonClick()
    {
        Npc.Distraction.SetDistractionCardColor(CardInterface.CardColor);
        Npc.Distraction.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
