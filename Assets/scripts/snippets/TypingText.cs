using UnityEngine;
using System.Collections;

public class TypingText {

	// IMPLEMENTATION
	// ====================
	// TypingText t = new TypingText ("Title of the Game");
	// void Update () {
	// 		if (!t.Done) {
	//		textToEdit = t.Type();
	//	===================
	// This requires the Timer class to function.

	Timer t = null;

	public bool Done { get; private set; }

	float minTime = 0.05f;
	float maxTime = 0.1f;

	string input;
	string toShow = string.Empty;

	int current = 0;

	// CONSTRUCTORS
	// ===============
	// 1. Only the text - typing speeds are defaults
	/// <summary>
	/// TypingText t = new TypingText ("Title of the Game");
	/// void Update () {
	/// 		if (!t.Done) {
	///		textToEdit = t.Type();
	/// This requires the Timer class to function.	
	/// </summary>
	/// <param name="toType">To type.</param>
	public TypingText (string toType) {
		input = toType;
		Done = false;
	}

	// 2. Text and typing speeds defined
	public TypingText (string toType, float minPause, float maxPause) {
		input = toType;
		minTime = minPause;
		maxTime = maxPause;
		Done = false;
	}

	// MAIN FUNCTION
	// ==================

	public string Type () {
		// sets the timer
		if (t == null) {
			t = new Timer(minTime, maxTime, input.Length);
		}

		if (t.RunTimer()) {
			toShow += input[current];
			current++;
		}

		if (current == input.Length) {
			Done = true;
		}

		// blinking cursor
		string toAdd = ((int)Time.time % 2 == 0 ? "■" : "");

		// only add blinking cursor when the text is done typing
		return ( !Done ? toShow + "■" : toShow + toAdd);
	}

}
