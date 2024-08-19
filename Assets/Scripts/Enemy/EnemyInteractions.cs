using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (this.gameObject.tag == "EnemyRed")
            respawnPoint = GameObject.FindGameObjectWithTag("RespawnTucano");
        else if (this.gameObject.tag == "EnemyYellow")
            respawnPoint = GameObject.FindGameObjectWithTag("RespawnSucuri");
        else if (this.gameObject.tag == "EnemyGreen")
            respawnPoint = GameObject.FindGameObjectWithTag("RespawnOnca");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu do jogador");
        }
    }
}
