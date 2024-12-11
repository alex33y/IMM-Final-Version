using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;

using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRB;
    private Camera cam;
    public float speed;
    public float rotationSpeed;
    private bool canMove = false;
    public GameObject Bullet;
    public float bulletSpeed;
    public AudioClip shootSound;
    private AudioSource shootSoundSource;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerRB = GetComponent<Rigidbody>();
        shootSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true){
            PlayerMovement();
            RotatePlayer();
            FireBullet();
        }
        
    }

    public void EnableMovement(){
        canMove = true;
    }

    public void DisableMovement(){
        canMove = false;
    }

    // Handle player movement
    void PlayerMovement()
    {
        // Forward and Backward movement
        float upDown = Input.GetAxis("Vertical");
        // Lateral movement (side to side)
        float leftRight = Input.GetAxis("Horizontal");

        // Get the camera's forward and side direction
        Vector3 camUpDownDirection = Camera.main.transform.up;
        Vector3 camLeftRightDirection = Camera.main.transform.right;

        // Move player
        Vector3 movement = upDown * camUpDownDirection + leftRight * camLeftRightDirection;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void RotatePlayer() // certain lines learned from youtube (will link video in word doc - Colin)
    {
        // Get the mouse pos in the game world and make it level with the player
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
        mousePosition.y = transform.position.y;
        // LookRotation method - youtube
        playerRB.transform.rotation = Quaternion.LookRotation(mousePosition - transform.position, Vector3.up);
    }

    void FireBullet(){

        if (Input.GetKeyDown(KeyCode.Mouse0)){
            // Make bullet spawn in front of player
            Vector3 bulletSpawn = transform.position + transform.forward * 1.5f; 
            GameObject newBullet = Instantiate(Bullet, bulletSpawn, transform.rotation);
            // make bullet go woosh
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = transform.forward * bulletSpeed;
            // Make bullet noise
            shootSoundSource.PlayOneShot(shootSound);            
        }
    }
}
        








