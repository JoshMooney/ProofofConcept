using UnityEngine;
using System.Collections;

public class AudioListerSingleton : MonoBehaviour {

	private static AudioListerSingleton instance = null;

	private void Awake () {
		if(instance && instance != this) {
			DestroyImmediate(gameObject);
			return;
		}
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
