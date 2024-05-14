using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheftCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Кража", Color.yellow);
    }

    public override void OnButtonClick()
    {
        RequireConcreteCard(CardInitializer.Type.Bribe);
        base.OnButtonClick();
    }
}
