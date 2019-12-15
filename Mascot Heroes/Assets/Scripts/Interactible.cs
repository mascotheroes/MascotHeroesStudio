using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactible : MonoBehaviour {

	public List<Hero> interactibleHeores;
	public GameObject interactButton;
	public GameObject bearTipUI;
	public GameObject goatTipUI;
	public GameObject muleTipUI;
	public GameObject bulldogTipUI;
	public GameObject falconTipUI;
	private GameObject activeTipUI;
	public UnityEvent interacted;
	public bool activated;
	public bool destroyOnInteract;
	private HeroManager player;
	//private Hero selectedHero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (player == null) {
			player = other.gameObject.GetComponent<HeroManager> ();
		}
		if (player) {
			switch (interactibleHeores[0]) {
			case Hero.Bear:
				bearTipUI.SetActive (true);
				activeTipUI = bearTipUI;
				break;
			case Hero.Bulldog:
				bulldogTipUI.SetActive (true);
				activeTipUI = bulldogTipUI;
				break;
			case Hero.Falcon:
				falconTipUI.SetActive (true);
				activeTipUI = falconTipUI;
				break;
			case Hero.Goat:
				goatTipUI.SetActive (true);
				activeTipUI = goatTipUI;
				break;
			case Hero.Mule:
				muleTipUI.SetActive (true);
				activeTipUI = muleTipUI;
				break;
			}
			foreach (Hero heroes in interactibleHeores) {
				if (heroes == player.currentHero) {
					activeTipUI.SetActive (false);
					interactButton.SetActive(true);
					activated = true;
				}
			}
			//selectedHero = player.currentHero;
		}

	}
 
//	public void OnTriggerStay2D(Collider2D other){
//		if (player) {
//			if (selectedHero != player.currentHero) {
//				foreach (Hero heroes in interactibleHeores) {
//					if (heroes == player.currentHero) {
//						activeTipUI.SetActive (false);
//						interactButton.SetActive (true);
//						activated = true;
//					}
//				}
//				selectedHero = player.currentHero;
//			}
//		}
//	}

	public void OnTriggerExit2D(Collider2D other){
		if (player == null) {
			player = other.gameObject.GetComponent<HeroManager> ();
		}
		if (player) {
			activeTipUI.SetActive (false);
			interactButton.SetActive (false);
			activated = false;
		}
	}

	public void Interacted(){
		if (activated == true) {
			interacted.Invoke ();
			if (destroyOnInteract) {
				Destroy (gameObject);
			}
		}
	}
}
