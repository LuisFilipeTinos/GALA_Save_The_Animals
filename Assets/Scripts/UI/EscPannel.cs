using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscPannel : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public bool isCanvasOpen;

    void Start()
    {
        canvas.SetActive(false);
        isCanvasOpen = false;
    }

    void Update()
    {
        OpenCloseCanvas();
    }

    private void OpenCloseCanvas()
    {
        if (isCanvasOpen == false)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && InteractionsController.Instance.isTalking == false)
            {
                OpenCanvas();
            }

        }
        else if (isCanvasOpen == true)
        {

            if (Input.GetKeyUp(KeyCode.Escape) && InteractionsController.Instance.isTalking == false)
            {
                CloseCanvas();
            }
        }
    }

    public void CloseCanvas()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCanvasOpen = false;
        canvas.SetActive(false);
    }

    private void OpenCanvas()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCanvasOpen = true;
        canvas.SetActive(true);
    }


}
