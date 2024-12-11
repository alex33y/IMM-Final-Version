using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float camRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera(){
        // Rotate the camera left
        if(Input.GetKeyDown(KeyCode.Q)){
        transform.Rotate(Vector3.forward, -90);
        }

        // Rotate the camera right
        if(Input.GetKeyDown(KeyCode.E)){
        transform.Rotate(Vector3.back, + 90 );
        }
    }
}
