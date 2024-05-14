using UnityEngine;
using System;
using System.Collections.Generic;

public class NPCDistraction : NPCParameter
{
    public static event Action OnFullDistraction;

    private List<Color> _iconColors = new List<Color>() { Color.white, Color.green, Color.magenta };
    private Color _distractionCardColor;
    private int _matchedIconIndex;

    protected override void SetStartingAmount()
    {
        SetAmount(CurrentMaxAmount);
    }

    public override Color SetIconColor()
    {
        return _iconColors[UnityEngine.Random.Range(0, _iconColors.Count)];
    }

    public override void OnConnectedCardUse()
    {
        for (int i = 0; i < Icons.Count; i++)
        {
            if (Icons[i].color == _distractionCardColor)
            {
                _matchedIconIndex = i;
                SetAmount(CurrentAmount -= 1);
                break;
            }
        }
     
    }

    public void SetDistractionCardColor(Color color)
    {
        _distractionCardColor = color;
    }

    public void BeforeBribeUse()
    {
        _distractionCardColor = Icons[0].color;
    }

    public override void RefreshDisplayedInfo()
    {
        if (CurrentAmount < Icons.Count)
        {
            Destroy(Icons[_matchedIconIndex].gameObject);
            Icons.RemoveAt(_matchedIconIndex);

            if (Icons.Count == 0)
            {
                OnFullDistraction?.Invoke();
            }
        }
    }
}
