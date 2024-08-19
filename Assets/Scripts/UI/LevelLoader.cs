using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    public Animator anim;

    private float transitionTime = 0.7f;

    void Start()
    {
        Instance = this;
    }

    public IEnumerator LoadLevel(int index)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }

}
