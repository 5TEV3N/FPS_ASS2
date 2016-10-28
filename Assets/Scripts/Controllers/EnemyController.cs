using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;                   // Refference to the enemy manager

    public float enemyShootingForce;
    public GameObject enemyBullets;              // Container for the enemy bullets
    public Transform bulletsParent;              // Bullet will be placed in the BulletsSpawned as a child
    public Transform enemybulletExitPoint;       // Contains the transform of where the bullet is exiting
    public Camera enemyCam;

    public GameObject playerObject;
    public Vector3 playerPosition;

    private GameObject enemyBulletShot;          // Instantiated prefab bullet 
    
    void Awake()
    {
        enemyManager = GameObject.FindGameObjectWithTag("T_EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        playerPosition = playerObject.transform.position;

        gameObject.transform.LookAt(playerPosition);

        if (enemyManager.enemyHp == 0)
        {
            print("IM DEAD");
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            ShootOnSight();
        }
    }

    public void ShootOnSight()
    {
        enemyBulletShot = GameObject.Instantiate(enemyBullets, bulletsParent) as GameObject;
        enemyBulletShot.name = "Enemy Bullet";
        //enemyBulletShot.transform.position = enemybulletExitPoint.transform.position;

        //Vector3 enemyShootingDirection = gameObject.transform.position - enemybulletExitPoint.transform.position;
        //enemyShootingDirection.Normalize();
        
        //enemyBulletShot.GetComponent<Rigidbody>().AddForce(enemyShootingDirection * enemyShootingForce, ForceMode.Impulse);
    }
}

