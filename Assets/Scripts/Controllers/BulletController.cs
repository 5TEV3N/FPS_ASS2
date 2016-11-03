using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    EnemyManager enemyManager;                      //  Refferencing the enemyManager

    public float timeBeforeDeath;                   //  Time before it destroys itself
    public float intialTime;                        //  Self explanatory

    void Awake()
    {
        enemyManager = GameObject.FindGameObjectWithTag("T_EnemyManager").GetComponent<EnemyManager>();
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
    void OnCollisionEnter (Collision enemy)
    {
        if (enemy.transform.tag == "T_Enemy")
        {
            if (enemyManager.enemyHp != 0)
            {
                enemyManager.enemyHp--;
            }
        }
    }
}
