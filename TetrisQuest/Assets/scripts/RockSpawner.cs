using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropRock", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DropRock()
    {
        Debug.Log("Working");
        GameObject newBlock = Instantiate(rock, transform.position, Quaternion.identity) as GameObject;
    }
}
