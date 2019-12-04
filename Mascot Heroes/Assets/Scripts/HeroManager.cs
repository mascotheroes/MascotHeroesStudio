using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hero {Bulldog, Bear, Mule, Falcon, Goat}

public class HeroManager : MonoBehaviour {

	public Hero currentHero;
	public Sprite bulldog, bear, mule, falcon, goat;
	private SpriteRenderer spriteRend;
	private Movement player;
	// Use this for initialization
	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
		player = GetComponent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SwapHero ("Bear");
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SwapHero ("Bulldog");
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SwapHero ("Falcon");
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			SwapHero ("Goat");
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			SwapHero ("Mule");
		}
	}
		
	public void SwapHero(string newHero){
		switch (newHero) {
		case "Bear":
			currentHero = Hero.Bear;
			spriteRend.sprite = bear;
			break;
		case "Bulldog":
			currentHero = Hero.Bulldog;
			spriteRend.sprite = bulldog;
			break;
		case "Falcon":
			currentHero = Hero.Falcon;
			spriteRend.sprite = falcon;
				break;
		case "Goat":
			currentHero = Hero.Goat;
			spriteRend.sprite = goat;
			break;
		case "Mule":
			currentHero = Hero.Mule;
			spriteRend.sprite = mule;
			break;
		}
		player.ToggleSwapMenu ();
	}
}
