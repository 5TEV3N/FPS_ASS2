using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public int enemyHp;                         // Enemies' HP
    public GameObject youWinScreen;             // 
    public GameObject youWinScreenBackdrop;     //
    public GameObject HUD;                      //
    
    void Update()
    {
        if (enemyHp <= 0)
        {
            youWinScreen.SetActive(true);
            youWinScreenBackdrop.SetActive(true);
            HUD.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
