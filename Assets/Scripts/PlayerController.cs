using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public new Transform camera;
    private bool canJump = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        //player.AddForce(((Input.GetAxis("Horizontal") * -1) * 0.9f), 0, 0);
        int speed = 5;
        Vector3 movement = new Vector3((Input.GetAxis("Horizontal")) * speed, player.velocity.y, 0);
        player.velocity = movement;
        //player.gameObject.transform.Translate(movement );
        //player.MovePosition(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            player.AddForce(0, 300f, 0);
            canJump = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
