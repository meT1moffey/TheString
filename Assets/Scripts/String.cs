using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class String : MonoBehaviour
{
    public Char[] startString;
    
    public List<CharEntity> list { get; protected set; } = new();

    void Start()
    {
        foreach (Char data in startString)
        {
            list.Add(Embody(data, transform));
            list.Last().GetComponent<Button>().enabled = this is MainString;
        }
        UpdateIndexes();
    }

    protected void UpdateIndexes()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].index = i;
            list[i].UpdatePosition();
        }
    }

    public CharEntity Embody(Char data, Transform transform)
    {
        CharEntity sym = Instantiate(MainString.inst.charEntity, transform);
        sym.transform.parent = transform;
        sym.transform.localScale = Vector3.one;

        Image icon = sym.GetComponent<Image>();
        icon.color = data.color;
        icon.sprite = data.shape;

        sym.GetComponent<Button>().enabled = this is MainString;

        return sym;
    }
}
