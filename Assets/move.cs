using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    private float speed;
    private GameManager gameManager;

    void Start()
    {
        // Get reference to GameManager to access the gameData
        gameManager = FindObjectOfType<GameManager>();

        // Set the speed from the JSON data
        speed = gameManager.gameData.player_data.speed;
    }
    void Update()
    {
        // Get input from arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical");     // Up/Down arrow keys

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the object
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
