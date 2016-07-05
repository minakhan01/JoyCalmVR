using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void Awake() 
	{
		GetComponent<GvrViewer>().OnBackButton += HandleOnBackButton;
	}

	void HandleOnBackButton ()
	{
		Application.Quit();        
	}
}
