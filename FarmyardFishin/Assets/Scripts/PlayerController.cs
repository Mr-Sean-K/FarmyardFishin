using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f; // player movement speed
    public float xRange = 26; // range size of player movement border
    public float yRangeUpper = 18.5f; // range size of player movement border
    public float yRangeLower = 0.5f; // range size of player movement border
    
    public float horizontalInput;
    public float verticalInput;

    public GameObject player;
    public GameObject enemy;
    public GameController gameController;
    public float Lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y < yRangeLower){
            transform.position = new Vector3(transform.position.x, yRangeLower, transform.position.z);
        }

        if (transform.position.y > yRangeUpper){
            transform.position = new Vector3(transform.position.x, yRangeUpper, transform.position.z);
        }
    }

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Lose a life and destroy the enemy
            Lives -= 1;
            Destroy(collision.gameObject);

            Debug.Log($"Lives Remaining: {Lives}");

            if (Lives <= 0)
            {
                Debug.Log("Game Over!");
                // Add game-over logic here (e.g., reload scene, show game-over UI, etc.)
            }
        }
        else if (collision.gameObject.CompareTag("Friend"))
        {
            // Attach the friend to the player
            collision.gameObject.transform.SetParent(player.transform);
            Debug.Log("Friend attached!");
        }
    }
}