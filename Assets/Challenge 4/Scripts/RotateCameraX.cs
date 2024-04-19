using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    [SerializeField]float rotationspeed;

    /*
    public GameObject player;
    */
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationspeed * Time.deltaTime);
        /*
        transform.position = player.transform.position; // Move focal point with player
        */
    }
}
