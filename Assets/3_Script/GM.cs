using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public GameObject _enemySet;
	public GameObject _nearBgObj;
	public Transform _PlayerObjPool;
	public bool _SpawnChk = true;
	public UILabel _ScoreText;
	public GameObject _ResultUI;
	public TextMesh _ResultText;
	public float _TimerForLevel = 0.0f;
	public float _TimerForLevelLim = 10.0f;
	public PlayerScript _PlayerSt;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		_TimerForLevel += Time.deltaTime;
		if (_TimerForLevel > _TimerForLevelLim) {
			if (Time.timeScale < 5.0f) {
				if (Time.timeScale < 5.0f) {
					_PlayerSt._hpDam ++;
					Time.timeScale *= 1.2f;
					_TimerForLevelLim *= 1.2f;
				}
				_TimerForLevel = 0;
			}
		}

		_ScoreText.text = (Time.timeSinceLevelLoad * 100.0f).ToString ("N0");

		if (_nearBgObj.transform.localPosition.x < -2460.0f && _SpawnChk) {			
			var Set1 = Instantiate (_enemySet, Vector3.zero, Quaternion.identity) as GameObject;
			Set1.transform.parent = _PlayerObjPool;
			Set1.transform.localScale = new Vector3 (1, 1, 1);
			Set1.transform.localPosition = Vector3.zero;
			_SpawnChk = false;
		}
		if (_nearBgObj.transform.localPosition.x > -1300.0f && !_SpawnChk) {
			_SpawnChk = true;
		}
	}

	void Regame(){
		Debug.Log ("Click!!");
		Time.timeScale = 1.0f;
		_ResultUI.SetActive (false);
		SceneManager.LoadScene ("1_play");

	}

	void GameOver(){
		_ResultUI.SetActive (true);
		_ResultText.text = "Your Score is\n" + _ScoreText.text;
		Time.timeScale = 0.0f;
	}
}
