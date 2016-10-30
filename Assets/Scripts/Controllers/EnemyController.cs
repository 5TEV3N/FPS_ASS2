using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;                   // Refference to the enemy manager

    [Header("Values")]
    public Vector3 playerPosition;               // Gets the information of where the player is
    public float enemyShootingForce;             // How hard the player shoots

    [Header ("Containers")]
    public GameObject enemyBullets;              // Container for the enemy bullets
    public GameObject playerObject;              // Container for the player's charecter. so that the enemy is facing the player at all times
    public Transform bulletsParent;              // Bullet will be placed in the BulletsSpawned as a child
    public Transform enemybulletExitPoint;       // Contains the transform of where the bullet is exiting
    public Camera enemyCam;                      // The container of the player camera
    public NavMeshAgent agent;                   // Contains the NavMeshAgent
    public Transform[] hidingPosition;           // Hiding positions for the enemy

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

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            ShootOnSight();
            Transform findAnotherHidingPlace = hidingPosition[Random.Range(0, hidingPosition.Length)];
            agent.SetDestination(findAnotherHidingPlace.position);
        }
    }

    public void ShootOnSight()
    {
        enemyBulletShot = GameObject.Instantiate(enemyBullets, bulletsParent) as GameObject;
        enemyBulletShot.name = "Enemy Bullet";
        enemyBulletShot.transform.position = enemybulletExitPoint.transform.position;

        Vector3 enemyShootingDirection = playerPosition - enemybulletExitPoint.transform.position;
        enemyShootingDirection.Normalize();
        
        enemyBulletShot.GetComponent<Rigidbody>().AddForce(enemyShootingDirection * enemyShootingForce, ForceMode.Impulse);
    }
}

