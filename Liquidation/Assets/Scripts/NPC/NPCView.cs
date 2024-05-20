using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class NPCView : MonoBehaviour
{
    [SerializeField] private List<Sprite> _npcSprites;

    private List<Sprite> _availableSprites = new List<Sprite>();

    private void OnEnable()
    {
        NpcFactory.OnNewNPCCharacterSpawn += SetNpcSprite;
    }

    private void OnDisable()
    {
        NpcFactory.OnNewNPCCharacterSpawn -= SetNpcSprite;
    }

    public void SetNpcSprite(GameObject npc)
    {
        int availableIndex = AvailableSpriteIndex();
        npc.GetComponent<Image>().sprite = _availableSprites[availableIndex];
        _availableSprites.RemoveAt(availableIndex);
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

        return Random.Range(0, _availableSprites.Count);
    }
}

