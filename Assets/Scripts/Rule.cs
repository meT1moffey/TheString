using System.Linq;
using UnityEngine;

public class Rule : MonoBehaviour
{
    [SerializeField] Char[] generative, generated;
    [SerializeField] String str;

    void Awake()
    {
        Vector2 size = GetComponent<RectTransform>().rect.size;
        GameObject ruleStr = new();

        ruleStr.transform.parent = transform;
        ruleStr.transform.localScale = Vector3.one * 0.5f;
        ruleStr.transform.localPosition = Vector2.left * size / 2;
        ruleStr.AddComponent<String>().startString = generative.Concat(new[] { new Char(new(0, 0, 0, 0), null) }).Concat(generated).ToArray();
    }

    public bool Use(int begin)
    {
        if (!str.IsSubstringEquals(begin, generative))
            return false;

        str.ReplaceSubstring(begin, generative.Length, generated);
        return true;
    }

    public void UseOnFirst()
    {
        for(int i = 0; i < str.list.Count && !Use(i); i++);
    }
}
