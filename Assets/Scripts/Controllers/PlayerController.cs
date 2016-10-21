using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;
    AmmoManager ammoManager;

    [Header("Values")]
    public int playerHP;                            // Health of player
    public float mouseSensitivity = 1;              // Mouse sensitivity
    public float playerSpeed = 1;                   // We can controll the speed of the player here.
    public float upDownRange = 90.0f;               // How far i can look up or down.
    public float bulletShootingForce = 10f;         // Force of bullet
    public float valOfVelocity;                     // Checks how fast the player goes
    public float maxVelocity;                       // The max speed of how fast the player goes

    [Header ("Containers")]
    public Rigidbody rb;                            // Access the rigidbody to move
    public Camera cam;                              // Acess the Camera of the gameobject       
    public GameObject bullets;                      // Contains the bullet prefab                                        
    public Transform bulletExitPoint;               // Contains the transform of where the bullet is exiting
    public Transform bulletsParent;                 // Bullet will be placed in the BulletsSpawned as a child

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
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;

        rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayOrigin, ray.direction * 1000f, Color.green);
        //Physics.Raycast(ray, out hit, 1000f);
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

            print("Shoot");
            bulletsShot = GameObject.Instantiate(bullets, bulletsParent) as GameObject;
            bulletsShot.name = "Bullet";
            bulletsShot.transform.position = bulletExitPoint.transform.position;

            Vector3 bulletDirection = ((ray.GetPoint(1000f)) - bulletsShot.transform.position).normalized;
            //credits too http://stackoverflow.com/questions/33018808/unity-shooting-at-your-crosshair-even-if-there-is-no-ray-hit

            bulletsShot.GetComponent<Rigidbody>().AddForce(bulletDirection * bulletShootingForce, ForceMode.Impulse);
        }

        if (ammoManager.ammoLeft == 0)
        {
            print("Can't shoot");
        }
    }
}
