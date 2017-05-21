using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	
	private int timesHit;
	private LevelManager levelManager;
	private SoundManager soundManager;
	private FX_Controller fx_Controller;
	public ParticleSystem smoke;
	
	void Awake(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		soundManager = GameObject.FindObjectOfType<SoundManager>();
		fx_Controller = GameObject.FindObjectOfType<FX_Controller>();
	}
	
	void Start () {
		timesHit = 0;
	}

	void OnCollisionEnter2D (Collision2D collision2D) {
		bool isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		//When destroyed
		if(timesHit >= maxHits) {
			PlayExplosionVFX();
			PlayExplosionSFX();
			levelManager.DestroyBrick();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PlayExplosionVFX(){
		fx_Controller.PlayExplosionFX(this);
	}
	
	void PlayExplosionSFX(){
		soundManager.play(this);
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Sprite not found [spriteIndex " + spriteIndex + "].");
			this.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
		}
	}
}
