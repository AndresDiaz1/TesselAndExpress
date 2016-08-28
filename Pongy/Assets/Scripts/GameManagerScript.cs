using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour {

	int playerOneScore, playerTwoScore;
	[SerializeField]
	BallScript gameBall;
	[SerializeField]
	Text scoreText;
	[SerializeField]
	AudioClip goalScored;
	[SerializeField]
	AudioClip endGame;
	AudioSource audSource;
	[SerializeField]
	GameObject endGameScreen;
	CameraShakeScript camShake;

	// Use this for initialization
	public void StartNewGame()
	{
		playerOneScore = 0;
		playerTwoScore = 0;
		UpdateScoreText ();
		endGameScreen.SetActive (false);
		gameBall.Reset ();
	}
	
	void Start ()
	{
		audSource = GetComponent<AudioSource>();
		camShake = GetComponent<CameraShakeScript>();
		StartNewGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoalScored(int playerNumber)
	{
		camShake.Shake();
		PlaySound (goalScored);
		// increase the score for whichever player scored
		if(playerNumber == 1)
			playerOneScore++;
		else if (playerNumber ==2)
			playerTwoScore++;
		
		// now check if the player has won
		if(playerOneScore == 3)
			GameOver(1);
		else if (playerTwoScore ==3)
			GameOver(2);

		UpdateScoreText();
	} 

	void GameOver(int winner)
	{
		// this is called when a player reaches 3 points 
		
		// reset the scores
	 
		gameBall.Stop ();
		endGameScreen.SetActive (true);
		PlaySound (endGame);
	}

	void UpdateScoreText()
	{
		scoreText.text = "Player One " + playerOneScore.ToString() + " - " + playerTwoScore.ToString() + " Player Two";
	}

	void PlaySound(AudioClip soundClip)
	{
		audSource.clip = soundClip;
		audSource.Play();
	}


}
