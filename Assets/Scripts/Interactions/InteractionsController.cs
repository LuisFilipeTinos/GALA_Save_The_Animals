using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionsController : MonoBehaviour
{
    private bool canTalk;
    public bool isTalking = false;
    public bool canPressF = true;

    private bool tucanoBool;
    private bool oncaBool;
    private bool sucuriBool;
    private bool checkOncaBool;
    private bool checkTucanoBool;
    private bool checkSucuriBool;

    //********CORE SCENE*********
    [SerializeField] DialogueObject tucanoDialogue;
    [SerializeField] DialogueObject oncaDialogue;
    [SerializeField] DialogueObject sucuriDialogue;
    [SerializeField] DialogueObject checkPointTucanoDialogue;
    [SerializeField] DialogueObject checkPointOncaDialogue;
    [SerializeField] DialogueObject checkPointSucuriDialogue;

    [SerializeField] DialogueImage tucanoImage;
    [SerializeField] DialogueImage oncaImage;
    [SerializeField] DialogueImage sucuriImage;
    [SerializeField] DialogueImage araraImage;

    [SerializeField] GameObject tucanoCage;
    [SerializeField] GameObject oncaCage;
    [SerializeField] GameObject sucuriCage;

    [SerializeField] GameObject tucano;
    [SerializeField] GameObject sucuri;
    [SerializeField] GameObject onca;

    GameObject[] greenHunters;
    GameObject[] redHunters;
    GameObject[] yellowHunters;

    [SerializeField] GameManager gm;  //Implementar lógica para diminuir o numero de animais;

    [SerializeField] FadeTestMusic fadeTest;

    public static InteractionsController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        greenHunters = GameObject.FindGameObjectsWithTag("EnemyGreen");
        redHunters = GameObject.FindGameObjectsWithTag("EnemyRed");
        yellowHunters = GameObject.FindGameObjectsWithTag("EnemyYellow");

    }

    void Update()
    {
        //CORE SCENE DIALOGUE
        if (canTalk == true && canPressF == true && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.RightControl)))
        {
            if (tucanoBool == true)
            {
                if (tucanoCage != null)
                {
                    Destroy(tucanoCage.gameObject);

                    for (int i = 0; i < redHunters.Length; i++)
                    {
                        Destroy(redHunters[i]);
                    }

                    gm.numberOfAnimals--;
                    gm.textAnimalCount.text = gm.numberOfAnimals.ToString();
                }
                else
                {
                    PlayFadeOut();
                    DialogueManager.Instance.NextSentence(tucanoDialogue, tucanoImage);
                }
            }
            else if (oncaBool == true)
            {
                if (oncaCage != null)
                {
                    Destroy(oncaCage.gameObject);

                    for (int i = 0; i < greenHunters.Length; i++)
                    {
                        Destroy(greenHunters[i]);
                    }

                    gm.numberOfAnimals--;
                    gm.textAnimalCount.text = gm.numberOfAnimals.ToString();

                }
                else
                {
                    PlayFadeOut();
                    DialogueManager.Instance.NextSentence(oncaDialogue, oncaImage);
                }
            }
            else if (sucuriBool == true)
            {            
                if (sucuriCage != null)
                {
                    Destroy(sucuriCage.gameObject);

                    for (int i = 0; i < yellowHunters.Length; i++)
                    {
                        Destroy(yellowHunters[i]);
                    }

                    gm.numberOfAnimals--;
                    gm.textAnimalCount.text = gm.numberOfAnimals.ToString();
                }
                else
                {
                    PlayFadeOut();
                    DialogueManager.Instance.NextSentence(sucuriDialogue, sucuriImage);
                }
            }
            else if (checkOncaBool == true)
            {
                PlayFadeOut();
                DialogueManager.Instance.NextSentence(checkPointOncaDialogue, araraImage);
            }
            else if (checkSucuriBool == true)
            {
                PlayFadeOut();
                DialogueManager.Instance.NextSentence(checkPointSucuriDialogue, araraImage);
            }
            else if (checkTucanoBool == true)
            {
                PlayFadeOut();
                DialogueManager.Instance.NextSentence(checkPointTucanoDialogue, araraImage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canTalk = true;

        if (other.gameObject.CompareTag("Tucano"))
        {
            tucanoBool = true;
        }
        else if (other.gameObject.CompareTag("Onca"))
        {
            oncaBool = true;
        }
        else if (other.gameObject.CompareTag("Sucuri"))
        {
            sucuriBool = true;
        }
        else if (other.gameObject.CompareTag("CheckOnca"))
        {
            checkOncaBool = true;
        }
        else if (other.gameObject.CompareTag("CheckSucuri"))
        {
            checkSucuriBool = true;
        }
        else if (other.gameObject.CompareTag("CheckTucano"))
        {
            checkTucanoBool = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        canTalk = false;

        if (other.gameObject.CompareTag("Tucano"))
        {
            tucanoBool = false;
        }
        else if (other.gameObject.CompareTag("Onca"))
        {
            oncaBool = false;
        }
        else if (other.gameObject.CompareTag("Sucuri"))
        {
            sucuriBool = false;
        }
        else if (other.gameObject.CompareTag("CheckOnca"))
        {
            checkOncaBool = false;
        }
        else if (other.gameObject.CompareTag("CheckSucuri"))
        {
            checkSucuriBool = false;
        }
        else if (other.gameObject.CompareTag("CheckTucano"))
        {
            checkTucanoBool = false;
        }
    }

    private void PlayFadeOut()
    {
        if (fadeTest.canFadeIn == false)
        {
            StartCoroutine(fadeTest.FadeOut());
            fadeTest.canFadeIn = true;
        }
    }
}
