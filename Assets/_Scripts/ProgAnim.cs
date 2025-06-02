using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgAnim : MonoBehaviour
{
    public GameObject target;
    public float speed = 10f;
    void Update()
    {
        target.transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
