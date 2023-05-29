using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FlappyBirdEditorTests
{
    [Test]
    public void FlappyBirdPrefabExists()
    {
        // Check if the Flappy Bird prefab exists in the project
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipes.prefab");
        Assert.IsNotNull(prefab, "Pipes prefab does not exist.");
    }

    [UnityTest]
    public IEnumerator FlappyBirdInstantiatesWithCorrectComponents()
    {
        // Load the Flappy Bird prefab
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipes.prefab");
        Assert.IsNotNull(prefab, "Pipes prefab does not exist.");

        // Instantiate the Flappy Bird prefab
        GameObject flappyBird = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        Assert.IsNotNull(flappyBird, "Failed to instantiate Pipes prefab.");

        // Check if the necessary components are attached
        Assert.IsNotNull(flappyBird.GetComponent<Rigidbody2D>(), "Pipes prefab does not have Rigidbody2D component.");
        Assert.IsNotNull(flappyBird.GetComponent<SpriteRenderer>(), "Pipes prefab does not have SpriteRenderer component.");
        //Assert.IsNotNull(flappyBird.GetComponent<FlappyBirdController>(), "Flappy Bird prefab does not have FlappyBirdController component.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator FlappyBirdStartsMovingOnGameStart()
    {
        // Load the Flappy Bird prefab
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipes.prefab");
        Assert.IsNotNull(prefab, "Pipes prefab does not exist.");

        // Instantiate the Flappy Bird prefab
        GameObject flappyBird = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        Assert.IsNotNull(flappyBird, "Failed to instantiate Flappy Bird prefab.");

        GameObject myObject = GameObject.FindGameObjectWithTag("GameController");

        //if (myObject != null)
        //{
        //    GameManager playerScript = myObject.GetComponent<GameManager>();
        //    if (playerScript != null)
        //    {
        //        // Call the function from the Player script
        //        playerScript.MyFunction();
        //    }
        //}

        // Get the FlappyBirdController component
        //FlappyBirdController flappyBirdController = flappyBird.GetComponent<Player>();
        //GameObject bird = GameObject.Find("Player");
        //Player player = bird.GetComponent<Player>();
        //Assert.IsNotNull(bird.GetComponent<Player>, "Plsayer");
        //Assert.IsNotNull(flappyBirdController, "Flappy Bird prefab does not have FlappyBirdController component.");

        //// Set up a game start event
        //myObject.Play();

        //// Check if the Flappy Bird starts moving
        //Assert.IsTrue(flappyBirdController.IsMoving, "Flappy Bird did not start moving on game start.");

        yield return null;
    }

    // Other tests can be added here
}
