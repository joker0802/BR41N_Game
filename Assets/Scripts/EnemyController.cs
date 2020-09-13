using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityBody))]
public class EnemyController : MonoBehaviour
{
	public float Speed = 1;
	public float rotSpeed = 1;
	public int Health = 150;
	public GameObject destroyedExplosion;
	public bool isCrushed = false;

	private bool isDestroyed = false;

	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float inputX = Input.GetAxisRaw("Horizontal") * 10f;
		float inputY = 0.1f;

		Vector3 moveDir = new Vector3(0, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * Speed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, inputX * rotSpeed, 0) * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
		rb.MovePosition(rb.position + localMove);

		if (Health <= 0)
		{
			Instantiate(destroyedExplosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			isDestroyed = true;
			Destroy(gameObject);
		}
	}
}
