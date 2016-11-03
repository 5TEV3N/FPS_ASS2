using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour
{
    LevelManager levelManager;                      //  Refferencing the levelManager
    PlayerController playerController;              //  Refferencing the playerController

    public float timeBeforeDeath;                   //  Time before it destroys itself
    public float intialTime;                        //  Self explanatory

    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("T_LevelManager").GetComponent<LevelManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        intialTime = Time.time;
    }

    void Update()
    {
        if (Time.time > intialTime + timeBeforeDeath)
        {
            Destroy(gameObject);
            return;
        }
    }
    void OnCollisionEnter(Collision enemy)
    {
        if (enemy.transform.tag == "Player")
        {
            print("Hit Player!");
            if (levelManager.playerHP != 0)
            {
                levelManager.playerHP--;
                playerController.PlayerHurt();
            }
        }
    }
}
