using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
    public int ammo;                // Ammo you start with
    public int ammoLeft;            // Ammo you have left
    public Text uiAmmo;             //
    public Text uiAmmoBackdrop;     //

    void Update()
    {
        uiAmmo.text = ammoLeft + " | " + ammo;
        uiAmmoBackdrop.text = uiAmmo.text;

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Reloading...");
            ammoLeft = ammo;
        }
    }
}