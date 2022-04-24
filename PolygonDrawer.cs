﻿using Tiled2Unity;
using UnityEngine;

/// <summary>
/// 绘制多边形
/// TODO: 存在两点重合时绘制有问题
/// </summary>
public class PolygonDrawer : MonoBehaviour
{
    public Material material;
    private MeshRenderer mRenderer;
    private MeshFilter mFilter;
    public Vector3[] vertices;

    void Start()
    {
      //  Draw();
    }

    void Update()
    {
      //  Draw();
    }

    [ContextMenu("Draw")]
    public void Draw()
    {
        Vector2[] vertices2D = new Vector2[vertices.Length];
        Vector3[] vertices3D = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertice = vertices[i];
            vertices2D[i] = new Vector2(vertice.x, vertice.y);
            vertices3D[i] = vertice;
        }

        Triangulator tr = new Triangulator(vertices2D);
        int[] triangles = tr.Triangulate();

        Mesh mesh = new Mesh();
        mesh.vertices = vertices3D;
        mesh.triangles = triangles;

        if (mRenderer == null)
        {
            mRenderer = GetOrAddComponent<MeshRenderer>();
        }
        mRenderer.material = material;
        if (mFilter == null)
        {
            mFilter = GetOrAddComponent<MeshFilter>();
        }
        mFilter.mesh = mesh;
    }
    private  T GetOrAddComponent<T>() where T : UnityEngine.Component
    {
        // Get the component if it exists
        T component = gameObject.GetComponent<T>();
        if (component != null)
            return component;

        // Add the component
        return gameObject.AddComponent<T>();
    }
}