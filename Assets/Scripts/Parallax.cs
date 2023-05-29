using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    //Script to move the background

    private MeshRenderer meshRenderer;
    public float animationSpeed = 1.0f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); // to move background by 1 offset 
    }
}
