using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float _speed;
	public GameObject[] _EnemySetObj;
	// Use this for initialization
	void Start () {
		foreach(GameObject enemyObj in _EnemySetObj){
			enemyObj.transform.localPosition += new Vector3 (800, Random.Range (-2, 3) * 130.0f, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (_speed * Time.deltaTime, 0, 0);
	}
}
