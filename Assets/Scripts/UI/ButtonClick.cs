using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] EscPannel escPannel;
    [SerializeField] GameObject aboutMenu;

    [SerializeField] FadeTestMusic fadeMusic;

    public AudioSource generalBtnAudio;
    public AudioSource startBtnAudio;

    public AudioClip start;
    public AudioClip general;

    private void Start()
    {
        generalBtnAudio.clip = general;
        startBtnAudio.clip = start;
    }

    public void StartGame()
    {
        StartCoroutine(LevelLoader.Instance.LoadLevel(1));
        startBtnAudio.Play();
        //SceneManager.LoadScene(2);
    }

    public void AboutMenu()
    {
        aboutMenu.SetActive(true);
        generalBtnAudio.Play();
        //SceneManager.LoadScene(1);
    }

    public void BackFromAbout()
    {
        aboutMenu.SetActive(false);
        generalBtnAudio.Play();
    }

    public async void IntroScreenStart()
    {
        StartCoroutine(LevelLoader.Instance.LoadLevel(2));
        startBtnAudio.Play();
        await fadeMusic.FadeToZero();
    }

    public void BackToGameFromPause()
    {
        escPannel.CloseCanvas();
        generalBtnAudio.Play();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public async void ToMainMenu()
    {
        StartCoroutine(LevelLoader.Instance.LoadLevel(0));
        startBtnAudio.Play();
        await fadeMusic.FadeToZero();
    }
}
