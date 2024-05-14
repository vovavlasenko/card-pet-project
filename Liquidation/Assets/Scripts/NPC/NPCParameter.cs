using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public abstract class NPCParameter : MonoBehaviour
{
    [SerializeField] private int _minPossibleAmount;
    [SerializeField] private int _maxPossibleAmount;
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private Transform _iconParent;

    public List<Image> Icons;  

    protected int CurrentMaxAmount;

    public int CurrentAmount { get; protected set; }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize() 
    {
        SetMaxAmount();
        SetStartingAmount();
        CreateIcons();
        ApplyColorToIcons();
    }

    private void SetMaxAmount()
    {
        CurrentMaxAmount = Random.Range(_minPossibleAmount, _maxPossibleAmount + 1);
    }

    protected abstract void SetStartingAmount();

    protected virtual void CreateIcons()
    {
        Icons = new List<Image>();

        for (int i = 0; i < CurrentMaxAmount; i++)
        {
            var icon = Instantiate(_iconPrefab, _iconParent);
            Icons.Add(icon.GetComponent<Image>());
        }
    }

    protected void SetAmount(int newAmount)
    {
        CurrentAmount = newAmount;
        RefreshDisplayedInfo();
    }

    public virtual void ApplyColorToIcons()
    {
        for (int i = 0; i < Icons.Count; i++)
        {
            Icons[i].color = SetIconColor();
        }
    }

    public virtual Color SetIconColor()
    {
        return Color.white;
    }

    public abstract void RefreshDisplayedInfo();

    public abstract void OnConnectedCardUse();
}

