using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _npcPrefab;
    [SerializeField] private Transform _npcParentTransform;
    [SerializeField] private List<Sprite> _npcSprites;

    public static event Action<GameObject> OnNewNPCCharacterSpawn;

    private List<Sprite> _availableSprites = new List<Sprite>();

    public GameObject CurrentNPC { get; private set; }


    private void Start()
    {
        CreateNewNPCCharacter();
    }

    private void OnEnable()
    {
        NPCDistraction.OnFullDistraction += CreateNewNPCCharacter;
        NPCHealth.OnAllHPLost += CreateNewNPCCharacter;
    }

    private void OnDisable()
    {
        NPCDistraction.OnFullDistraction -= CreateNewNPCCharacter;
        NPCHealth.OnAllHPLost -= CreateNewNPCCharacter;
    }

    private void CreateNewNPCCharacter()
    {
        int spriteIndex = AvailableSpriteIndex();

        if (CurrentNPC != null)
            Destroy(CurrentNPC);

        CurrentNPC = Instantiate(_npcPrefab, _npcParentTransform);
        CurrentNPC.GetComponent<NPCCharacter>().SetNpcSprite(_availableSprites[spriteIndex]);
        _availableSprites.RemoveAt(spriteIndex);
        OnNewNPCCharacterSpawn?.Invoke(CurrentNPC);
    }

    private int AvailableSpriteIndex() 
    {
        if (_availableSprites.Count == 0)
        {
            for (int i = 0; i < _npcSprites.Count; i++)
            {
                _availableSprites.Add(_npcSprites[i]);
            }
        }
         
        return UnityEngine.Random.Range(0, _availableSprites.Count);               
    }

}
