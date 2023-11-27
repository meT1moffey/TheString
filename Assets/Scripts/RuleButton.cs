using System.Linq;
using UnityEngine;

[System.Serializable]
public struct Rule
{
    public Char[] generative, generated;
}

public class RuleButton : MonoBehaviour
{
    public Char[] generative, generated;
    String str;

    public void Init(Rule rule, String str_)
    {
        generative = rule.generative;
        generated = rule.generated;
        str = str_;
    }

    void Start()
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
