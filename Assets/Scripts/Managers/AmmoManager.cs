using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
    public int ammo;                      // Ammo you start with
    public int ammoLeft;                  // Ammo you have left

    public Text uiAmmo;                   // Container for the ammo text from the ui
    public Text uiAmmoBackdrop;           // Same as above
    public GameObject uiNoAmmo;           // Container for the No ammo text from the ui
    public GameObject uiNoAmmoBackdrop;   // Again, same as above

    void Update()
    {
        uiAmmo.text = ammoLeft + " | " + ammo;
        uiAmmoBackdrop.text = uiAmmo.text;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoLeft = ammo;

            uiNoAmmo.SetActive(false);
            uiNoAmmoBackdrop.SetActive(false);
        }

        if (ammoLeft == 0)
        {
            uiNoAmmo.SetActive(true);
            uiNoAmmoBackdrop.SetActive(true);
        }

    }
}