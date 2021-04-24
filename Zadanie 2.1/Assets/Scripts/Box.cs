using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Box : MonoBehaviour
{
    Mesh mesh, meshNew;
    GameObject newObj;

    void Start()
    {
        //создание первого обьекта и делаем его квадратным
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenetateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        meshc.sharedMesh = mesh;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //создаем второй обьект треугольник
            newObj = new GameObject("NewBox");
            meshNew = new Mesh();
            newObj.AddComponent<MeshFilter>();
            newObj.AddComponent<MeshRenderer>();
            newObj.GetComponent<MeshFilter>().mesh = meshNew;
            meshNew.vertices = GenetateVerticesTwo();
            meshNew.triangles = GenerateTriangles();
            meshNew.RecalculateNormals();
            MeshCollider meshc = newObj.AddComponent<MeshCollider>();
            newObj.transform.GetComponent<MeshCollider>().convex = true;
            newObj.AddComponent<Rigidbody>();

            //первый обьект преврщаем в треугольник
            mesh.vertices = GenetateVerticesOne();
            mesh.triangles = GenerateTriangles();
        }
    }
    Vector3[] GenetateVertices()
    {
        return new Vector3[]
        {
                new Vector3(0f, 0f, 0f),
                new Vector3(1f, 0f, 0f),
                new Vector3(1f, 0f, 1f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 1f, 0f),
                new Vector3(1f, 1f, 0f),
                new Vector3(1f, 1f, 1f),
                new Vector3(0f, 1f, 1f)
        };
    }
    Vector3[] GenetateVerticesOne()
    {
        return new Vector3[]
        {
               new Vector3(0f, 0f, 0f),
                new Vector3(1f, 0f, 0f),
                new Vector3(1f, 0f, 0.5f),
                new Vector3(0f, 0f, 0.5f),
                new Vector3(0f, 1f, 0f),
                new Vector3(1f, 1f, 0f),
                new Vector3(1f, 1f, 0.5f),
                new Vector3(0f, 1f, 0.5f)
        };
    }
    Vector3[] GenetateVerticesTwo()
    {
        return new Vector3[]
        {
                 new Vector3(0f, 0f, 0.5f),
                new Vector3(1f, 0f, 0.5f),
                new Vector3(1f, 0f, 1f),
                new Vector3(0f, 0f, 1f),
                new Vector3(0f, 1f, 0.5f),
                new Vector3(1f, 1f, 0.5f),
                new Vector3(1f, 1f, 1f),
                new Vector3(0f, 1f, 1f)
        };
    }
    int[] GenerateTriangles()
    {
        return new int[] { 0, 1, 3, 1, 2, 3, 0, 4, 5, 0, 5, 1, 7, 6, 5, 7, 5, 4, 3, 2, 6, 3, 6, 7, 7, 0, 3, 7, 4, 0, 6, 2, 1, 6, 1, 5 };
    }
}
