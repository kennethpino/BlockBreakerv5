using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private AudioSource ballCollision;
	private AudioSource brickExplosion;

	void Awake(){
		ballCollision = GameObject.Find("BallToPaddleThump").GetComponent<AudioSource>();
		brickExplosion = GameObject.Find("Explosion").GetComponent<AudioSource>();
	}

	public void play(Object o){
		switch(o.GetType().ToString()){
		case "Ball": ballCollision.Play();
		break;
		case "Brick": brickExplosion.Play();
		break;
		}
	}
}
