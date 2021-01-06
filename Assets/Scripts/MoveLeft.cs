using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    PlayerController playerController;
    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameover) return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x < -10 && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
