using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 moveVector;
    [SerializeField] [Range(0,1)] float moveFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    { 
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;

        const float tao = Mathf.PI * 2;

        float rawSine = Mathf.Sin(cycles * tao);

        moveFactor = (rawSine + 1f) / 2f; 

        Vector3 offset = moveVector * moveFactor;
        transform.position = startPos + offset;
    }
}
