using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevControls : MonoBehaviour
{
    Scene currentScene;
    public CollisionHandler collision;
    public MonoBehaviour movement;
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
        if(Input.GetKey(KeyCode.L)){
            collision.ReloadScene(1);
        }
        else if(Input.GetKey(KeyCode.C)){
            collision.collisionDisabled = !collision.collisionDisabled;
        }
    }
}
