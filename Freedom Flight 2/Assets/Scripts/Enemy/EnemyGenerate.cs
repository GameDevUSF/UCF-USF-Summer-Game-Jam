using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    private float force;
    private float innerWait;
    public float spawn_radius;

    public GameObject enemy;
    public GameObject spawnPoint;
    private GameObject player;

    private float InnerCounter;

    private Vector3 throw_dir;

    public float TimeToSpawn
    {
        get { return innerWait; }
        set { innerWait = value; }
    }

    public float Force
    {
        get { return force; }
        set { force = value; }
    }


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
            genMissle(force);
        }
    }

    private void genMissle(float force)
    {
        GameObject newEnemy = Instantiate(enemy, Random.insideUnitSphere * spawn_radius + spawnPoint.transform.position, Quaternion.Euler(0, 180, 0));
        //var mod_force = force * 10000;
        var mod_force = force * 10;
        newEnemy.GetComponent<Rigidbody>().AddForce(throw_dir * Random.Range(mod_force - 10, mod_force + 10));
        //newEnemy.GetComponent<Rigidbody>().AddForce(-Vector3.forward * Random.Range(mod_force - 10, mod_force + 10));
        InnerCounter = 0;
    }

}