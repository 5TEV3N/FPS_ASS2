using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;  //refference to the enemymanager

    void Awake()
    {
        enemyManager = GameObject.FindGameObjectWithTag("T_EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        if (enemyManager.enemyHp == 0)
        {
            print("IM DEAD");
            Destroy(gameObject);
        }
    }
}
