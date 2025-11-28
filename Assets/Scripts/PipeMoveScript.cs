using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private float movespeed=5;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * movespeed * Time.deltaTime;
    }
}
