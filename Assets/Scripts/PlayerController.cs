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
        Vector3 movement = new Vector3((Input.GetAxis("Horizontal")), 0, 0);
        player.gameObject.transform.Translate(movement * speed * Time.deltaTime);
        //player.MovePosition(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            player.AddForce(0, 300, 0);
            canJump = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
        else if (collision.gameObject.tag == "Level")
        {
            Debug.LogWarning("== Level");
            //player.velocity = Vector3.zero;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
