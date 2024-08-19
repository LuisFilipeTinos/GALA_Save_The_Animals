using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadScroll : MonoBehaviour
{
    RawImage raw;
    public float speed;

    private void Start()
    {
        raw = GetComponent<RawImage>();
    }

    void Update()
    {
        raw.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
