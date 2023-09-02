using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{

    [SerializeField] private float speed = 100000f;
    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, 360*speed*Time.deltaTime);
    }
}
