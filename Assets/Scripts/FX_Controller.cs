using UnityEngine;
using System.Collections;

public class FX_Controller : MonoBehaviour {

	private ParticleSystem explosion;

	void Awake () {
		explosion = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
	}

	public void PlayExplosionFX(Brick brick){
		explosion.startColor = brick.GetComponent<SpriteRenderer>().color;
		Instantiate (explosion, brick.transform.position, Quaternion.identity);
	}
}
