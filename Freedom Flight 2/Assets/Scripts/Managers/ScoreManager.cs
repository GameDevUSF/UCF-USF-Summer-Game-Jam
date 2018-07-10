//Jean-Luc Hayes 11/29/16
//Controls the Score of the game through a static variable
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    UnityEngine.UI.Text text;
    UnityEngine.UI.Text speed;


    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        text = GameObject.FindGameObjectWithTag("Score_UI").GetComponent<UnityEngine.UI.Text>();
        speed = GameObject.FindGameObjectWithTag("Speed_UI").GetComponent<UnityEngine.UI.Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var power = Input.GetAxis("Power");

        text.text = "" + score;
        speed.text = "" + (power * 100).ToString("F1");
    }
}
