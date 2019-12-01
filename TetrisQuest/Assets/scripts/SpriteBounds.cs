using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBounds : MonoBehaviour
{
    [SerializeField] public float RightX { get; set; }
    [SerializeField] public float LeftX { get; set; }
    [SerializeField] public float Bottom { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        RecalculateSides();
    }

    public void RecalculateSides() {
        var centerX = GetComponent<BoxCollider2D>().bounds.center.x;
        var centerY = GetComponent<BoxCollider2D>().bounds.center.y;

        RightX = Mathf.CeilToInt(centerX);
        LeftX = Mathf.FloorToInt(centerX);
        Bottom = Mathf.FloorToInt(centerY);
    }

}
