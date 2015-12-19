using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoretxt;

	// Use this for initialization
	void Start () 
    {
        score = 0;
        scoretxt.text = "0";
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (score.ToString() != scoretxt.text)
        {
            scoretxt.text = score.ToString();
        }
	}
}
