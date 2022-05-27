using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTrigger : MonoBehaviour
{
    public Transform egg;
    private GameObject claw;

    void OnTriggerEnter(Collider other)
    {
        this.transform.parent = other.transform;
    }
}
