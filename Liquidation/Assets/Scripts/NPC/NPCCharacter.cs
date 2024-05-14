using UnityEngine.UI;
using UnityEngine;

public class NPCCharacter : MonoBehaviour
{
    [SerializeField] private NPCSuspicion _suspicion;
    [SerializeField] private NPCDistraction _distraction;
    [SerializeField] private NPCHealth _health;
    [SerializeField] private NPCCheck _check;
    [SerializeField] private Image _npcImage;

    public NPCSuspicion Suspicion => _suspicion;
    public NPCDistraction Distraction => _distraction;
    public NPCHealth Health => _health;
    public NPCCheck Check => _check;

    public bool IsTarget { get; private set; }

    private void Start()
    {
        SetNPCTargetOrNot();
    }

    private void OnEnable()
    {
        NPCHealth.OnAllHPLost += CheckTargetBeforeNPCSwitch;
        NPCDistraction.OnFullDistraction += CheckTargetBeforeNPCSwitch;
    }

    private void OnDisable()
    {
        NPCHealth.OnAllHPLost -= CheckTargetBeforeNPCSwitch;
        NPCDistraction.OnFullDistraction -= CheckTargetBeforeNPCSwitch;
    }

    public void SetNpcSprite(Sprite sprite)
    {
        _npcImage.sprite = sprite;
    }

    private void SetNPCTargetOrNot()
    {
        int r = Random.Range(0, 3);

        if (r == 0)
        {
            IsTarget = true;
        }

    }

    private void CheckTargetBeforeNPCSwitch()
    {
        if (IsTarget)
            Debug.Log("It was target!");

        else
            Debug.Log("It was wrong person..");

    }
}
