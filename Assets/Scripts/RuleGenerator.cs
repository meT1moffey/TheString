using UnityEngine;


public class RuleGenerator : MonoBehaviour
{
    [SerializeField] Rule[] rules;
    [SerializeField] String str;
    [SerializeField] Vector2 firstPos, dist;
    [SerializeField] RuleButton prefab;

    void Start()
    {
        for (int i = 0; i < rules.Length; i++)
        {
            RuleButton rule = Instantiate(prefab, transform);
            rule.transform.localPosition = firstPos + dist * i;
            rule.Init(rules[i], str);
        }
    }
}