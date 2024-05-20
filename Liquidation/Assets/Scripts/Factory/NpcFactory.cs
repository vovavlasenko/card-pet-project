using System;
using UnityEngine;

public class NpcFactory
{
    public static event Action<GameObject> OnNewNPCCharacterSpawn;

    public GameObject Create(Transform parent)
    {
        var npcPrefab = Resources.Load<GameObject>("NPCCharacter");
        var npcObject = GameObject.Instantiate(npcPrefab, parent);
        OnNewNPCCharacterSpawn?.Invoke(npcObject);
        return npcObject;
    }
}
