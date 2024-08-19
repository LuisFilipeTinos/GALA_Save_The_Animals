using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalInteraction : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LevelLoader.Instance.LoadLevel(3));
        }
    }
}
