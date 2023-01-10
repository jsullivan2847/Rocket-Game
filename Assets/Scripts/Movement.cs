using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem rightEngine;


    Rigidbody rb;
    AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPropel();
        ProcessPoint();
    }

    void ProcessPropel()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Propel();
        }
        else
        {
            StopPropel();
        }
    }

    void ProcessPoint()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotate();
        }
    }

    private void StopPropel()
    {
        sound.Stop();
        mainEngine.Stop();
    }

    private void Propel()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!sound.isPlaying)
        {
            sound.PlayOneShot(mainEngineSound);
        }
        mainEngine.Play();
    }

    private void StopRotate()
    {
        leftEngine.Stop();
        rightEngine.Stop();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        rightEngine.Play();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        leftEngine.Play();
    }

    void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime, Space.World);
        rb.freezeRotation = false;
    }
}
