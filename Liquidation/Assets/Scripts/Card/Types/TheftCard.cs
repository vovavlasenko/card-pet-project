using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheftCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("�����", Color.yellow);
    }

    public override void OnButtonClick()
    {
        RequireConcreteCard(CardType.Type.Bribe);
        base.OnButtonClick();
    }
}
