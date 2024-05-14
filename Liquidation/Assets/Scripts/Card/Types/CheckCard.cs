using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Проверка", Color.blue);
    }

    public override void OnButtonClick()
    {
        Npc.Check.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
