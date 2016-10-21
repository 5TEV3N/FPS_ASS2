using UnityEngine;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
    public int ammo;        // Ammo you start with
    public int ammoLeft;    // Ammo you have left
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Reloading...");
            ammoLeft = ammo;
        }
    }
}