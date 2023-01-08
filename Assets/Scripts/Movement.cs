using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust =  100f;
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
        Propel();
        Point();
    }

    void Propel(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!sound.isPlaying){
                sound.PlayOneShot(mainEngineSound);
            }
            mainEngine.Play();
        }
        else{
            sound.Stop();
            mainEngine.Stop();
        }
    }

    void Point(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            leftEngine.Play();
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
            rightEngine.Play();
        }
        else{
            leftEngine.Stop();
            rightEngine.Stop();
        }
    }

    void ApplyRotation ( float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime, Space.World);
        rb.freezeRotation = false;
    }
}
