using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backScroll : MonoBehaviour
{
    public float scrollSpeed;

    [SerializeField] private MeshRenderer mesh;

    private void Update()
    {
        Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);
        mesh.material.mainTextureOffset = offset;
    }
}
