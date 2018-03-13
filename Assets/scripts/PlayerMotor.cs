using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;




public class PlayerMotor : MonoBehaviour {


	public float walkSpeed;
	public float runSpeed;
	public float duckSpeed;
	public float inAirSpeed;

	public float jumpImpulse;

	public Transform groundCheckPoint;
	public LayerMask whatIsGround;
	public Transform spawnInicial;



	private Rigidbody2D body;
	private Vector2 movement;
	private BoxCollider2D cabeza;
	private CapsuleCollider2D cuerpo;
	private float horInput;

	private bool jumpInput;
	private bool grounded;
	private bool allowDobleJump;
	private bool yaSaltoDoble;
	private bool jumping;

	private Animator anim;

	private bool faceingRigth;

	private float actualSpeed;


	private bool duckInput;
	private bool runInput;




	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody2D>();
		this.cabeza = this.GetComponent<BoxCollider2D>();
		this.cuerpo = this.GetComponent<CapsuleCollider2D> ();

		this.movement = new Vector2();
		this.grounded = false;
		this.allowDobleJump = false;
		this.jumping = false;
		this.yaSaltoDoble = false;

		if (spawnInicial != null)
			body.transform.position = spawnInicial.position;




		this.anim = this.GetComponent<Animator> ();
		this.faceingRigth = true;


		actualSpeed = walkSpeed;

	}
	
	// Update is called once per frame
	void Update () {

		if (Physics2D.OverlapCircle (groundCheckPoint.position, 0.2f, whatIsGround)) {
			this.grounded = true;
			actualizarVariablesGrounded ();
		} else {
			this.grounded = false;
		}

		setearInputs ();

		chequearInputs ();

		setearVariablesAnim ();

	

	}
	void FixedUpdate(){
		actualizarVelocidades ();

	

	}
	private void setearInputs(){

		if (Input.GetAxis ("Horizontal") == 0) {
			/*float axisInput = CrossPlatformInputManager.GetAxis ("Horizontal");
			if (Mathf.Abs (axisInput) > 0.2)
				this.horInput = axisInput / Mathf.Abs (axisInput);
			else
				this.horInput = 0;*/

		} else {
			this.horInput = Input.GetAxis ("Horizontal");
		}
	
		if (CrossPlatformInputManager.GetButtonDown ("Derecha"))
			this.horInput = 1;
		if (CrossPlatformInputManager.GetButtonUp ("Derecha"))
			this.horInput = 0;
		if (CrossPlatformInputManager.GetButtonDown ("Izquierda"))
			this.horInput = -1;
		if (CrossPlatformInputManager.GetButtonUp ("Izquierda"))
			this.horInput = 0;
		
		/*this.jumpInput = (Input.GetKey(KeyCode.Space)) || (Input.GetKey(KeyCode.UpArrow)) ||(CrossPlatformInputManager.GetButton("Cruz")) ||((CrossPlatformInputManager.GetAxis("Vertical")) > 0.3);*/
		this.jumpInput = (Input.GetKey(KeyCode.Space))||(CrossPlatformInputManager.GetButton("Cruz"));

		this.duckInput = CrossPlatformInputManager.GetButton("Circulo")||(Input.GetKey (KeyCode.LeftControl)) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S))  ;


		this.runInput = Input.GetKey (KeyCode.LeftShift) || (Mathf.Abs (CrossPlatformInputManager.GetAxis ("Horizontal")) > 0.8) ;
	}
	private void setearVariablesAnim(){
		this.anim.SetFloat ("horSpeed", Mathf.Abs(this.body.velocity.x));
		this.anim.SetFloat ("verSpeed", this.body.velocity.y);
		this.anim.SetBool ("shift", runInput);
		this.anim.SetBool ("duckInput", duckInput);
		this.anim.SetBool ("estaQuieto", estaQuieto ());
	
	}
	private void chequearInputs(){


		if ((horInput < 0) && (this.faceingRigth)) {
			this.Flip ();
			this.faceingRigth = false;
		} else if ((horInput > 0) && !(this.faceingRigth)) {
			this.Flip ();
			this.faceingRigth = true;
		}




		if (runInput && grounded && !duckInput) {
			actualSpeed = runSpeed;

		} else if (duckInput && grounded) {
			actualSpeed = duckSpeed;
			cabeza.enabled = false;

		} else if (grounded){
			actualSpeed = walkSpeed;
			cabeza.enabled = true;
		}
	}
	private void actualizarVelocidades(){
		this.movement = this.body.velocity;

		bool yaSaltoEnEsteFrame = false;



		if (Input.anyKey) {
			this.movement.x = horInput * actualSpeed;

		}
		if (!grounded && jumping && !jumpInput && !yaSaltoDoble) {
			this.allowDobleJump = true;
		}

		if (this.jumpInput && this.grounded && !this.duckingInputDown() && !yaSaltoEnEsteFrame ) {
			if (estaQuieto ()) {
				actualSpeed = inAirSpeed;
			}
			anim.SetTrigger ("salto");
			this.movement.y = jumpImpulse;
			yaSaltoEnEsteFrame = true;
			yaSaltoDoble = false;
			this.jumping = true;

		}

		if (jumpInput && this.allowDobleJump && !yaSaltoEnEsteFrame ) { // doble salto
			this.movement.y = jumpImpulse;
			anim.SetTrigger ("dobleSalto");
			allowDobleJump = false;
			yaSaltoDoble = true;

		}


		if (float.IsNaN (movement.x))
			movement.x = 0;
		if (float.IsNaN (movement.y))
			movement.y = 0;
		this.body.velocity = this.movement;
	}
	private void actualizarVariablesGrounded(){
		this.allowDobleJump = false;
		this.jumping = false;
	}

	void Flip(){
		Vector3 scale = this.transform.localScale;
		scale.x *= -1;
		this.transform.localScale = scale;
	}

	public bool duckingInputDown(){
		return duckInput;
	}
	public bool isGrounded(){
		return grounded;
	}
	public bool jumpInputDown(){
		return jumpInput;
	}
	public void impulsoEnX(float impulso){
		Vector2 vector = this.body.velocity;
		vector.x = -this.transform.localScale.x * impulso;

		body.velocity = vector;
	}
	public void impulsoEnY(float impulso){
		Vector2 vector = this.body.velocity;
		vector.y = impulso;

		body.velocity = vector;
	}
	public float getWalkSpeed(){
		return this.walkSpeed;
	}
	public bool estaQuieto(){
		return (body.velocity.x == 0);
	}
	public void enSalto(){
		this.allowDobleJump = true;
	}
	public bool estaSaltando(){
		return jumping;
	}
	public bool estaCayendo(){
		return (body.velocity.y < -1);
	}

}
