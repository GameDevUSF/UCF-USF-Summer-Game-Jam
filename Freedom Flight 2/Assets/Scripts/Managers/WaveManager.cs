using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private EnemyGenerate enemyGenerate;

    private float wave_number;
    private float timer;
    private float originalTime = 15f;
    private float increment = 15f;

    UnityEngine.UI.Text wave;
    UnityEngine.UI.Text time;

    private float wave_timer = 0;



    // Use this for initialization
    void Start ()
    {
        wave_number = 1;
        enemyGenerate = gameObject.GetComponent<EnemyGenerate>();
        wave = GameObject.FindGameObjectWithTag("Wave_UI").GetComponent<UnityEngine.UI.Text>();
        time = GameObject.FindGameObjectWithTag("Wave_Time_UI").GetComponent<UnityEngine.UI.Text>();
    }

    void render_wave()
    {
        wave.text = "" + wave_number;
        time.text = "" + wave_timer.ToString("F1");
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        //Wave Mechanics


        if (timer < originalTime)
        {
            wave_number = 1;
            enemyGenerate.TimeToSpawn = 5f;
            enemyGenerate.Force = 1f;
        }

        if (timer > originalTime && timer < originalTime + increment)
        {
            wave_number = 2;
            enemyGenerate.TimeToSpawn = 4f;
            enemyGenerate.Force = 1.25f;
        }

        if (timer > originalTime + increment && timer < originalTime + 2 * increment)
        {
            wave_number = 3;
            enemyGenerate.TimeToSpawn = 3f;
            enemyGenerate.Force = 1.50f;
        }

        if (timer > originalTime + 2 * increment && timer < originalTime + 3 * increment)
        {
            wave_number = 4;
            enemyGenerate.TimeToSpawn = 2f;
            enemyGenerate.Force = 2f;
        }

        if (timer > originalTime + 3 * increment && timer < originalTime + 4 * increment)
        {
            wave_number = 5;
            enemyGenerate.TimeToSpawn = 1.5f;
            enemyGenerate.Force = 2.50f;
        }

        if (timer > originalTime + 4 * increment && timer < originalTime + 5 * increment)
        {
            wave_number = 6;
            enemyGenerate.TimeToSpawn = 1f;
            enemyGenerate.Force = 3f;
        }

        if (timer > originalTime + 5 * increment && timer < originalTime + 6 * increment)
        {
            wave_number = 7;
            enemyGenerate.TimeToSpawn = 0.5f;
            enemyGenerate.Force = 3.5f;
        }

        if (timer > originalTime + 6 * increment && timer < originalTime + 7 * increment)
        {
            wave_number = 8;
            enemyGenerate.TimeToSpawn = 0.25f;
            enemyGenerate.Force = 4f;
        }

        if (wave_timer <= 0.0f)
        {
            wave_timer = increment;
        }

        wave_timer -= Time.deltaTime;

        render_wave();



    }

}
