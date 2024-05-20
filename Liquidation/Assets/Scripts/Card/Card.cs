using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardInterface))]
[RequireComponent(typeof(Button))]

public abstract class Card : MonoBehaviour
{

    public static event Action OnCardPlayed;
    public static event Action<CardType.Type> OnConcreteCardToGenerate;

    protected CardInterface CardInterface;
    protected Button CardButton;

    public NPCModel Npc;

    private void Awake()
    {
        CardInterface = GetComponent<CardInterface>();
        CardButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        NpcFactory.OnNewNPCCharacterSpawn += SetNPCCharacter;
        CardButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        NpcFactory.OnNewNPCCharacterSpawn -= SetNPCCharacter;
        CardButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        SetCardDisplay();
    }

    /// <summary>
    /// Настраиваем отображение карты
    /// </summary>
    public abstract void SetCardDisplay();

    /// <summary>
    /// Разыгрываем карту
    /// </summary>
    public virtual void OnButtonClick()
    {
        OnCardPlayed?.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// При генерации нового NPC, получаем к нему доступ
    /// </summary>
    /// <param name="npcCharacter"></param>
    public void SetNPCCharacter(GameObject npcCharacter)
    {
        Npc = npcCharacter.GetComponent<NPCModel>();
    }

    /// <summary>
    /// Используем, когда при разыгрывании карты, игрок должен получить другую, связянную с ней карту
    /// </summary>
    /// <param name="type"></param>
    protected void RequireConcreteCard(CardType.Type type)
    {
        OnConcreteCardToGenerate?.Invoke(type);
    }

}
