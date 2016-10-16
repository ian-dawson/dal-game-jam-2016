using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	Texture2D crosshairTex;
	Vector2 windowSize;
	Rect crosshairRect;

	// Use this for initialization
	void Start () {
		crosshairTex = new Texture2D (2, 2);
		windowSize = new Vector2 (Screen.width, Screen.height);
		CalculateRect ();
	}
	
	void CalculateRect() {
		crosshairRect = new Rect ((windowSize.x - crosshairTex.width) / 2,
								  (windowSize.y - crosshairTex.height) / 2,
								   crosshairTex.width, crosshairTex.height);
	}

	void OnGUI() {
		GUI.DrawTexture (crosshairRect, crosshairTex);
	}
}
