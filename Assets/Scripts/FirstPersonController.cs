using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

[RequireComponent (typeof (GravityBody))]
public class FirstPersonController : MonoBehaviour {
	
	public float Speed = 3;
	
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Transform cameraTransform;
	Rigidbody rb;
	
	void Awake() {
		cameraTransform = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update() {
		float inputX = Input.GetAxisRaw("Horizontal");
		Debug.Log(inputX);
		float inputY = 0.1f;
		
		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * Speed;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);

		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, inputX*50, 0) * Time.deltaTime);
		rb.MovePosition(rb.position + localMove);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}
}
