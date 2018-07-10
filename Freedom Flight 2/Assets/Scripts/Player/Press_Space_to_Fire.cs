using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_Space_to_Fire : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter_1;
    public GameObject Bullet_Emitter_2;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler_1;
            GameObject Temporary_Bullet_Handler_2;

            Temporary_Bullet_Handler_1 = Instantiate(Bullet, Bullet_Emitter_1.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            Temporary_Bullet_Handler_2 = Instantiate(Bullet, Bullet_Emitter_2.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            //Temporary_Bullet_Handler.transform.Rotate(Vector3.forward);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody_1;
            Temporary_RigidBody_1 = Temporary_Bullet_Handler_1.GetComponent<Rigidbody>();

            Rigidbody Temporary_RigidBody_2;
            Temporary_RigidBody_2 = Temporary_Bullet_Handler_2.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody_1.AddForce(transform.forward * Bullet_Forward_Force * 1000);
            Temporary_RigidBody_2.AddForce(transform.forward * Bullet_Forward_Force * 1000);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler_1, 4f);
            Destroy(Temporary_Bullet_Handler_2, 4f);
        }
    }
}