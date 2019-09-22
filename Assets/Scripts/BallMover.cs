using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public float speed;
    private Rigidbody ball;
    // Start is called before the first frame update
    void Start() {
        ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        ball.AddForce(movement * speed);
    }

    private void OnCollisionStay(Collision collision) {
        //Vector3 point = collision.contacts[0].point;
        foreach (var contact in collision.contacts) {
            if (!collision.gameObject.CompareTag("nope")) { 
                PlaceRedSphereAtPoint(contact.point);
            }
        }
    }

    private static void PlaceRedSphereAtPoint(Vector3 point) {
        Transform sphereTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        sphereTransform.tag = "nope";
        sphereTransform.position = point;
        sphereTransform.localScale = Vector3.one * 0.1f;
        sphereTransform.GetComponent<Renderer>().material.color = Color.red;
        sphereTransform.GetComponent<SphereCollider>().enabled = false;
    }

}
