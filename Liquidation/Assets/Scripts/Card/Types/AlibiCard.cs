using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlibiCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Алиби", Color.blue);
    }

    public override void OnButtonClick()
    {
        Npc.Suspicion.OnConnectedCardUse();
        base.OnButtonClick();
    }
}
