using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{

    //*******INTRO*******
    [SerializeField] DialogueObject araraIntroDialogue;
    [SerializeField] DialogueImage araraDialogueImage;

    [SerializeField] Animator animIntroText;

    public bool canPressFIntro;

    public bool showUIBtns;

    [SerializeField] GameObject introText;

    public GameObject PressFText;

    [SerializeField] GameObject beginBtn;
    [SerializeField] GameObject repeatText;

    [SerializeField] FadeTestMusic fadeTest;

    public static IntroDialogue Instance;

    private void Start()
    {
        beginBtn.SetActive(false);
        repeatText.SetActive(false);
        showUIBtns = false;
        PressFText.SetActive(true);
        Instance = this;
        canPressFIntro = true;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)  //INTRO DIALOGUE
        {
            if (showUIBtns)
            {
                Invoke("ShowButtons", 1f);
            }

            if (!showUIBtns)
            {
                HideButtons();
            }

            if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.RightControl)) && canPressFIntro)
            {
                if (introText != null)
                    Destroy(introText.gameObject);

                StartCoroutine(fadeTest.FadeOut());
                DialogueManager.Instance.NextSentence(araraIntroDialogue, araraDialogueImage);

            }
        }
    }

    private void ShowButtons()
    {
        beginBtn.SetActive(true);
        repeatText.SetActive(true);
    }

    private void HideButtons()
    {
        beginBtn.SetActive(false);
        repeatText.SetActive(false);
    }
}
