using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTestMusic : MonoBehaviour
{
    public AudioSource song;
    float fadeSpeed = 0.055f;
    public bool canFadeIn;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            song = GameObject.FindGameObjectWithTag("MainMusic").GetComponent<AudioSource>();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            song = GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>();
    }

    public IEnumerator FadeOut()
    {
        while (song.volume > 0.08f)
        {
            song.volume -= fadeSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator FadeIn()
    {
        while(song.volume < 0.3f)
        {
            song.volume += fadeSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public async Task FadeToZero()
    {
        while(song.volume > 0.00f)
        {
            song.volume -= fadeSpeed;
            await Task.Delay(90);
        }

        await Task.Yield();
    }
}
