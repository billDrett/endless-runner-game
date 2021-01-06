using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] float spawnInterval = 3f;

    PlayerController playerController;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;


    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObsticle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObsticle()
    {
        if (playerController.isGameover) return;
        Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation);
    }
}
