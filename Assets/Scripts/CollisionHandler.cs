using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem success;
    AudioSource sound;
    bool isTransitioning = false;
    public bool collisionDisabled = false;
    void OnCollisionEnter(Collision other)
    {
        sound = GetComponent<AudioSource>();

        if(isTransitioning || collisionDisabled) return;

            switch (other.gameObject.tag)
            {
                case
               "Finish":
                    StartSuccess();
                    break;
                case
               "Friendly":
                    // Debug.Log("Friendly");
                    break;
                case
               "Fuel":
                    // Debug.Log("Fuel");
                    break;
                default:
                    StartCrash();
                    break;
        }
    }

    void StartSuccess()
    {
        isTransitioning = true;
        success.Play();
        sound.Stop();
        sound.PlayOneShot(successSound);
        Movement movement = GetComponent<Movement>();
        movement.enabled = false;
        StartCoroutine(WaitAndLoad(0.7f, 1));
    }

    void StartCrash()
    {
        isTransitioning = true;
        explosion.Play();
        sound.Stop(); 
        sound.PlayOneShot(crashSound, 0.5f);
        Movement movement = GetComponent<Movement>();
        movement.enabled = false;
        StartCoroutine(WaitAndLoad(0.7f, 0));
    }
    public void ReloadScene(int mod)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene + mod == SceneManager.sceneCountInBuildSettings)
        {
            currentScene = 0;
            mod = 0;
        }
        SceneManager.LoadScene(currentScene + mod);
    }

    IEnumerator WaitAndLoad(float waitTime, int mod)
    {
        yield return new WaitForSeconds(waitTime);
        ReloadScene(mod);
    }

}


