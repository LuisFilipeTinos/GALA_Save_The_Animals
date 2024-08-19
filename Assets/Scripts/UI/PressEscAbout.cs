using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEscAbout : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.activeSelf == true)
            if (Input.GetKeyDown(KeyCode.Escape))
                this.gameObject.SetActive(false);
    }
}
