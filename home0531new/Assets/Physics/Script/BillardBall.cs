using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BillardBall : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] float speed = 3.0f;
    [SerializeField] Rigidbody rigidBody;


    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce
        (
            direction * speed,
            ForceMode.Acceleration //연속적인 힘 (무게 적용)
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pillar"))
        {
            var result = Vector3.Reflect
                (
                transform.position.normalized,
                collision.contacts[0].normal
                );
            rigidBody.velocity = result * Mathf.Max(speed, 0);

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("BillardBall"))
        {
            rigidBody.AddTorque
                (
                Vector3.up * speed,
                ForceMode.Impulse // 순간적인 힘(무게 적용)
                );
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pillar"))
        {
            int randomMode = Random.Range(0, 3);
            rigidBody.interpolation = (RigidbodyInterpolation)randomMode;
        }
    }
}