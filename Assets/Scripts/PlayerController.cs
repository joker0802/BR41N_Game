using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.SocialPlatforms;

[RequireComponent (typeof (GravityBody))]
public class PlayerController : MonoBehaviour {
	
	public float Speed = 0;
	public float rotSpeed = 0;
	public int Health = 300;
	public GameObject destroyedExplosion;
	public bool isCrushed = false;

	public bool isDestroyed = false;
	public int turns = 1;
	
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Transform cameraTransform;
	Rigidbody rb;
	
	void Awake() {
		cameraTransform = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float inputX = turns * 10f;
		float inputY = 0.1f;

		Vector3 moveDir = new Vector3(0, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * Speed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, inputX * rotSpeed, 0) * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
		rb.MovePosition(rb.position + localMove);

		if(Health <= 0)
		{
			if (isDestroyed == false)
			{
				Instantiate(destroyedExplosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			}
			isDestroyed = true;
			//Debug.Log(gameObject.transform.GetChild(0).gameObject.name);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			gameObject.transform.GetChild(2).gameObject.SetActive(false);
			gameObject.transform.GetChild(3).gameObject.SetActive(false);
			Speed = 0;
			rotSpeed = 0;
		}
	}
}
