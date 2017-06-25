using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGame : MonoBehaviour {

	[SerializeField]
	Button[] buttons;
	[SerializeField]
	Text currentItemDisplay;


	OptionObject[] optionObjects; //Pre-defined list of objects that can appear.

	[SerializeField]
	OptionObject[] groep3OptionObjects;
	[SerializeField]
	OptionObject[] groep4OptionObjects;

	[SerializeField]
	List<OptionObject> objectChoiceList; //A dynamic list that will be used for choosing the possible answers.
	[SerializeField]
	OptionObject[] objectChoices;
	[SerializeField]
	OptionObject currentObject; //The right object that is chosen as the right answer.

	void OnEnable() {
		switch(GameObject.Find("script holder").GetComponent<Buttons>().gameStatus) {
		case Buttons.Status.groep3:
			optionObjects = groep3OptionObjects;
			break;
		case Buttons.Status.groep4:
			optionObjects = groep4OptionObjects;
			break;
		default:
			//Do nothing (use current list)
			break;
		}
		NewReset();
	}

	void NewReset() { //Resets the board and starts the game over to it's starting setup.

		currentObject = new OptionObject("", new Sprite());

		objectChoiceList = new List<OptionObject>(optionObjects);
		objectChoices = new OptionObject[buttons.Length];

		List<OptionObject> something = new List<OptionObject>(optionObjects);

		for(int i=0; i < buttons.Length; i++) { //Selects a random item in the list of choices, sets this as one of the buttons' "value"s and removes it from the list and repeats this until all the buttons have a valie.

			int currentRandomObjectInt = Random.Range(0, objectChoiceList.Count);

			objectChoices[i] = objectChoiceList[currentRandomObjectInt];
			buttons[i].GetComponent<Image>().sprite = objectChoiceList[currentRandomObjectInt].image;
			objectChoiceList.RemoveAt(currentRandomObjectInt);


		}

		currentObject.name = objectChoices[Random.Range(0, objectChoices.Length)].name;
		currentItemDisplay.GetComponent<Text>().text = currentObject.name;

	}

	public void OnButtonClick(int choiceNumber) {

		if (currentObject.name == objectChoices[choiceNumber].name) {
			NewReset();
			Debug.Log("Right answer!");
		} else {
			Debug.Log("Wrong answer! Try again!");
		}

	}


}

[System.Serializable]
class OptionObject {

	public string name;
	public Sprite image;

	public OptionObject(string name, Sprite image) {
		this.name = name;
		this.image = image;
	}

}