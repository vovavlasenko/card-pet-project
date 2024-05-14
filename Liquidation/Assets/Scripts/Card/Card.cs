using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardInterface))]
[RequireComponent(typeof(Button))]

public abstract class Card : MonoBehaviour
{

    public static event Action OnCardPlayed;
    public static event Action<CardInitializer.Type> OnConcreteCardToGenerate;

    protected CardInterface CardInterface;
    protected Button CardButton;

    public NPCCharacter Npc;

    private void Awake()
    {
        CardInterface = GetComponent<CardInterface>();
        CardButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        NPCGenerator.OnNewNPCCharacterSpawn += SetNPCCharacter;
        CardButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        NPCGenerator.OnNewNPCCharacterSpawn -= SetNPCCharacter;
        CardButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        SetCardDisplay();
    }

    /// <summary>
    /// ����������� ����������� �����
    /// </summary>
    public abstract void SetCardDisplay();

    /// <summary>
    /// ����������� �����
    /// </summary>
    public virtual void OnButtonClick()
    {
        OnCardPlayed?.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// ��� ��������� ������ NPC, �������� � ���� ������
    /// </summary>
    /// <param name="npcCharacter"></param>
    public void SetNPCCharacter(GameObject npcCharacter)
    {
        Npc = npcCharacter.GetComponent<NPCCharacter>();
    }

    /// <summary>
    /// ����������, ����� ��� ������������ �����, ����� ������ �������� ������, ��������� � ��� �����
    /// </summary>
    /// <param name="type"></param>
    protected void RequireConcreteCard(CardInitializer.Type type)
    {
        OnConcreteCardToGenerate?.Invoke(type);
    }

}
