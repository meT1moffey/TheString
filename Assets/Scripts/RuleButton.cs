using System.Linq;
using UnityEngine;

[System.Serializable]
public struct Rule
{
    public Rule(Char[] generative_, Char[] generated_)
    {
        generative = generative_;
        generated = generated_;
    }

    public Char[] generative, generated;
}

public class RuleButton : MonoBehaviour
{
    public Char[] generative, generated;

    public void Init(Rule rule)
    {
        generative = rule.generative;
        generated = rule.generated;
    }

    void Start()
    {
        Vector2 size = GetComponent<RectTransform>().rect.size;
        GameObject ruleStr = new();

        ruleStr.transform.parent = transform;
        ruleStr.transform.localScale = Vector3.one * 0.5f;
        ruleStr.transform.localPosition = Vector2.left * size * 0.4f;
        ruleStr.AddComponent<String>().startString = generative.Concat(new[] { new Char(new(0, 0, 0, 0), null) }).Concat(generated).ToArray();
    }

    Rule GetData() => new(generative, generated);

    public void Select() => MainString.inst.curRule = GetData();
}
