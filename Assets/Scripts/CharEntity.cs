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
    static public CharEntity Embody(Char data, Transform transform)
    {
        GameObject sym = new();
        sym.transform.parent = transform;
        sym.transform.localScale = Vector3.one;
        sym.SetActive(true);

        Image icon = sym.AddComponent<Image>();
        icon.color = data.color;
        icon.sprite = data.shape;

        return sym.AddComponent<CharEntity>();
    }
}
