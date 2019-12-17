using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private float dropInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropRock());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DropRock()
    {
        while (true) {
            GameObject newBlock = Instantiate(rock, transform.position, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(dropInterval);
        }
    }


}
