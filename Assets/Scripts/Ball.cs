using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private const float BALL_X_POS_START = 0.5f;
	private const float BALL_Y_POS_START = 0.85f;
	private const float BALL_Z_POS = -5f;
	
	private const float CLAMP_MIN = 0.5f;
	private const float CLAMP_MAX = 15.5f;
	
	private Vector3 paddleToBallVector;
	
	private bool gameStarted = false;
	private Paddle paddle;
	
	private SoundManager soundManager;
	
	void Awake(){
		soundManager = GameObject.FindObjectOfType<SoundManager>();
	}
	
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if(!gameStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if(Input.GetMouseButtonUp(0)){
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,10f);
				gameStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision2D){
		
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
			
		if(gameStarted) {
			soundManager.play(this);
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
