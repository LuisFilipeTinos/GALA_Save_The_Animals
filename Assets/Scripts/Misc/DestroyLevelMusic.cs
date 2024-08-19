using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelMusic : MonoBehaviour
{
    GameObject song;
    private void Awake()
    {
        song = GameObject.FindGameObjectWithTag("LevelMusic");
    }

    void Start()
    {
        if (song != null)
            Destroy(song.gameObject);
    }
}
