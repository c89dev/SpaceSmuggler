using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapBounds : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player bounds reached.");
        }
    }
}
