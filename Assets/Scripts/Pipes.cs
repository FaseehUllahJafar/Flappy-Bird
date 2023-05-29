using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float leftBound;
    void Start()
    {
        leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // left boundary of screen. Subtracting 1 so that user don't see the object vanish
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
