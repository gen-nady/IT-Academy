using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshCollider))]
public class Box : MonoBehaviour
{
    Mesh mesh, meshCut, meshNew;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenetateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        meshc.sharedMesh = mesh;
        Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        //пытаюсь создать 2 новыъ объекта треугольника
        meshCut = new Mesh();
        GetComponent<MeshFilter>().mesh = meshCut;
        meshNew = new Mesh();
        GetComponent<MeshFilter>().mesh = meshNew;
        meshNew.vertices = GenetateVerticesOne();
        meshNew.triangles = GenerateOne();
        meshCut.vertices = GenetateVerticesTwo();
        meshCut.triangles = GenerateTwo();
    
    }
    Vector3[] GenetateVertices()
    {
        return new Vector3[]
        {
                new Vector3(0f, 0f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(1f, 0f, 0f),
                new Vector3(1f, 0f, 1f)

        };
    }
    Vector3[] GenetateVerticesOne()
    {
        return new Vector3[]
        {
                new Vector3(0f, 0f, 0f),
                new Vector3(0f, 0f, 1f),
                new Vector3(1f, 0f, 0f)

        };
    }
    Vector3[] GenetateVerticesTwo()
    {
        return new Vector3[]
        {
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 2f),
                new Vector3(2f, 1f, 1f)

        };
    }
    int[] GenerateTriangles()
    {
        return new int[] { 0, 1, 2 , 1,3,2};
    }
    int[] GenerateOne()
    {
        return new int[] { 0, 1, 2};
    }
    int[] GenerateTwo()
    {
        return new int[] { 0, 1, 2 };
    }
}
