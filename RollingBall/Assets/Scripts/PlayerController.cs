using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI timeText;

	public float time;
	public int min;
	public float score;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;
		time = 0;

		SetCountText ();
		SetTimeText ();
	}
	void Update ()
	{
		time += Time.deltaTime;
		SetTimeText();
	}
	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Score: " + count.ToString();

		if (count >= 12) 
		{
		    score = min;
		    PlayerPrefs.SetInt("ScoreMinutes",min);
		    PlayerPrefs.SetFloat("ScoreTime",time);
		    
		    if (min <= PlayerPrefs.GetInt("HighScoreMinutes",1000))
		    {
		    	if (time <= PlayerPrefs.GetFloat("HighScoreTime",1000))
		    	{
		    		PlayerPrefs.SetInt("HighScoreMinutes",min);
		    		PlayerPrefs.SetFloat("HighScoreTime",time);		    		
		    	}
		    	
		    }
                    // Set the text value of your 'winText'                   			
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
	void SetTimeText()
	{
		
		if (time <= 59)
		{
			timeText.text = "Time: " + min.ToString() + " m " + time.ToString("0") + " s";
		}
		else
		{
			min += 1;
			time = 0;
			timeText.text = "Time: " + min.ToString() + " m " +  time.ToString("0") + " s";
		}
		
	}
}

