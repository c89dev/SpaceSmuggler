using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("BoostItem"))
        {
            Destroy(other.gameObject);
        }
    }
}
