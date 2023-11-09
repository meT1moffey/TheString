using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    [SerializeField] CharData[] startString;
    [SerializeField] Char prefab;

    List<Char> list = new();

    void Start()
    {
        foreach(CharData data in startString)
        {
            Char sym = Instantiate(prefab, transform);
            sym.GetComponent<SpriteRenderer>().color = data.color;
            sym.GetComponent<SpriteRenderer>().sprite = data.shape;
            sym.index = list.Count;
            list.Add(sym);
        }
    }
}
