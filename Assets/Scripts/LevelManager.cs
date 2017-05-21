using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private int bricksLeftInLevel = 0;

	void Start(){
		bricksLeftInLevel = GameObject.FindGameObjectsWithTag("Breakable").Length;
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void DestroyBrick(){
		bricksLeftInLevel--;
		
		if(bricksLeftInLevel <= 0){
			LoadNextLevel();
		}
	}
}
