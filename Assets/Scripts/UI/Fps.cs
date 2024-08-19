using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fps : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textFps;
    float deltaTimeFloat;
    float fps;

    void Update()
    {
        deltaTimeFloat += (Time.deltaTime - deltaTimeFloat) * 0.1f;
        fps = 1.0f / deltaTimeFloat;
        textFps.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }
}
