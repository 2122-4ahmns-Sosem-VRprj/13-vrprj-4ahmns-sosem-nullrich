using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{
    public GameObject Ausgang;
    private void OnTriggerEnter(Collider other)
    {
        ScoreTextScript.eggAmount += 1;
        if (ScoreTextScript.eggAmount == 5)
        {
            Ausgang.SetActive(true);
        }
        Destroy(other.gameObject);

        
    }
}
