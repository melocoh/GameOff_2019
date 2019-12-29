using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D polycol;
    Transform trans;

    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polycol = GetComponent<PolygonCollider2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        StopMoving();
    }

    private void StopMoving() {
       if (rb.velocity.y < float.Epsilon && polycol.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            Debug.Log(trans.position.y);
            
            trans.position = new Vector3(trans.position.x,
                (float) System.Math.Round(trans.position.y, 1), 0);
            Debug.Log(trans.position.y);
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
