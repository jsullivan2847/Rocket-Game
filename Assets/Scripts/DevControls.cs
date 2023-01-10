using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevControls : MonoBehaviour
{
    Scene currentScene;
    public CollisionHandler collision;
    public MonoBehaviour movement;
    [SerializeField] bool collisionDisabled;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(currentScene);
        CollisionHandler collision = this.GetComponent<CollisionHandler>();
        // Debug.Log(collision);
    }

    // Update is called once per frame
    void Update()
    {
        if(collisionDisabled){
            collision.collisionDisabled = true;
        }
        else if(!collisionDisabled){
            collision.collisionDisabled = false;
        }
        if(Input.GetKey(KeyCode.L)){
            collision.ReloadScene(1);
        }
        else if(Input.GetKey(KeyCode.C)){
            collisionDisabled = !collisionDisabled;
        }
    }
}
