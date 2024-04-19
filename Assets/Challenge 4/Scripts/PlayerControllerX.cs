using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    Rigidbody playerRb;
    GameObject focalPoint;

    [SerializeField] GameObject powerUpIndicator;

    [SerializeField] float speed;
    [SerializeField] float normalStrength;
    [SerializeField] float powerUpStrength;

    public bool hasPowerUp = false;

    int powerUpDuration = 7;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerUpIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            if (hasPowerUp)
            {
                enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            }
            else
            {
                enemyRb.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
            Debug.Log("Player collided with " + collision.gameObject.name + " with power up set to " + hasPowerUp);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
