using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    [SerializeField] public const float GRID = 0.5f;

    public static Vector3 mouseGridPos() {
        float recip = 1f / GRID;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = Mathf.Round(mousePos.x * recip) / recip - GRID;
        float y = Mathf.Round(mousePos.y * recip) / recip - GRID;

        return new Vector3(x, y, 0);
    }

    public static Vector3 gridPos(Vector3 position) {
        float recip = 1f / GRID;

        position = Camera.main.ScreenToWorldPoint(position);
        float x = Mathf.Round(position.x * recip) / recip - GRID;
        float y = Mathf.Round(position.y * recip) / recip - GRID;

        return new Vector3(x, y, 0);
    }

}
