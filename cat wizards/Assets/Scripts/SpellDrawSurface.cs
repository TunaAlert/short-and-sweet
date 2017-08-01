using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class SpellDrawSurface : MonoBehaviour {

	public Color32 color;

	ArrayList drawNodes;
	bool drawMouseWasDown;

	Texture2D tex;
	RawImage img;

	void Start () {
		img = GetComponent<RawImage> ();
		tex = new Texture2D (Screen.width, Screen.height);
		img.texture = tex;
		drawNodes = new ArrayList ();
		ClearTex ();
	}

	void Update () {
		if (Input.GetAxis ("DrawMouse") == 1) {
			drawMouseWasDown = true;

			Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			if (drawNodes.Count > 0) {
				Vector2 lastPos = (Vector2)drawNodes [drawNodes.Count - 1];
				DrawLine (lastPos, mousePos, color);
			}
			drawNodes.Add (mousePos);
		} else if (drawMouseWasDown) {
			drawMouseWasDown = false;

			CheckSpell ();
			drawNodes.Clear ();

			ClearTex ();
		}
	}

	void DrawLine(Vector2 f, Vector2 t, Color32 c){
		Vector2 l = f;
		float frac = 1/Mathf.Sqrt (Mathf.Pow (t.x - f.x, 2) + Mathf.Pow (t.y - f.y, 2));
		float ctr = 0;

		while ((int)l.x != (int)t.x || (int)l.y != (int)t.y) {
			l = Vector2.Lerp(f, t, ctr);
			ctr += frac;
			tex.SetPixel((int)l.x, (int)l.y, c);
		}
		tex.Apply ();
	}

	void ClearTex(){
		tex.Resize (Screen.width, Screen.height);
		for (int x = 0; x < tex.width; x++) {
			for (int y = 0; y < tex.height; y++) {
				tex.SetPixel (x, y, Color.clear);
			}
		}
		tex.Apply ();
	}

	void CheckSpell(){

	}
}
