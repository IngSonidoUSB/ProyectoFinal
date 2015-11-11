using UnityEngine;
using System.Collections;

public class ThirdPersonControllerDM : MonoBehaviour
{
	public Transform player;
	public float forwardSpeed = 3f;
	public float runSpeed = 3f;
	public float turnSpeed = 3f;

	private Animator animator;


	// Use this for initialization
	void Start ()
	{
		//Player = this.transform.parent.GetComponent(Transform);
		//Player = transform.parent;
		animator = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//bool crouch = Input.GetKey(KeyCode.C);
		float totalSpeed = forwardSpeed;

		if(Input.GetKey(KeyCode.LeftShift))
		{
			if(v > 0.1f){
				Debug.Log("Shift Presionado");
				totalSpeed +=runSpeed;
				animator.SetBool("run", true);
			}
		}else{
			animator.SetBool("run", false);
		}

		//Debug.Log("Horizontal: " + h);
		//Debug.Log("Vertical: " + v);

		animator.SetFloat("speed",v * totalSpeed);
		animator.SetFloat("steering",h);

		if (Input.GetKey (KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)) {
			animator.SetBool("jump",true);
		}else{
			animator.SetBool("jump",false);
		}

		//Debug.Log("Velocidad " + v * totalSpeed);

		transform.Translate(Vector3.forward * v * totalSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up, h * turnSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
