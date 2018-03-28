using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator anim;
	float direcao;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
			anim.SetInteger("Direcao", (int)Input.GetAxisRaw("Horizontal"));
	}
}
