using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour
{
    PlayerController playerController;              //  Refferencing the enemyManager

    public float timeBeforeDeath;                   //  Time before it destroys itself
    public float intialTime;                        //  Self explanatory

    void Awake()
    {
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
            if (playerController.playerHP != 0)
            {
                playerController.playerHP--;
            }
        }
    }
}
