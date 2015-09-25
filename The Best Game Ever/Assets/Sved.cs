using UnityEngine;
using System.Collections;

public class Sved : MonoBehaviour {

	float sved = 4;
	float maxsved = 5;
	public bool running = false;

	Rect StaminaRect;
	Texture2D Staminatext;
	Rect borderRect;
	Texture2D bordertext;

	// Use this for initialization
	void Start () {
		StaminaRect = new Rect (Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
		borderRect = new Rect (Screen.width / 10-2, Screen.height * 9 / 10-2, Screen.width / 3+4, Screen.height / 50+4);
		Staminatext = new Texture2D (1, 1);
		bordertext = new Texture2D (1, 1);
		bordertext.SetPixel (0, 0, Color.black);
		bordertext.Apply();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftShift)){
			running = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)){
			running = false;
		}
		if (running) {
			sved += 0.7f * Time.deltaTime;
			if (sved > maxsved) {
				sved = maxsved;
				running = false;
			}
		} else {

			sved -= 1.25f * Time.deltaTime;
			if (sved < 0) {
				sved = 0;

			}
		}
	}
	void OnGUI () {
		float ratio = sved / maxsved;
		float rectWitdth = ratio * Screen.width / 3;
		StaminaRect.width = rectWitdth;
		if (ratio < 0.5) Staminatext.SetPixel (0, 0, Color.green);
		else if (ratio > 0.9) Staminatext.SetPixel (0, 0, Color.red);
		else if (ratio > 0.5 && ratio < 0.9) Staminatext.SetPixel (0, 0, Color.yellow);
		Staminatext.Apply();
		GUI.DrawTexture (borderRect, bordertext);
		GUI.DrawTexture (StaminaRect, Staminatext);

	}
}
