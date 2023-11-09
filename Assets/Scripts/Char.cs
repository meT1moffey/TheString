using UnityEngine;
using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public record IsExternalInit;
}

[System.Serializable]
public struct CharData
{
    public Color color;
    public Sprite shape;
}

public class Char : MonoBehaviour
{
    static int rowLenght = 4;
    static float charsDistance = 1.0f, rowsDistance = -1.0f;

    public int index;

    void UpdatePosition()
        => transform.localPosition = new Vector2(index % rowLenght, index / rowLenght) * new Vector2(charsDistance, rowsDistance);

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        UpdatePosition();
    }
}
