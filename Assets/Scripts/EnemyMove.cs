using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
	[SerializeField]
	float detectionRadius;
	[SerializeField]
	GameObject player;
	[SerializeField]
	float speed;

	bool playerDetected;
	Rigidbody rb;
	Vector3 playerToEnemy;

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
		Gizmos.DrawSphere(transform.position, detectionRadius);
	}

	// Start is called before the first frame update
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// void LookForPlayer()
	// {
	// 	targetDirection = Vector3.Normalize(target.transform.position - transform.position);
	// 	RaycastHit hit;
	//
	// }

	// Update is called once per frame
	void FixedUpdate()
	{
		playerToEnemy = (player.transform.position - transform.position).normalized;
		RaycastHit hit;

		if (Physics.Raycast(transform.position, playerToEnemy, out hit, detectionRadius))
		{
			Debug.DrawRay(transform.position, playerToEnemy * hit.distance, Color.red);
			if (hit.collider.gameObject.CompareTag("Player"))
			{
				rb.AddForce(playerToEnemy * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
			}
		}
	}
}
