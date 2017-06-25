using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Wordflash : MonoBehaviour {

	//Unity UI elements
	[SerializeField]
	Button startButton;
	[SerializeField]
	Button[] optionButtons;
	[SerializeField]
	Text flashWord;

	//
	[SerializeField]
	string currentAnswer; //Current answer
	string[] currentOptions; //List of answers that have been chosen. 
	string[] possibleAnswers = {
		"Hoedje",
		"Oranje trui",
		"Blits gele broek",
		"Blauwe broek",
		"Paraplu",
	}; //List of possible answers.


	[SerializeField]
	string[] groep3Antwoorden;
	[SerializeField]
	string[] groep4Antwoorden;

	// Use this for initialization
	public void OnEnable() {
		Debug.Log("Start here"); //Game starts here.

		//Level difficulty implementation;
		switch(GameObject.Find("script holder").GetComponent<Buttons>().gameStatus) {
		case Buttons.Status.groep3:
			possibleAnswers = groep3Antwoorden;
			break;
		case Buttons.Status.groep4:
			possibleAnswers = groep4Antwoorden;
			break;
		default:
			//Do nothing (use current list)
			break;
		}

		StartCycle();
	}

	void StartCycle() {

		currentOptions = new string[optionButtons.Length];

		//Set optionbuttons and nextbutton off. As they're not available in this phase.
		for (int i=0; i < optionButtons.Length; i++) {
			optionButtons[i].interactable = false;
		}

		startButton.onClick.AddListener( () => {
			StartCoroutine(StartWordFlash());
		});

	}

	IEnumerator StartWordFlash() {

		startButton.interactable = false;

		GenerateAnswerOptions();
		SetFlashWord();

		Debug.Log("Starting wordflash.");

		yield return new WaitForSeconds(3); 

		flashWord.text = "";
		SetAnswerButtons();

	}

	void GenerateAnswerOptions() {

		List<string> currentPossibleAnswers = new List<string>(possibleAnswers); //List of possible answers, eligible for being used as a button.

		Debug.Log("Generating for each button;");

		for (int i=0; i < optionButtons.Length; i++) {
			int thisAnswerIndex = Random.Range(0, currentPossibleAnswers.Count);

			currentOptions[i] = currentPossibleAnswers[thisAnswerIndex];
			currentPossibleAnswers.RemoveAt(thisAnswerIndex);
		}
	}

	void SetFlashWord() {
		
		currentAnswer = currentOptions[Random.Range(0, optionButtons.Length)];
		flashWord.text = currentAnswer;

	}

	void SetAnswerButtons() {

		for (int i=0; i < optionButtons.Length; i++) {
			optionButtons[i].interactable = true;
			optionButtons[i].gameObject.GetComponentInChildren<Text>().text = currentOptions[i];
			string text = optionButtons[i].GetComponentInChildren<Text>().text;
			optionButtons[i].onClick.AddListener( () => {
				StartCoroutine(WordFlashOutcome(text == currentAnswer));
				for (int j=0; j < optionButtons.Length; j++) {
					optionButtons[j].interactable = false;
					optionButtons[j].gameObject.GetComponentInChildren<Text>().text = "";
				}
			});
		}

	}

	IEnumerator WordFlashOutcome(bool right) {

		flashWord.text = right ? "Goed!" : "Fout";

		yield return new WaitForSeconds(3);

		flashWord.text = "";
		startButton.interactable = true;

	}

}
