using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {

	public GUISkin skin;

	System.Random r = new System.Random();

	float spacer = 10;

	float displayWidth = 300f;
	float displayHeight = 200f;

	List<string> toDisplay = new List<string>();
	List<string> flaggedWords = new List<string>();
	int maxWords = 10;

	// WORD LISTS
	// ============

	List<string> innocuousWords = new List<string>() {
		"cats",
		"funny cats",
		"siamese cats",
		"why does this hurt when I press it",
		"computer on",
		"really funny cats",
		"pugs",
		"pay my bills",
		"internet",
		"local restaurants",
		"movie times",
		"love interest questions",
		"colleges",
		"test answers",
		"math homework help",
		"popular television shows",
		"how to be popular",
		"how to be good at sports"
	};

	List<string> dangerWords = new List<string>() {
		"ANARCHY",
		"MENDACITY",
		"WANTON",
		"HOW TO DISTRIBUTE SEDITIOUS MATERIALS",
		"I HATE THE GOVERNMENT",
		"GOVERNMENT SECRETS"
	};

	Timer t = new Timer (0.1f, 0.3f, true);
	Timer danger = new Timer (0.5f, 2f, true);

	// list of all incoming search terms
	string UpdateSearchTerms() {
		while (toDisplay.Count > maxWords) {
			toDisplay.RemoveAt(0);
		}
		string toShow = ((int)Time.time % 2 == 0 ? "RECEIVING STREAM...\n\n" : "\n\n");
		foreach (string s in toDisplay) {
			toShow += s + "\n";
		}
		
		if (danger.RunTimer()) {
			string word = dangerWords[r.Next (0, dangerWords.Count - 1)];
			toDisplay.Add (word);
			flaggedWords.Add (word);
		}
		else if (t.RunTimer()) {
			toDisplay.Add (innocuousWords[r.Next (0, innocuousWords.Count - 1)]);
		}
		return toShow;
	}

	// sorted list of danger words
	string UpdateFlaggedTerms() {
		while (flaggedWords.Count > maxWords) {
			flaggedWords.RemoveAt(0);
		}
		string toShow = string.Empty;
		foreach (string s in flaggedWords) {
			toShow += s + "\n";
		}
		return toShow;
	}

	string tempString = string.Empty;
	char[] removeThis = new char[] { '_' };

	void UserInput () {
		tempString = GUI.TextField (new Rect (spacer,
		                                      spacer,
		                                      displayWidth,
		                                      displayHeight), tempString + ((int)Time.time % 2 == 0 ? "_" : ""));
		tempString = tempString.Trim(removeThis);
		if (Event.current.isKey && (Event.current.keyCode == KeyCode.Return ||
		                            Event.current.keyCode == KeyCode.RightArrow ||
		                            Event.current.keyCode == KeyCode.LeftArrow)) {
			if (flaggedWords.Contains (tempString.ToUpper())) {
				flaggedWords.Remove (tempString.ToUpper());
				print ("GOT IT");
			}
			else {
				print ("NOPE");
			}
			tempString = string.Empty;
		}
	}

	string fauxStream = string.Empty;
	string fauxStream2 = string.Empty;
	string fauxStream3 = string.Empty;
	Timer fauxTimer = new Timer (0.02f, true);
	int fauxMax = 45;
	float fauxHeight = 20f;

	string FauxBitStream(string stream, out string streamOut) {
		if (fauxTimer.RunTimer()) {
			stream += (SaFrMo.GetRandomBool() ? "0" : "1");
		}
		if (stream.Length > fauxMax) {
			stream = stream.Remove (0, 1);
		}
		streamOut = stream;
		return stream;
	}



	void OnGUI () {
		GUI.skin = skin;

		// Search terms box
		GUI.Box (new Rect (Screen.width - spacer - displayWidth,
		                   spacer,
		                   displayWidth,
		                   displayHeight), UpdateSearchTerms());

		// Flagged terms box
		GUI.Box (new Rect (Screen.width - spacer - displayWidth,
		                   spacer + displayHeight + spacer,
		                   displayWidth,
		                   displayHeight), UpdateFlaggedTerms(), skin.customStyles[0]);

		// "Bit stream" boxes
		GUILayout.BeginArea (new Rect (spacer, displayHeight + spacer + spacer, displayWidth, 100f));
		GUILayout.Box ( FauxBitStream(fauxStream, out fauxStream));
		GUILayout.Box ( "0" + fauxStream.Remove(0, 1));
		GUILayout.Box ( "1" + fauxStream.Remove (1, 1));
		GUILayout.EndArea();


		UserInput();
	}
}

