using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> walls;
    public NavMeshSurface navMeshSurfave;
    void Start()
    {
        foreach (var wall in walls)
        {
            wall.SetActive(true);
        }
        navMeshSurfave.BuildNavMesh();
    }
}
