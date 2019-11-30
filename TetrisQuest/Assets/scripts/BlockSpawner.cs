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

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        blockChoice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
        RotateBlock();
        ChooseBlock();
        MakeBlock();
    }

    private void MousePosition() {
        transform.position = SnapToGrid.mouseGridPos();
    }

    private bool spawnCheck()
    {
        int layerMask = 1 << 8;
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, 0.75f, layerMask);
        return (colliders != null);
    }

    private void MakeBlock() {
        if (Input.GetMouseButtonUp(0) && !spawnCheck()) {
            GameObject newBlock = Instantiate(blocks[blockChoice], transform.position, transform.rotation) as GameObject;
        }
    }

    private void RotateBlock() {
        if (Input.GetMouseButtonUp(1)) {
            transform.rotation *= Quaternion.Euler(Vector3.forward * 90);
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
