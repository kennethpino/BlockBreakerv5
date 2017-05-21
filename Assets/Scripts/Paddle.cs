using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private const float CLAMP_MIN = 1f;
	private const float CLAMP_MAX = 15f;
	private const float PADDLE_X_POS = 0.5f;
	private const float PADDLE_Y_POS = 0.5f;
	private const float PADDLE_Z_POS = -1;
	
	private Vector3 paddlePosition;
	private Ball ball;
	public bool autoPlay = false;
		
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
		paddlePosition = new Vector3(PADDLE_X_POS,PADDLE_Y_POS,PADDLE_Z_POS);
	}

	void Update(){
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse(){
		paddlePosition.x = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, CLAMP_MIN, CLAMP_MAX);
		this.transform.position = paddlePosition;
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3(ball.transform.position.x, PADDLE_Y_POS, PADDLE_Z_POS);
		this.transform.position = paddlePos;
	}
}
 