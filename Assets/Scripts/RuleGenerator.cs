using UnityEngine;


public class RuleGenerator : MonoBehaviour
{
    static public RuleGenerator inst;
    public Rule[] rules;
    [SerializeField] Vector2 firstPos, dist;
    [SerializeField] RuleButton prefab;

    void Awake()
    {
        if(inst == null)
            inst = this;
    }

    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = prefab.GetComponent<RectTransform>().sizeDelta * new Vector2(1, rules.Length) * 1.2f;
        for (int i = 0; i < rules.Length; i++)
        {
            RuleButton rule = Instantiate(prefab, transform);
            rule.transform.localPosition = firstPos + dist * i;
            rule.Init(rules[i]);
        }
    }
}
