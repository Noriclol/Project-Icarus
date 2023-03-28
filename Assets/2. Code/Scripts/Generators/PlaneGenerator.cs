using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    // The number of vertices in x axis
    public int xSize = 10;

    // The number of vertices in y axis
    public int ySize = 10;

    // The offset of the plane position
    public Vector3 offset;

    // The generated mesh
    private Mesh mesh;

    // The vertices array
    private Vector3[] vertices;

    // The triangles array
    private int[] triangles;

    // The UV array
    private Vector2[] uvs;

    private void Start()
    {
        // Create a new mesh and assign it to the mesh filter component
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Create the plane mesh
        CreatePlane();
        // Update the mesh data
        UpdateMesh();
        // Center the transform component
        CenterTransform();
    }

    private void CreatePlane()
    {
        // Calculate the number of vertices and triangles
        int vertexCount = (xSize + 1) * (ySize + 1);
        int triangleCount = xSize * ySize * 6;

        // Initialize the arrays
        vertices = new Vector3[vertexCount];
        triangles = new int[triangleCount];
        uvs = new Vector2[vertexCount];

        // Loop through the vertices and assign their positions and uvs
        int i = 0;
        
        var xHalf = xSize / 2;
        var yHalf = xSize / 2;
        
        for (int y = -yHalf; y <= yHalf; y++)
        {
            for (int x = -xHalf; x <= xHalf; x++)
            {
                // Add the offset to the vertex position
                vertices[i] = new Vector3(x, 0, y) + offset;
                uvs[i] = new Vector2((float)x / xSize, (float)y / ySize);
                i++;
            }
        }

        // Loop through the triangles and assign their indices
        int t = 0;
        int v = 0;
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[t] = v;
                triangles[t + 1] = v + xSize + 1;
                triangles[t + 2] = v + 1;
                triangles[t + 3] = v + 1;
                triangles[t + 4] = v + xSize + 1;
                triangles[t + 5] = v + xSize + 2;

                t += 6;
                v++;
            }

            v++;
        }
    }

    private void UpdateMesh()
    {
        // Clear the existing mesh data
        mesh.Clear();

        // Set the new mesh data
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Recalculate the normals and bounds
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    private void CenterTransform()
    {
        // Get the bounds of the mesh
        Bounds bounds = mesh.bounds;

        // Get the center of the bounds in world space
        Vector3 centerWorldSpace = transform.TransformPoint(bounds.center);

        // Move the transform component to the center of the bounds
        transform.position -= centerWorldSpace - transform.position;

        // Adjust the vertices positions relative to the new transform position
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += centerWorldSpace - transform.position;
        }

        // Update the mesh data with the adjusted vertices positions
        mesh.vertices = vertices;
    }
}
