using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    public float jumpForce = 10;
    private float zLimits = 6.1f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        // We create and initialize all-direction movement variables for Input usage
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticallInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        // Jump action using user input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Prevent the player from leaving from top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zLimits)
        {
            playerRb.transform.position = new Vector3(transform.position.x, transform.position.y, zLimits);
        }

        if (transform.position.z < -zLimits)
        {
            playerRb.transform.position = new Vector3(transform.position.x, transform.position.y, -zLimits);
        }

    }
}
