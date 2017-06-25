using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace InteractiveHouse {

	[RequireComponent(typeof(EventTrigger))]
	public class InteractiveFurniture : MonoBehaviour {

		[Header("Artist elements")]
		[SerializeField]
		string itemDescription;

		[Header("Developer elements")]
		[SerializeField]
		Text descriptionTextElement;
		[SerializeField]
		UnityEngine.Events.UnityEvent actionsOnClick;


		void Start () {

			Button thisButton = gameObject.AddComponent<Button>();

			thisButton.onClick.AddListener(() => {
				actionsOnClick.Invoke();
			});


			EventTrigger trigger = GetComponent<EventTrigger>();

			EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
			EventTrigger.Entry entryPointerExit = new EventTrigger.Entry();
			entryPointerEnter.eventID = EventTriggerType.PointerEnter;
			entryPointerExit.eventID = EventTriggerType.PointerExit;
			entryPointerEnter.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); });
			entryPointerExit.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data); });
			trigger.triggers.Add(entryPointerEnter);
			trigger.triggers.Add(entryPointerExit);
		}

		void OnPointerEnterDelegate(PointerEventData eventData) {
			
			Debug.Log("Event 'OnPointerEnter' triggered");
			gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1.2f);
			GetComponent<Animator>().CrossFade("Transition-Active", 0f);

		}

		void OnPointerExitDelegate(PointerEventData eventData) {

			Debug.Log("Event 'OnPointerExit' triggered");
			gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
			GetComponent<Animator>().CrossFade("Transition-Inactive", 0f);

		}

		public void Interaction() {
			Debug.Log("Interacting with " + gameObject.name);

			//Clear description text element's text.
			SetDescriptionText("");

			//Set description text element to have this item's description text.
			SetDescriptionText(itemDescription);

		}

		private void SetDescriptionText(string text) {
			try {
				descriptionTextElement.text = text;
			} catch (System.NullReferenceException) {
				Debug.LogWarning("No Description Text UI element found, not displaying description.");
			}
		}

	}



}