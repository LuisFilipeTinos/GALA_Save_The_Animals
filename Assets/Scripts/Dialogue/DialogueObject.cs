using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]

public class DialogueObject : ScriptableObject
{
    [SerializeField]
    private string npcName;

    [SerializeField]
    [TextArea(1, 5)]
    private string[] dialogue;

    public string NpcName
    {
        get { return npcName; }
    }

    public string[] Dialogue
    {
        get { return dialogue; }
    }
}
