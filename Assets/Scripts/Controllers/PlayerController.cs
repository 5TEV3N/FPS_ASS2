﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;

    [Header ("Values")]
    public float mouseSensitivity = 1;              // Mouse sensitivity
    public float playerSpeed = 1;                   // We can controll the speed of the player here.
    public float upDownRange = 90.0f;               // How far i can look up or down.
    public float bulletShootingForce = 10f;         // Force of bullet

    [Header ("Containers")]
    public Rigidbody rb;                            // Access the rigidbody to move
    public Camera cam;                              // Acess the Camera of the gameobject
    public GameObject bullets;                      // Contains the bullet prefab                                                   
    public Transform bulletExitPoint;               // Contains the transform of where the bullet is exiting
    public Transform bulletsParent;                 // Bullet will be placed in the BulletsSpawned as a child

    private float verticalRotation = 0;             // Contains the MouseYAxis
    private Vector3 shootingDirection;              // Where the bullet is shooting towards

    private RaycastHit hit;                          // Gets info from the raycast
    private Ray ray;                                 // Ray that gathers info
    private Vector3 rayOrigin;                       // Position of ray 

    void Awake()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
    }

    void Update()
    {
        rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.Raycast(ray, out hit, 1000f);
        Debug.DrawRay(rayOrigin, ray.direction * 1000f, Color.green);
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            gameObject.transform.Rotate(new Vector3(0, mouseXAxis, 0));                     // Rotate gameObject left or right
            
        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;                // Rotates the gameobject up and down.
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);    // Clamp the camera from moving up and down. Argument = float Value, float minimum val, float max minimum val
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);         // Idk.
        } 
    }

    public void PlayerMove(float xAxis, float zAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                //positive x = Right
                rb.AddForce(transform.right * playerSpeed);
            }

            if (xAxis < 0)
            {
                rb.AddForce(-transform.right * playerSpeed);
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                //positive z = Forward
                rb.AddForce(transform.forward * playerSpeed);
            }

            if (zAxis < 0)
            {
                rb.AddForce(-transform.forward * playerSpeed);
            }
        }

    }

    public void PlayerShoot()
    {
        print("Shoot");
        bullets = GameObject.Instantiate(bullets, bulletsParent) as GameObject;
        bullets.name = "Bullet";
        bullets.transform.position = bulletExitPoint.transform.position;

        Vector3 bulletDirection = ((ray.GetPoint(1000f)) - bullets.transform.position).normalized;
        //credits too http://stackoverflow.com/questions/33018808/unity-shooting-at-your-crosshair-even-if-there-is-no-ray-hit

        bullets.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletShootingForce, ForceMode.Impulse);
    }
}

/*
bullets = GameObject.Instantiate(bullets, bulletsParent) as GameObject;
bullets.name = "Bullet";
bullets.transform.position = bulletExitPoint.transform.position;

shootingDirection = bullets.transform.position;
bullets.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletShootingForce, ForceMode.Impulse);
*/
