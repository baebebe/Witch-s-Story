using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	
	public float _speed = 2.0f;
	public Animator _anim;
	public int _hp = 100;
	public int _hpDam = 1;
	private float _halfHeight;
	private bool pressed = false;
	public GameObject _DamageEff;
	public UISprite _GaugeBarWidget;

	// Use this for initialization
	void Start () {
		_halfHeight = Screen.height * 0.5f;	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("halfheight" + _halfHeight);

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		h = h * _speed * Time.deltaTime;
		v = v * _speed * Time.deltaTime;

		transform.Translate (Vector3.up * v);
		transform.Translate (Vector3.right * h);

		transform.localPosition = new Vector3 (Mathf.Clamp(transform.localPosition.x, -416.0f, 450.0f), Mathf.Clamp (transform.localPosition.y, -270.0f, 250.0f), transform.localPosition.z);

	}

	void OnTriggerEnter(Collider other){
		_hp -= _hpDam;
		_GaugeBarWidget.fillAmount = _hp * 0.01f;

		if (_hp <= 0) {
			GameObject.Find ("GM").SendMessage ("GameOver", SendMessageOptions.DontRequireReceiver);
		} else {
			_anim.SetTrigger("damageChk");
			var _Eff1 = Instantiate (_DamageEff, transform.localPosition, Quaternion.identity) as GameObject;
			_Eff1.transform.parent = transform;
			_Eff1.transform.localPosition = Vector3.zero;
			_Eff1.transform.localScale = new Vector3 (1, 1, 1);
		}

	}


}
