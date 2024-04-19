using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject PlayerGoal;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        PlayerGoal = GameObject.Find("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (PlayerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerGoal")
        {
            Destroy(gameObject);
            Debug.Log("LOSER");
        }
        else if (collision.gameObject.name == "EnemyGoal")
        {
            Destroy(gameObject);
            Debug.Log("WINNER");
        }
    }
}
