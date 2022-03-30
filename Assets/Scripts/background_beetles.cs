using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_beetles : MonoBehaviour
{

    [SerializeField] Vector2 scrollSpeed;


    private MeshRenderer meshRenderer;


    void Start()
    {

        transform.SetPositionAndRotation(Vector3.zero, transform.rotation);
        
        meshRenderer = GetComponent<MeshRenderer>();


    }

    void Update()
    {
        meshRenderer.material.SetVector("_ScrollSpeed", scrollSpeed);

    }

}