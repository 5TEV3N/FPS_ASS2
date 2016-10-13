using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 1;    //Mouse sensitivity
    public float playerSpeed = 1;   //We can controll the speed of the player here.
    public Rigidbody rb;    //Access the rigidbody to move
    public Camera cam;  //Acess the Camera of the gameobject
    public float upDownRange = 90.0f;   //How far i can look up or down.

    private float verticalRotation = 0;

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            gameObject.transform.Rotate(new Vector3(0, mouseXAxis, 0)); //Rotate gameObject left or right
            
        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;    //Rotates the gameobject up and down.
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);    //Clamp the camera from moving up and down. Argument = float Value, float minimum val, float max minimum val
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); //Idk.
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
}