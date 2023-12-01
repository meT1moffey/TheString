using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public record IsExternalInit;
}

[System.Serializable]
public struct Char
{
    public Color color;
    public Sprite shape;

    public Char(Color color, Sprite shape)
    {
        this.color = color;
        this.shape = shape;
    }

    public static bool operator==(Char a, Char b)
        => a.color == b.color && a.shape == b.shape;

    public static bool operator !=(Char a, Char b)
        => !(a == b);
}

public class CharEntity : MonoBehaviour
{
    static int rowLenght = 5;
    static float charsDistance = 120, rowsDistance = -120;
    static CharEntity prefab = null;

    public int index;

    public void UpdatePosition()
        => transform.localPosition = new Vector2(index % rowLenght, index / rowLenght) *
           new Vector2(charsDistance, rowsDistance);

    void Start()
    {
        UpdatePosition();
    }

    public Char GetData()
    {
        Image icon = GetComponent<Image>();
        return new(icon.color, icon.sprite);
    }

    public void Select()
    {
        MainString.inst.ApplyRule(index);
    }
}
