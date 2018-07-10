using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter_1;
    public GameObject Bullet_Emitter_2;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    //private float innerWait;
    public float innerWait;

    private float InnerCounter;
    private Vector3 throw_dir;
    private GameObject player;

    /*public float TimeToSpawn
    {
        get { return innerWait; }
        set { innerWait = value; }
    }*/

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        throw_dir = player.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        InnerCounter += Time.deltaTime;

        if (InnerCounter > innerWait)
        {
            genBullet(Bullet_Forward_Force);
        }
    }

    private void genBullet(float force)
    {
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler_1;
        GameObject Temporary_Bullet_Handler_2;

        Temporary_Bullet_Handler_1 = Instantiate(Bullet, Bullet_Emitter_1.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        Temporary_Bullet_Handler_2 = Instantiate(Bullet, Bullet_Emitter_2.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

        Rigidbody Temporary_RigidBody_1;
        Temporary_RigidBody_1 = Temporary_Bullet_Handler_1.GetComponent<Rigidbody>();

        Rigidbody Temporary_RigidBody_2;
        Temporary_RigidBody_2 = Temporary_Bullet_Handler_2.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody_1.AddForce(transform.forward * force * 1000);
        Temporary_RigidBody_2.AddForce(transform.forward * force * 1000);

        Destroy(Temporary_Bullet_Handler_1, 4f);
        Destroy(Temporary_Bullet_Handler_2, 4f);

        InnerCounter = 0;
    }

}