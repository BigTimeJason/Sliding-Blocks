using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event System.Action<Block> OnBlockPressed;
    public Vector2Int coord;

    private void OnMouseDown()
    {
        if (OnBlockPressed != null)
        {
            OnBlockPressed(this);
        }
    }

    public void Init(Vector2Int startingCoord, Texture2D image)
    {
        coord = startingCoord;

        GetComponent<MeshRenderer>().material.mainTexture = image;
        GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Texture");
    }
}
