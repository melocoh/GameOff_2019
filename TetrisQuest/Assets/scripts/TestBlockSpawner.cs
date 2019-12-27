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
    private int tileIndex;

    private Vector2Int[ , ] L_DATA;

    void Awake() {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        tracers = GetComponentsInChildren<Transform>();

    }

    // Start is called before the first frame update
    void Start() {
        tracers[1].transform.position = new Vector3(-0.5f, 0.5f, 0);
        tracers[2].transform.position = new Vector3(1.5f, 0.5f, 0);
        tracers[3].transform.position = new Vector3(1.5f, 1.5f, 0);
        blockChoice = 0;

        foreach(Transform t in tracers) {
            Debug.Log(t.position);
        }
    }

    // Update is called once per frame
    void Update() {
        MousePosition();
        RotateBlock();
        ChooseBlock();
        MakeBlock();
        Cursor.visible = false;
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
        if (Input.GetMouseButtonUp(1)) {
            transform.Rotate(0, 0, -90);
        }
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

    private void RepositionTiles() {
        
    }

}
