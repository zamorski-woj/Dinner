using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHammer : MonoBehaviour
{
    public GameObject g;
    public Rigidbody rb;
    public float speed = 50.0f;
    public float rotationSpeed = 50.0f;
    public GameObject pivot;


    public float verticalMove, rotation, lorry;
    //float moveSpeed = 10;

    void Start()
    {
        g = gameObject;
        rb = g.GetComponent<Rigidbody>();
        pivot = GameObject.Find("rotator");
    }
    //A miner has been trapped in a flooded mine. Now it is up to you to feed him sugar.
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") == 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.97f * Time.deltaTime, rb.velocity.y * 0.97f * Time.deltaTime, rb.velocity.z * 0.97f * Time.deltaTime);

        }


        verticalMove = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //lorry= Input.GetKey

        //verticalMove *= Time.deltaTime;
        rotation *= Time.deltaTime;
        rb.AddRelativeForce(0, -verticalMove, 0);



        // rb.transform.Translate(translation, 0, 0);
        //rb.transform.Rotation(0.0f,0.0f,rb.transform.Rotation.z);
        rb.transform.RotateAround(pivot.transform.position, new Vector3(0, 1, 0), rotation);

    }



    // private void OnTriggerEnter(Collider other)
    // {
    //	Debug.Log("HammerCollision");
    //}

}
