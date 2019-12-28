using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D polycol;

    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polycol = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StopMoving();
    }

    private void StopMoving() {
       if (rb.velocity.y < float.Epsilon && polycol.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
