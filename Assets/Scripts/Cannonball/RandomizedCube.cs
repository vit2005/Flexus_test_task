using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RandomizedCube : MonoBehaviour
{
    [Range(0f, 0.5f)]
    public float randomOffset = 0.2f;

    private Mesh mesh;

    void Start()
    {
        GenerateRandomizedCube();
    }

    void GenerateRandomizedCube()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] baseVertices = new Vector3[8]
        {
            new Vector3(1, 1, 1),  // 0
            new Vector3(-1, 1, 1), // 1
            new Vector3(-1, -1, 1),// 2
            new Vector3(1, -1, 1), // 3
            new Vector3(1, 1, -1), // 4
            new Vector3(-1, 1, -1),// 5
            new Vector3(-1, -1, -1),// 6
            new Vector3(1, -1, -1) // 7
        };

        for (int i = 0; i < baseVertices.Length; i++)
        {
            baseVertices[i] += new Vector3(
                Random.Range(-randomOffset, randomOffset),
                Random.Range(-randomOffset, randomOffset),
                Random.Range(-randomOffset, randomOffset)
            );
        }

        Vector3[] vertices = new Vector3[24]
        {
            baseVertices[0], baseVertices[1], baseVertices[2], baseVertices[3],
            baseVertices[4], baseVertices[7], baseVertices[6], baseVertices[5],
            baseVertices[1], baseVertices[5], baseVertices[6], baseVertices[2],
            baseVertices[0], baseVertices[3], baseVertices[7], baseVertices[4],
            baseVertices[0], baseVertices[4], baseVertices[5], baseVertices[1],
            baseVertices[3], baseVertices[2], baseVertices[6], baseVertices[7]
        };

        mesh.vertices = vertices;

        int[] triangles = new int[36]
        {
            0, 1, 2,
            0, 2, 3,
            4, 5, 6,
            4, 6, 7,
            8, 9, 10,
            8, 10, 11,
            12, 13, 14,
            12, 14, 15,
            16, 17, 18,
            16, 18, 19,
            20, 21, 22,
            20, 22, 23
        };

        mesh.triangles = triangles;

        Vector2[] uvs = new Vector2[24]
        {
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0)
        };

        mesh.uv = uvs;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
