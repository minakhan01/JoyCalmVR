﻿using UnityEngine;
using System.Collections;

public class AndroidReceiveData : MonoBehaviour {

	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	public float fft = 0;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		AndroidJNI.AttachCurrentThread();
		AndroidJNIHelper.debug = true; 

		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.mina.breathitout.AnalyzeActivity")) {
			if(pluginClass != null) {
				//					toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
				toastExample = pluginClass.CallStatic<AndroidJavaObject>("getInstance", activityContext);
				//					activityContext.Call("print", "this");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//		int RValue = 0;
		//		using (AndroidJavaClass javaClass = new AndroidJavaClass("com.mina.myapplication.MainActivity")) {
		//			using (AndroidJavaObject activity = javaClass.GetStatic<AndroidJavaObject>("mContext"))
		//			{
		//				Debug.Log("rate :"+activity.CallStatic<float>("getRate"));
		//			}
		//		}
		//
		//		//		Debug.Log("rate" + RValue.ToString() );
	}

	void receiveAlpha(string message) {
		Debug.Log("message from java: " + message);
		float result;
		float.TryParse(message, out result);
		fft = result;
	}

	void receiveEeg(string message) {
		Debug.Log("message from java: " + message);
	}

	void receiveAccel(string message) {
		Debug.Log("message from java: " + message);
	}

	void receiveStatus(string message) {
		Debug.Log("message from java: " + message);
	}
}