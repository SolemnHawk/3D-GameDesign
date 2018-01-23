using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuControls : MonoBehaviour {

	public void QuitGame(){
		print ("Quit Game");
		Application.Quit ();
	}

	public void LoadLevel(int levelId)
	{
		print ("Load Scene " + levelId);
		SceneManager.LoadScene (levelId);
	}
}


