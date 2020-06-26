using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] private int numberOfVertex;
    public Vector3[] vertices;
    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
        vertices = GetComponent<MeshFilter>().mesh.vertices;
        for (int i = 0; i < numberOfVertex; i++)
        {
            vertices[i] = transform.TransformPoint(vertices[i]);
        }
    }

    private void Update()
    {
        if (!IsObjectVisibleByCamera())
        {
            Destroy(this.gameObject);
        }
    }

    private bool IsObjectVisibleByCamera()
    {
        bool visible = false;
        for (int i = 0; i < numberOfVertex; i++)
        {
            Vector3 vertexToTest = cam.WorldToViewportPoint(vertices[i]);
            if (vertexToTest.z > 0 && vertexToTest.x > 0 && vertexToTest.x < 1 && vertexToTest.y > 0 && vertexToTest.y < 1)
            {
                visible = true;
            }
        }

        Vector3 centerOfObject = cam.WorldToViewportPoint(transform.position);
        if (centerOfObject.z > 0 && centerOfObject.x > 0 && centerOfObject.x < 1 && centerOfObject.y > 0 && centerOfObject.y < 1)
        {
            visible = true;
        }

        return visible;
    }
}
