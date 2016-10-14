using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    //This scripts deletes the bullet after x amount of time

    public float timeBeforeDeath;   //  Time before it destroys itself
    public float intialTime;        //  Self explanatory

    void Start()
    {
        intialTime = Time.time;
    }

    void Update()
    {
        if (Time.time > intialTime + timeBeforeDeath)
        {
        }
    }
}
