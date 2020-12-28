using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event System.Action<Block> OnBlockPressed;
    public event System.Action OnFinishedMoving;

    public Vector2Int coord;
    Vector2Int startingCoord;

    private void OnMouseDown()
    {
        if (OnBlockPressed != null)
        {
            OnBlockPressed(this);
        }
    }

    public void MoveToPosition(Vector2 target, float duration)
    {
        StartCoroutine(AnimateMove(target, duration));
    }

    public void Init(Vector2Int startingCoord, Texture2D image)
    {
        coord = startingCoord;
        this.startingCoord = startingCoord;
        GetComponent<MeshRenderer>().material.mainTexture = image;
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("BlockMaterial");
    }

    IEnumerator AnimateMove(Vector2 target, float duration)
    {
        Vector2 initPos = transform.position;
        float percent = 0;

        //lerp position based on percent - if duration = 2, time.deltatime / 2 after one second = 0.5
        while (percent < 1)
        {
            percent += Time.deltaTime / duration;
            transform.position = Vector2.Lerp(initPos, target, percent);
            yield return null;
        }

        if(OnFinishedMoving != null)
        {
            OnFinishedMoving();
        }
    }

    public bool IsAtStartingCoord()
    {
        return coord == startingCoord;
    }
}
