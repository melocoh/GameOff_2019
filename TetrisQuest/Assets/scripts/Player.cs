﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private Vector3 startPos;

    // State
    private bool isDead;

    // Cached references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CircleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    Scene scene;

    // Start is called before the first frame update
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CircleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        startPos = new Vector3(transform.position.x, transform.position.y);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update() {
        Jump();
        CheckDeath();
  
    }

    void FixedUpdate() {
        Run();
        FlipSprite();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hazard")
        {
            isDead = true;
            Debug.Log("Died");
        }
    }

    private void Run() {
        float controlThrow = Input.GetAxis("Horizontal");
        myRigidBody.velocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);

        bool isMoving = Mathf.Abs(myRigidBody.velocity.x) > 0;
        myAnimator.SetBool("running", isMoving);
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") 
            && (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) 
            || myFeet.IsTouchingLayers(LayerMask.GetMask("Block")))) {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocity;
        }
    }

    private void FlipSprite() {
        bool isMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (isMoving) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void CheckDeath()
    {
        if (isDead)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
