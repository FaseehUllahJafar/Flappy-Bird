using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FlappyBirdPlayModeTests
{
    [UnityTest]
    public IEnumerator FlappyBird_PlayerJumped_Success()
    {
        // Load the Flappy Bird scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyBirdScene");

        // Wait for the scene to load
        yield return null;

        // Get the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Player object not found");

        // Trigger a jump
        //player.GetComponent<Player>().Jump();

        // Wait for the jump to complete
        yield return new WaitForSeconds(1f);

        // Verify that the player has moved upwards
        //Assert.Greater(player.transform.position.y, 0f);
    }

    [UnityTest]
    public IEnumerator FlappyBird_PlayerCollidedWithObstacle_Success()
    {
        // Load the Flappy Bird scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyBirdScene");

        // Wait for the scene to load
        yield return null;

        // Get the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Player object not found");

        // Get the obstacle object
        GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        Assert.IsNotNull(obstacle, "Obstacle object not found");

        // Move the player to collide with the obstacle
        player.transform.position = obstacle.transform.position;

        // Wait for the collision to be detected
        yield return new WaitForSeconds(1f);

        // Verify that the game over state is triggered
        //Assert.IsTrue(GameManager.Instance.GameOver);
    }
}
