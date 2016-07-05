using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BreathingControl : MonoBehaviour {

	GameObject micController;
	GameObject dandelion;
	ParticleSystem particleSystem;
	bool micInitialized = false;

	// Use this for initialization
	void Start () {
		Invoke("InitializeMic", 1);
	}

	void InitializeMic() {
		micController = GameObject.Find ("Listener");
		dandelion = GameObject.Find ("Dandelions_A");
		particleSystem = dandelion.GetComponent<ParticleSystem>();
		IncreaseRate ();
		micInitialized = true;
	}

	// Update is called once per frame
	void Update () {
		if (micInitialized) {
//			var loudness = micController.GetComponent<MicControl> ().loudness;
			var fft = micController.GetComponent<AndroidReceiveData>().fft;
			Debug.Log ("fft: " + fft);
			if (fft > -30) {
				Debug.Log ("loudness > 0.05f");
				IncreaseRate ();
			} else {
				DecreaseRate ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene("UnderWater Scene_2", LoadSceneMode.Single);
		}
	}

	void IncreaseRate() {
//		ParticleSystem.EmissionModule em = particleSystem.emission;
//		em.enabled = true;
//		var ex = particleSystem.externalForces;
//		ex.multiplier = 500f;
//		ex.enabled = true;
////		em.rate = new ParticleSystem.MinMaxCurve(100000);
////		var ex = particleSystem.externalForces;
////		ex.enabled = true;
////		ex.multiplier = 500f;
//		em.SetBursts(
//			new ParticleSystem.Burst[]{
//				new ParticleSystem.Burst(2.0f, 10000),
//				new ParticleSystem.Burst(4.0f, 10000)
//			});
		particleSystem.Play ();
		StartCoroutine(ExecuteAfterTime(5));
	}

	void DecreaseRate() {
		
//		var ex = particleSystem.externalForces;
//		ex.multiplier = 5f;
//		ex.enabled = false;
//		particleSystem = GetComponent<ParticleSystem>();
//		var em = particleSystem.emission;
////		em.rate = new ParticleSystem.MinMaxCurve(100000);
//		var ex = particleSystem.externalForces;
//		ex.enabled = true;
//		ex.multiplier = 1f;
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay
		particleSystem.Pause();
	}
}