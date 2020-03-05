using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {up, down, left, right}

public class MoveOnInteract : MonoBehaviour {

	//public Direction directionToMove;
	public float speed;
	private Transform tf;
	public Vector3 goalPosition;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(){
//		switch (directionToMove) {
//		case Direction.up:
//			for (int i = 0; i <= distance; i++) {
//				tf.position += tf.up * speed * Time.deltaTime;
//			}
//			break;
//		case Direction.down:
//			for (int i = 0; i <= distance; i++) {
//				tf.position -= tf.up * speed * Time.deltaTime;
//			}
//			break;
//		case Direction.right:
//			for (int i = 0; i <= distance; i++) {
//				tf.position += tf.right * speed * Time.deltaTime;
//			}
//			break;
//		case Direction.left:
//			for (int i = 0; i <= distance; i++) {
//				tf.position -= tf.right * speed * Time.deltaTime;
//			}
//			break;
//		}
		StartCoroutine(Moving());
	}
	IEnumerator Moving(){
		while (Vector2.Distance (tf.position, goalPosition) > 0f) {
			tf.position = Vector3.MoveTowards (tf.position, goalPosition, speed * Time.deltaTime);
			yield return null;
		}
	}
}
