using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScore : MonoBehaviour
{
    private GameObject score_manager;
    private float score;

    UnityEngine.UI.Text death_score;

    // Use this for initialization
    void Start ()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score_Manager");
        death_score = GameObject.FindGameObjectWithTag("Death_Score_UI").GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        score = score_manager.GetComponent<ScoreManager>().Score;

        death_score.text = "" + score;
    }
}
