﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;
    AmmoManager ammoManager;
    CameraShake2D cameraShake2D;

    [Header("Values")]
    public float mouseSensitivity = 1;              // Mouse sensitivity
    public float playerSpeed = 1;                   // We can controll the speed of the player here.
    public float upDownRange = 90.0f;               // How far i can look up or down.
    public float bulletShootingForce = 10f;         // Force of bullet
    public float valOfVelocity;                     // Checks how fast the player goes
    public float maxVelocity;                       // The max speed of how fast the player goes

    public float shakeCamDuration;                  // Self explanatory
    public float shakeCamAmplitude;                 // Self explanatory
    public float shakeCamDecay;                     // Self explanatory

    [Header ("Containers")]
    public Rigidbody rb;                            // Access the rigidbody to move
    public Camera cam;                              // Acess the Camera of the gameobject       
    public GameObject bullets;                      // Contains the bullet prefab                                        
    public Transform bulletExitPoint;               // Contains the transform of where the bullet is exiting
    public Transform bulletsParent;                 // Bullet will be placed in the BulletsSpawned as a child
    public AudioSource hurtSound;                   // Contains the audiosound for the player getting hurt
    public AudioSource pewSound;                    // Contains the audiosound for the gun noise

    private float verticalRotation = 0;             // Contains the MouseYAxis
    private Vector3 shootingDirection;              // Where the bullet is shooting towards    
    private GameObject bulletsShot;                 // Instantiate the bullet prefab

    private RaycastHit hit;                         // Gets info from the raycast
    private Ray ray;                                // Ray that gathers info
    private Vector3 rayOrigin;                      // Position of ray 

    void Awake()
    {   
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        ammoManager = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoManager>();
        cameraShake2D = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraShake2D>();
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;

        rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayOrigin, ray.direction * 1000f, Color.gray);
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            gameObject.transform.Rotate(new Vector3(0, mouseXAxis, 0));      
        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;               
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);   
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);        
        } 
    }

    public void PlayerMove(float xAxis, float zAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.right * playerSpeed);
                }
            }

            if (xAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed);
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.forward * playerSpeed);
                }
            }

            if (zAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * playerSpeed);
                }
            }
        }

    }

    public void PlayerShoot()
    {
        if (ammoManager.ammoLeft != 0 )
        {
            ammoManager.ammoLeft--;
            bulletsShot = GameObject.Instantiate(bullets, bulletsParent) as GameObject;
            bulletsShot.name = "Bullet";
            bulletsShot.transform.position = bulletExitPoint.transform.position;

            Vector3 bulletDirection = ((ray.GetPoint(1000f)) - bulletsShot.transform.position).normalized;                  //credits too http://stackoverflow.com/questions/33018808/unity-shooting-at-your-crosshair-even-if-there-is-no-ray-hit

            bulletsShot.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletShootingForce, ForceMode.Impulse);

            pewSound.Play();
        }
    }

    public void PlayerHurt()
    {
        hurtSound.Play();
        cameraShake2D.ShakeCamera(shakeCamDuration, shakeCamAmplitude, shakeCamDecay);
    }
}
