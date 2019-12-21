using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockSpawner : MonoBehaviour {
    SpriteRenderer mySprite;

    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Sprite[] blockTrace;
    [SerializeField] private Transform[] tracers;

    [SerializeField] private float grid = 0.5f;
    [SerializeField] private float x = 0f, y = 0f;

    private int blockChoice;

    private Vector2Int[ , ] L_DATA;

    void Awake() {
        L_DATA = new Vector2Int[3, 2];
        L_DATA[0, 0] = new Vector2Int(-1, 0);
    }

    // Start is called before the first frame update
    void Start() {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        tracers = GetComponentsInChildren<Transform>();
        blockChoice = 0;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        MousePosition();
        RotateBlock();
        ChooseBlock();
        MakeBlock();
    }

    // Forces the block spawner onto the mouse position
    private void MousePosition() {
        transform.position = SnapToGrid.mouseGridPos();
    }

    // Checks if the area around the spawner is blocked or not
    private bool spawnCheck() {
        int layerMask = 1 << 8;
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, 0.75f, layerMask);
        return (colliders != null);
    }

    private void MakeBlock() {
        if (Input.GetMouseButtonUp(0) && !spawnCheck()) {
            // TODO: Create game block based off of which block the tracer is and what rotation it is at

        }
    }

    private void RotateBlock() {
        // TODO: Rotate tracer blocks based on what block it is and what position its at

    }

    // TODO: Change the tracer block when pressing Q and E
    private void ChooseBlock() {
        if (Input.GetKeyUp("e")) {
            if (blockChoice == blocks.Length - 1) {
                blockChoice = 0;
            } else {
                blockChoice++;
            }
        } else if (Input.GetKeyUp("q")) {
            if (blockChoice == 0) {
                blockChoice = blocks.Length - 1;
            } else {
                blockChoice--;
            }
        }
    }



}
