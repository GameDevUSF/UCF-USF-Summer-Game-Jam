using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject ship;
    private Rigidbody rb;

    public float turnspeed = 10f;
    public float trueSpeed;
    public float transSpeed;

    // Use this for initialization
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        rb = ship.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var roll = Input.GetAxis("Roll");
        var pitch = Input.GetAxis("Pitch");
        var yaw = Input.GetAxis("Yaw");
        var power = Input.GetAxis("Power");

       
        //Debug.Log(pitch);



        //Pitch
        ///rb.AddRelativeTorque(Vector3.left * pitch * turnspeed); //* Time.deltaTime);

        //Yaw
        //rb.AddRelativeTorque(Vector3.up * yaw * turnspeed); // * Time.deltaTime);
        //Roll
        //rb.AddRelativeTorque(Vector3.forward * roll * turnspeed); // * Time.deltaTime);

        //yaw but with roll keys
        //rb.AddRelativeTorque(Vector3.up * roll * turnspeed);

        //Roll but with Yaw keys and pitch with pitch keys
        //rb.AddRelativeTorque(-pitch * turnspeed, 0, yaw * turnspeed);

        //Roll but with roll keys
        rb.AddRelativeTorque(0, 0, -roll * turnspeed * 1000);

        //Yaw with yaw Keys
        //rb.AddRelativeTorque(0, yaw * turnspeed * 1000, 0);

        //Pitch with Pitch Keys
        //rb.AddRelativeTorque(pitch * turnspeed * 1000, 0, 0);

        //Go side ways and up nigga
        Vector3 new_velocity = new Vector3(horizontal * transSpeed * 50, vertical * transSpeed * 50, (trueSpeed + (power * trueSpeed)));

        rb.velocity = Vector3.Slerp(rb.velocity, new_velocity, 0.2f);
        //rb.velocity = new Vector3(horizontal * 50, vertical * 50, 0);

        //rb.AddRelativeForce(0, 0, power * trueSpeed * 10000);
        //rb.AddForce(0, 0, power * trueSpeed * 1000);

    }


}
