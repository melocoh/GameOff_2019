using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    SpriteRenderer mySprite;

    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Sprite[] blockTrace;

    [SerializeField] private float grid = 0.5f;
    [SerializeField] private float x=0f, y=0f;

    private int blockChoice;
    private int overlap;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        blockChoice = 0;
        overlap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
        RotateBlock();
        ChooseBlock();
        MakeBlock();
        BadSpawn();
        Cursor.visible = false;
        //Debug.Log(overlap);
    }

    // Forces the block spawner onto the mouse position
    private void MousePosition() {
        transform.position = SnapToGrid.mouseGridPos();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        overlap++;
        //Debug.Log("Collided with" + col.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D col) {
        overlap--;
        //Debug.Log("Overlap decrement");
    }

    // Checks if there's any overlap with another object.
    // return true when there's overlap
    private bool SpawnCheck() {
        int layerMask = 1 << 8;
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, 0.505f, layerMask);
        return (colliders != null); 

        //return (overlap > 0);
    }

    // 
    // Returns 
    private void BadSpawn() {
        if (SpawnCheck())
            mySprite.color = Color.red;
        else
            mySprite.color = Color.white;
    }

    private void MakeBlock() {
        if (Input.GetMouseButtonUp(0) && !SpawnCheck()) {
            GameObject newBlock = Instantiate(blocks[blockChoice], transform.position, transform.rotation) as GameObject;
            //Debug.Log("Created " + newBlock.name);
        }
    }

    private void RotateBlock() {
        if (Input.GetMouseButtonUp(1)) {
            transform.Rotate(0, 0, -90);
        }
    }

    private void ChooseBlock() {
        if (Input.GetKeyUp("e")) {
            if (blockChoice == blocks.Length - 1) {
                blockChoice = 0;
                mySprite.sprite = blockTrace[blockChoice];
            } else {
                blockChoice++;
                mySprite.sprite = blockTrace[blockChoice];
            }
        } else if (Input.GetKeyUp("q")) {
            if (blockChoice == 0) {
                blockChoice = blocks.Length - 1;
                mySprite.sprite = blockTrace[blockChoice];
            } else {
                blockChoice--;
                mySprite.sprite = blockTrace[blockChoice];
            }
        }
    }

    

}
