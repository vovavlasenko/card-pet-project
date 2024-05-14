using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BribeCard : Card
{    
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("������", Color.yellow);
    }

    public override void OnButtonClick()
    {
        Npc.Distraction.BeforeBribeUse();
        Npc.Distraction.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
