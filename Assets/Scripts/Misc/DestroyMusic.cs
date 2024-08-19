using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMusic : MonoBehaviour
{
    GameObject song;
    private void Awake()
    {
       song = GameObject.FindGameObjectWithTag("MainMusic");
    }
    void Start()
    {
        if (song != null)
            Destroy(song.gameObject);
    }
}
