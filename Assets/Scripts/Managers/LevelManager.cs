using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController playerController;              // Reference to the playerController

    public int playerHP;                            // Health of player
    public Text uiPlayerHp;                         // Container for the hp ui text
    public Text uIPlayerHpBackdrop;                 // Same as above

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // check if the player hp is ==0;
        // if zero, freeze player movement, bring up the gameover ui.
    }
}
