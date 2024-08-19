using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = new Vector3(cameraObj.transform.eulerAngles.x,
            cameraObj.transform.eulerAngles.y, 0.0f);
    }
}
