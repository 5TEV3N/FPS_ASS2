using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController playerController;              // Reference to the playerController

    public int playerHP;                            // Health of player

    public Text uiPlayerHp;                         // Container for the hp ui text
    public Text uIPlayerHpBackdrop;                 // Same as above

    public GameObject gameOverText;                 // Container for the gameover text
    public GameObject gameOverTextBackdrop;         // Same as above
    public GameObject HUD;                          // Container for the hud object

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        uiPlayerHp.text = "Health     " + playerHP;
        uIPlayerHpBackdrop.text = "Health     " + playerHP;
        if (playerHP <=0)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            gameOverTextBackdrop.SetActive(true);
            HUD.SetActive(false);
        }
    }
}
