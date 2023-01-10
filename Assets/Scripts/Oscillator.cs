using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPos;
    Vector3 offset;
    float moveFactor;

    float period;

    Vector3 moveVector;
    // [SerializeField] float period = 2f;
    [SerializeField] float periodMin = 10f;
    [SerializeField] float periodMax = 50f;
    // Start is called before the first frame update
    void Start()
    { 
        period = GetRandomPeriod(periodMin,periodMax);
        Debug.Log(period);
        moveVector = GetRandomVector();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; //continually growing over time

        const float tao = Mathf.PI * 2; // 6.23 amount of radians in a perfect circle

        float rawSine = Mathf.Sin(cycles * tao); //Oscillating from -1 to 1

        moveFactor = (rawSine + 1f) / 2f; //recalculated to go from 0 to 1

        Vector3 offset = moveVector * moveFactor;

        transform.position = startPos + offset;
    }

    float GetRandomPeriod(float max, float min){
        return Random.Range(min,max);
    }
    private Vector3 GetRandomVector(){
        float randomX = Random.Range(-20,20);
        float randomY = Random.Range(-20,20);
        return new Vector3 (randomX,randomY,0f);
    }

}
