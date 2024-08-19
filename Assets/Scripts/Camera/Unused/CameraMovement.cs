using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float headHeight = 0.4f;

    [SerializeField]
    GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");

        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + headHeight, player.transform.position.z);

        
    }
}
