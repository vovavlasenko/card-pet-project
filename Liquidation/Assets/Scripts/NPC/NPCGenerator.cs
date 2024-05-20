using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _npcPrefab;
    [SerializeField] private Transform _npcParentTransform;
    
    private NpcFactory _npcFactory = new NpcFactory();

    public GameObject CurrentNPC { get; private set; }


    private void Start()
    {
        CreateNewNPCCharacter();
    }

    private void OnEnable()
    {
        NPCDistraction.OnFullDistraction += CreateNewNPCCharacter;
        NPCHealth.OnAllHPLost += CreateNewNPCCharacter;
        CardFactory.OnCardCreated += SetNPCToCard;
    }

    private void OnDisable()
    {
        NPCDistraction.OnFullDistraction -= CreateNewNPCCharacter;
        NPCHealth.OnAllHPLost -= CreateNewNPCCharacter;
        CardFactory.OnCardCreated -= SetNPCToCard;
    }

    private void CreateNewNPCCharacter()
    {
        if (CurrentNPC != null)
            Destroy(CurrentNPC);

        CurrentNPC = _npcFactory.Create(_npcParentTransform);
    }


    private void SetNPCToCard(GameObject cardObject) // Прокидываем сущность NPC в скрипт карты
    {
        if (CurrentNPC != null)
        {
            var card = cardObject.GetComponent<Card>();
            card.SetNPCCharacter(CurrentNPC);
        }
    }

}
