using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public new Transform camera;
    private bool canJump = true;
    public PowerBarManager powerBar;
    public float maxJump = 5;
    public float currentJump;

    void Start()
    {
        currentJump = maxJump;
        powerBar.UpdatePowerBar();
    }

    
    void Update()
    {
        //player.AddForce(((Input.GetAxis("Horizontal") * -1) * 0.9f), 0, 0);
        int speed = 5;
        Vector3 movement = new Vector3((Input.GetAxis("Horizontal")) * speed, player.velocity.y, 0);
        player.velocity = movement;
        //player.gameObject.transform.Translate(movement );
        //player.MovePosition(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && canJump && currentJump > 0)
        {
            player.AddForce(0, 650, 0);
            currentJump = currentJump - 1;
            canJump = false;
            powerBar.UpdatePowerBar();
        }
        //Add "game over" screen
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }

        if (collision.gameObject.tag == "Finish")
        {
            Destroy(player.gameObject);
        }
        if (collision.gameObject.tag == "Battery")
        {
            Destroy(collision.gameObject);
            currentJump = maxJump;
            powerBar.UpdatePowerBar();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
