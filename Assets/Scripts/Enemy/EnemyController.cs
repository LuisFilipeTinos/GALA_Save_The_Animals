using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float changeTime;

    private void Start()
    {
        if (this.gameObject.CompareTag("EnemyRed"))
        {
            changeTime = 2f;
            StartCoroutine(TurningDirectionRed());
        }
        else if (this.gameObject.CompareTag("EnemyGreen"))
        {
            changeTime = 5f;
            StartCoroutine(TurningDirectionGreen());
        }
        else if (this.gameObject.CompareTag("EnemyYellow"))
        {
            changeTime = 4f;
            StartCoroutine(TurningDirectionYellow());
        }     
    }

    IEnumerator TurningDirectionRed()
    {
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        yield return new WaitForSeconds(changeTime);
        StartCoroutine(TurningDirectionRed());
    }

    IEnumerator TurningDirectionGreen()
    {
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        yield return new WaitForSeconds(changeTime);
        StartCoroutine(TurningDirectionGreen());
    }

    IEnumerator TurningDirectionYellow()
    {
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        yield return new WaitForSeconds(changeTime);
        StartCoroutine(TurningDirectionYellow());
    }
}
