using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCard : Card
{
    public override void SetCardDisplay()
    {
        CardInterface.SetCardDisplay("Перемещение", Color.gray);
    }

}
