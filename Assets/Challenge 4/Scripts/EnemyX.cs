using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;

    [SerializeField] float speed;

    /*
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    */
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3
        enemyRb.AddForce(player.transform.position - transform.position * speed);
        /*
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;

        */
    }

    private void OnCollisionEnter(Collision other)
    {
        /*
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
        */
    }

}
