using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PaddleScript : MonoBehaviour {
	
	[SerializeField]
	bool isPlayerTwo;
	[SerializeField]
	float speed = 0.2f;       // how far the paddle moves per frame
	Transform myTransform;    // reference to the object's transform
	int direction = 0; // 0 = still, 1= up, -1 = down
	float previousPositionY;

	public WWW www;
	public string url = "http://192.168.0.11:8080/accel";
	public string player1Position;


	// Use this for initialization
	void Start () {
		myTransform = transform;
		previousPositionY = myTransform.position.y;
		www = new WWW(url);


		//StartCoroutine(WaitForRequest(www));
		InvokeRepeating("Example", 0.00001F, 0.3F);
	}

	void Example() {
		StartCoroutine(GetAccel());
	}


	IEnumerator GetAccel()
	{
		string url = "http://192.168.0.11:8080/accel";
		UnityWebRequest www = UnityWebRequest.Get (url);
		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			player1Position = www.downloadHandler.text;

			// Or retrieve results as binary data
			byte[] results = www.downloadHandler.data;
		}

		if (isPlayerTwo)
		{
			if (player1Position=="u")
				MoveUp ();
			else if (player1Position=="d")
				MoveDown ();
		}
		else // if not player 2 it must be player 1
		{
			if (Input.GetKey ("q"))
				MoveUp ();
			else if (Input.GetKey ("a"))
				MoveDown ();
		}

		if (previousPositionY > myTransform.position.y)
			direction = -1;
		else if (previousPositionY < myTransform.position.y)
			direction =1;
		else
			direction = 0;

	}
	
	// FixedUpdate is called once per physics tick/frame
	void FixedUpdate () {
		//StartCoroutine(WaitForRequest(www));
		// first decide if this is player 1 or player 2 so we know what keys to listen for

	}
	
	// move the player's paddle up by an amount determined by 'speed'
	void MoveUp()
	{
		myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
	}
	
	// move the player's paddle down by an amount determined by 'speed'
	void MoveDown()
	{
		myTransform.position = new Vector2 (myTransform.position.x, myTransform.position.y - speed);            
	}

	void LateUpdate()
	{
		previousPositionY = myTransform.position.y;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		float adjust = 5 * direction;
		other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);        
	}

}