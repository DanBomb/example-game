using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;
	//public Text loseText;
	public Text endTimeText;
	public Text readyText;

	private Rigidbody rb;
	private int count;
	private int time;
	private bool timeset;
	private bool setStart = false;
	private string timetext;
	

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		timeset = (true);
		count = 7;
		time = 0;
		SetCountText ();
		winText.text = "";
		//loseText.text = "";
		timeText.text = "";
		endTimeText.text = "";
		InvokeRepeating ("SetTimeText", 0.0f, 1.0f);
		readyText.text = "Press space to start";

	}
	

	void FixedUpdate ()
	{
		if (Input.GetButton("Jump"))
		{
			setStart = true;
			readyText.text = "";
		}
		if (setStart)
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (-moveVertical, 0.0f, moveHorizontal);

			rb.AddForce (movement * speed);
		}
	}

    void OnTriggerEnter(Collider other)
	{
    	if (other.gameObject.CompareTag("Pick-up")) //&& time >= 1)
		{
			other.gameObject.SetActive (false);
			count = count - 1;
			SetCountText ();
		}
		/* else if (other.gameObject.CompareTag("Pick-up") && time <= 0)
		{
			time = 0;
		}*/
	}
	void SetCountText ()
	{
		countText.text = "Cubes left: " + count.ToString ();
		if (count <= 0)
		{
			winText.text = "You win!";
			//time = 1000;
			timeset = (false);
			timetext = time.ToString ();
			endTimeText.text = "Your time: " + timetext;
			
		}
	}
	void SetTimeText ()
	{
		if (setStart)
		{
			time = time + 1;
			if (timeset)
			{
				timeText.text = "Time: " + time.ToString ();
			}
			/* if (time <= 0)
			{
				loseText.text = "Time's up!";
				timeset = (false);
			}*/
		}
	}
	/* void TimeUp ()
	{
		if (gameObject.CompareTag("Player"))
			{
				gameObject.SetActive (false);
			}	
	}*/
}
