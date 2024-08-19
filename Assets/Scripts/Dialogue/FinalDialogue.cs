using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDialogue : MonoBehaviour
{
    //******ENDING DIALOGUE********
    [SerializeField] DialogueImage araraDialogueImage;
    [SerializeField] DialogueObject araraFinalDialogue;

    public bool canPressFFinal;

    [SerializeField] GameObject finalText;

    public GameObject pressFText;

    public bool showUIFinalBtns;

    [SerializeField] FadeTestMusic fadeTest;

    public static FinalDialogue Instance;

    [SerializeField] GameObject thankYouText;
    [SerializeField] GameObject menuBtn;
    [SerializeField] GameObject quitBtn;

    void Start()
    {
        Instance = this;
        canPressFFinal = true;
        showUIFinalBtns = false;
        pressFText.SetActive(true);
        thankYouText.SetActive(false);
        menuBtn.SetActive(false);
        quitBtn.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (showUIFinalBtns)
                Invoke("ShowFinalButtons", 1f);

            if ((Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.RightControl)) && canPressFFinal)
            {
                if (finalText != null)
                    Destroy(finalText.gameObject);

                StartCoroutine(fadeTest.FadeOut());
                DialogueManager.Instance.NextSentence(araraFinalDialogue, araraDialogueImage);
            }
        }
    }

    private void ShowFinalButtons()
    {
        thankYouText.SetActive(true);
        menuBtn.SetActive(true);
        quitBtn.SetActive(true);
    }
}
