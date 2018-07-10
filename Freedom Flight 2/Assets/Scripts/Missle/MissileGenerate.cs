using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerate : MonoBehaviour
{

    public GameObject missle;
    GameObject player;
    float InnerCounter;
    Vector3 throw_dir;

    public GameObject spawnPoint;

    public float force;
    public float innerWait;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        throw_dir = player.transform.position - missle.transform.position;
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
        //Missle One
        GameObject newMissle_1 = Instantiate(missle, Random.insideUnitSphere * 15 + spawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
        newMissle_1.GetComponent<Rigidbody>().AddForce(throw_dir * Random.Range(force - 10, force + 10));
        InnerCounter = 0;
    }

}