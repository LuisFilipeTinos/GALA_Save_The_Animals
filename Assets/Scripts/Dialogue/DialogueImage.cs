using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Dialogue/Dialogue Image")]

public class DialogueImage : ScriptableObject
{
    [SerializeField]
    private Sprite mugshot;

    public Sprite Mugshot
    {
        get { return mugshot; }
    }
}
