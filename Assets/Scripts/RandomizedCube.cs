using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RandomizedCube : MonoBehaviour
{
    [Range(0f, 0.5f)]
    public float randomOffset = 0.2f; // Максимальний оффсет

    private Mesh mesh;

    void Start()
    {
        GenerateRandomizedCube();
    }

    void GenerateRandomizedCube()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Оригінальні унікальні вершини куба (без дублювання для кожної грані)
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

        // Додаємо випадкові зміщення лише один раз до унікальних вершин
        for (int i = 0; i < baseVertices.Length; i++)
        {
            baseVertices[i] += new Vector3(
                Random.Range(-randomOffset, randomOffset),
                Random.Range(-randomOffset, randomOffset),
                Random.Range(-randomOffset, randomOffset)
            );
        }

        // Тепер створюємо вершини для граней, використовуючи зміщені унікальні вершини
        Vector3[] vertices = new Vector3[24]
        {
            // Передня сторона
            baseVertices[0], baseVertices[1], baseVertices[2], baseVertices[3],
            // Задня сторона
            baseVertices[4], baseVertices[7], baseVertices[6], baseVertices[5],
            // Ліва сторона
            baseVertices[1], baseVertices[5], baseVertices[6], baseVertices[2],
            // Права сторона
            baseVertices[0], baseVertices[3], baseVertices[7], baseVertices[4],
            // Верхня сторона
            baseVertices[0], baseVertices[4], baseVertices[5], baseVertices[1],
            // Нижня сторона
            baseVertices[3], baseVertices[2], baseVertices[6], baseVertices[7]
        };

        // Присвоюємо вершини мешу
        mesh.vertices = vertices;

        // Трикутники для куба (порядок проти годинникової стрілки)
        int[] triangles = new int[36]
        {
            // Передня сторона
            0, 1, 2,
            0, 2, 3,
            // Задня сторона
            4, 5, 6,
            4, 6, 7,
            // Ліва сторона
            8, 9, 10,
            8, 10, 11,
            // Права сторона
            12, 13, 14,
            12, 14, 15,
            // Верхня сторона
            16, 17, 18,
            16, 18, 19,
            // Нижня сторона
            20, 21, 22,
            20, 22, 23
        };

        // Присвоюємо трикутники мешу
        mesh.triangles = triangles;

        // UV-координати для кожної сторони
        Vector2[] uvs = new Vector2[24]
        {
            // Передня сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            // Задня сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            // Ліва сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            // Права сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            // Верхня сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0),
            // Нижня сторона
            new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 0)
        };

        // Присвоюємо UV-координати мешу
        mesh.uv = uvs;

        // Оновлюємо нормалі та межі
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
