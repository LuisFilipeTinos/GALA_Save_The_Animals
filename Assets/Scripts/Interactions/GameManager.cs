using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] animals;

    public int numberOfAnimals;

    private bool canEnableColl;

    [SerializeField] BoxCollider bigTreeColl;

    public TextMeshProUGUI textAnimalCount;

    void Start()
    {
        bigTreeColl.enabled = false;
        canEnableColl = true;
        GetNumberOfAnimals();
        Debug.Log(numberOfAnimals);
        textAnimalCount.text = numberOfAnimals.ToString();
    }

    private void Update()
    {    
        WonTheGame();
    }

    private int GetNumberOfAnimals()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            numberOfAnimals++;
        }

        return numberOfAnimals;
    }

    private void WonTheGame()
    {
        if (numberOfAnimals <= 0 && canEnableColl)
        {
            bigTreeColl.enabled = true;
            bigTreeColl.isTrigger = true;
        }
    }

    
}
