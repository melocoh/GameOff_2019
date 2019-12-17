using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        Destroy(transform.parent.gameObject);
    }
}
