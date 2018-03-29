using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	Rigidbody2D carlos;
	public float velocidade;
	bool facingRight = true;
	void Awake(){
		 carlos = GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	public void Move(int direcao){
		carlos.velocity = (Vector2.right * velocidade * direcao);	
		if(direcao > 0 && !facingRight || direcao < 0 && facingRight)
			Flip();
		
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 thisScale = transform.localScale;
		thisScale.x *= -1;
		transform.localScale = thisScale; 		
	}
}
