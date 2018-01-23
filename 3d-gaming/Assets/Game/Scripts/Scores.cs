using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {


	public Text totalText;
	public Text continueText;
	public Text hole1;
	public Text hole2;
	public Text hole3;
	public Text hole4;
	public Text hole5;
	public Text hole6;
	public Text hole7;
	public Text hole8;
	public Text hole9;
	public Text hole10;
	public Text hole11;
	public Text hole12;
	public Text hole13;
	public Text hole14;
	public Text hole15;
	public Text hole16;
	public Text hole17;
	public Text hole18;
	public Text Hitcount;
	public int[] scores=new int[18];
	public GameObject scoreBoard;
	public int currentHole;

	private int totalScore;
	private int currentScore;


	void Start()
	{
		totalScore = 0;
		currentScore = -1;
		currentHole = 1;
		swingCount();
		continueText.text = "";
		scoreBoard.SetActive(false); //set scoreboard inactive till round end
	}
		
	public void HideScores ()
	{
			scoreBoard.SetActive (false);
			continueText.text = "";
			currentScore = -1;
			Time.timeScale = 1;
			swingCount ();

	}

	public void swingCount()
	{
		currentScore++;
		Hitcount.text = "Swing Count: " + currentScore.ToString (); //display current score

	}

	public void scoreUp()
	{
		//if ( end trigger)
		scores[currentHole-1]=currentScore;//set score for current hole = to the current score
		currentHole++;


		//for (int i = 0; i < 18; i++)//calculate total from all holes
		totalScore = totalScore + currentScore;


		totalText.text = "Total: " + totalScore.ToString ();
		//set each text zone on the Scoreboard to display score for that round
		hole1.text = scores [0].ToString();
		hole2.text = scores [1].ToString();
		hole3.text = scores [2].ToString();
		hole4.text = scores [3].ToString();
		hole5.text = scores [4].ToString();
		hole6.text = scores [5].ToString();
		hole7.text = scores [6].ToString();
		hole8.text = scores [7].ToString();
		hole9.text = scores [8].ToString();
		hole10.text = scores [9].ToString();
		hole11.text = scores [10].ToString();
		hole12.text = scores [11].ToString();
		hole13.text = scores [12].ToString();
		hole14.text = scores [13].ToString();
		hole15.text = scores [14].ToString();
		hole16.text = scores [15].ToString();
		hole17.text = scores [16].ToString();
		hole18.text = scores [17].ToString();
		scoreBoard.SetActive (true); //display scoreboard
		continueText.text="Press 'return' to continue";
		Time.timeScale = 0;
	}
}