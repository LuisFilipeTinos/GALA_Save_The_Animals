using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI npcName;

    [SerializeField]
    private TextMeshProUGUI dialogue;

    [SerializeField]
    private Image mugshot;

    [SerializeField]
    private float dialogSpeed;

    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    GameObject dialogueImageBox;

    [SerializeField]
    GameObject dialogueFade;

    public int index = 0;

    public Animator animDialogueBox;
    public Animator animImageBox;
    public Animator animFadeDialogue;

    [SerializeField] FadeTestMusic fadeTest;

    public static DialogueManager Instance;

    private void Start()
    {
        Instance = this;
        CloseDialogueBox();
        CloseDialogueImage();
        CloseDialogueFade();
    }

    public void NextSentence(DialogueObject dialogueObject, DialogueImage dialogueImage)
    {
        if(index <= dialogueObject.Dialogue.Length - 1)
        {
            dialogueBox.SetActive(true);
            dialogueImageBox.SetActive(true);
            dialogueFade.SetActive(true);
            dialogue.text = string.Empty;
            npcName.text = string.Empty;
            StartCoroutine(WriteSentence(dialogueObject, dialogueImage));
        }
        else
        {
            if (InteractionsController.Instance != null)
                InteractionsController.Instance.canPressF = false;
            else if (IntroDialogue.Instance != null)
            {
                IntroDialogue.Instance.canPressFIntro = false;
                IntroDialogue.Instance.PressFText.SetActive(false);
                IntroDialogue.Instance.showUIBtns = true;
            }
            else if (FinalDialogue.Instance != null)
            {
                FinalDialogue.Instance.canPressFFinal = false;
                FinalDialogue.Instance.pressFText.SetActive(false);
                FinalDialogue.Instance.showUIFinalBtns = true;
            }


            animDialogueBox.SetTrigger("Exit");
            animImageBox.SetTrigger("ExitImage");
            animFadeDialogue.SetTrigger("Exit");
            StartCoroutine(fadeTest.FadeIn());
            fadeTest.canFadeIn = false;
            Invoke("CloseDialogueBox", 1f);
            Invoke("CloseDialogueImage", .5f);
            Invoke("CloseDialogueFade", .4f);
        }
    }

    private IEnumerator WriteSentence(DialogueObject dialogueObject, DialogueImage dialogueImage)
    {
        npcName.text = dialogueObject.NpcName;
        this.mugshot.sprite = dialogueImage.Mugshot;

        if (InteractionsController.Instance != null)
        {
            InteractionsController.Instance.canPressF = false;
            InteractionsController.Instance.isTalking = true;
        }
        else if (IntroDialogue.Instance != null)
        {
            IntroDialogue.Instance.canPressFIntro = false;
            IntroDialogue.Instance.PressFText.SetActive(false);
        }
        else if (FinalDialogue.Instance != null)
        {
            FinalDialogue.Instance.canPressFFinal = false;
            FinalDialogue.Instance.pressFText.SetActive(false);
        }


        foreach (char character in dialogueObject.Dialogue[index].ToCharArray())
        {
            dialogue.text += character;
            yield return new WaitForSeconds(dialogSpeed);
        }
        index++;

        if (InteractionsController.Instance != null)
            InteractionsController.Instance.canPressF = true;
        else if (IntroDialogue.Instance != null)
        {
            IntroDialogue.Instance.canPressFIntro = true;
            IntroDialogue.Instance.PressFText.SetActive(true);
        }
        else if (FinalDialogue.Instance != null)
        {
            FinalDialogue.Instance.canPressFFinal = true;
            FinalDialogue.Instance.pressFText.SetActive(true);
        }

    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        dialogue.text = string.Empty;
        npcName.text = string.Empty;
        index = 0;
        if (InteractionsController.Instance != null)
        {
            InteractionsController.Instance.isTalking = false;
            InteractionsController.Instance.canPressF = true;
        }
        else if (IntroDialogue.Instance != null)
        {
            IntroDialogue.Instance.canPressFIntro = true;
        }
    }

    private void CloseDialogueImage()
    {
        dialogueImageBox.SetActive(false);
    }

    private void CloseDialogueFade()
    {
        dialogueFade.SetActive(false);
    }
}
