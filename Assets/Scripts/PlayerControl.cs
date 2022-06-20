using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	private Rigidbody rigid;
	
	//velocidade de movimento e forca do pulo
    [SerializeField]
	private float move_speed, jump_force;
	
	//se o botao de pulo foi apertado
	private bool jump_btn;
	
	//layer do raycast de pulo
	[SerializeField]
	private LayerMask jump_layer;
	
	[SerializeField]
	private float rc_offset, rc_dist;

	//joystick mobile
	[SerializeField]
	private FixedJoystick moveStick;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
	
    private void Update()
    {
        if(Input.GetButtonDown("Jump")) JumpButton();

		//teste input de touch
		if(Input.touchCount > 0)
        {
			//variavel de toque
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began)
				print("toque began");
			else if(touch.phase == TouchPhase.Moved)
				print("toque moved");
			else if(touch.phase == TouchPhase.Ended)
				print("toque ended");
        }
    }
	
	private void FixedUpdate()
	{
		//versao teclado
		//vetor de inputs de movimento
		//Vector3 move_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

		//pega os floats do joystick
		Vector3 move_input = new Vector3(moveStick.Horizontal, 0, moveStick.Vertical).normalized;

		//multiplica o input pela velocidade
		move_input *= move_speed;
		//movimento
		rigid.velocity = new Vector3(move_input.x, rigid.velocity.y, move_input.z);
		
		//botao de pulo pressionado
		if(jump_btn)
		{
			RaycastHit hit;
			//debug pra ver porque o raycast nao ta funfando pela 40000a vez
			//Debug.DrawRay(transform.position + (Vector3.up * rc_offset), -Vector3.up * rc_dist, Color.green, 1f);
			//faz um raycast
			if(Physics.Raycast(transform.position + (Vector3.up * rc_offset), -Vector3.up, out hit, Mathf.Infinity, jump_layer))
			{
				//se o raycast acertou algo na distancia especificada
				if(hit.distance <= rc_dist)
				{
					//pula
					rigid.AddForce(Vector3.up * jump_force, ForceMode.Acceleration);
				}
			}
			
			//no FixedUpdate pro input de pulo nao virar false antes do pulo acontecer
			jump_btn = false;
		}
	}

	public void JumpButton()
    {
		jump_btn = true;
    }
}
