using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenophieTest : MonoBehaviour
{
    public Rigidbody rigidbody;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * 5f, rigidbody.velocity.y, 0f);
        rigidbody.velocity = movement;

        if (Input.GetButtonDown("Jump"))
            rigidbody.AddForce(0f, 250f, 0f);
    }
}
