using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterScript : MonoBehaviour {

	UnityAction activateListener;
	UnityAction deactivateListener;
	Light light;

	public Material letterMaterial;
	public char letter;
	void Awake () {
		activateListener = new UnityAction (LightOn);
		deactivateListener = new UnityAction (LightOn);
		light = GetComponent<Light> ();
	}

	void OnEnable () {
		SetLightOn (false);
		EventManager.StartListening ("ActivateLetter" + letter, activateListener);
		EventManager.StartListening ("DeactivateLetter" + letter, deactivateListener);
	}

	void OnDisable () {
		EventManager.StopListening ("ActivateLetter" + letter, activateListener);
		EventManager.StopListening ("DeactivateLetter" + letter, deactivateListener);
	}
		
	void LightOn () {
		SetLightOn (true);
	}

	void LightOff () {
		SetLightOn (false);
	}

	void SetLightOn(bool lightOn) {		
		letterMaterial.color = lightOn ? new Color (30, 0, 0) : new Color (8, 0, 0);
		light.intensity = lightOn ? 1F : 0F;
		light.range = lightOn ? 15F : 0F;
	}
}
