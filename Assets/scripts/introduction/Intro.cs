using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	float spacer = 10f;

	public GUISkin skin;

	string toContent = string.Empty;

	float buttonWidth = 100f;
	float buttonHeight = 20f;

	const string intro = "AUGUST 1, 1984.\n\n\nWORLDGOV, INC. wishes to welcome you to your new post at the Information Enhancement Department. \n\nYour time at the IED will be spent ensuring that WORLDGOV, INC.'s new INTER-NET systems are of the highest quality and reliability, providing only the most useful information to the most deserving parties.\n\nThank you, and remember: WE THINK SO YOU DON'T HAVE TO.\n\n\nDonald D. Domoore\nCEO, WORLDGOV, INC.";

	TypingText t = new TypingText (intro, 0.04f, 0.04f);

	void OnGUI () {

		GUI.skin = skin;

		if (!t.Done) {
			toContent = t.Type();
		}
		else {
			if (GUI.Button (new Rect (Screen.width - spacer - buttonWidth, Screen.height - spacer - buttonHeight, buttonWidth, buttonHeight), "CONTINUE...")) {
				Application.LoadLevel ("concourse");
			}
		}



		GUI.Box (new Rect (spacer, spacer, Screen.width - (spacer * 2), Screen.height - (spacer * 2)), toContent);
	}
}
