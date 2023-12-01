using System.Linq;
using UnityEngine.UI;

public class MainString : String
{
    static public MainString inst;
    public CharEntity charEntity;

    public Rule? curRule;

    void Awake()
    {
        if(inst == null)
            inst = this;
    }

    bool IsSubstringEquals(int begin, Char[] comparing)
    {
        if (begin + comparing.Length > list.Count)
            return false;

        for (int i = 0; i < comparing.Length; i++)
            if (list[i + begin].GetData() != comparing[i])
                return false;

        return true;
    }

    void ReplaceSubstring(int begin, int count, Char[] replacing)
    {
        for (int i = begin; i < begin + count; i++)
            Destroy(list[i].gameObject);
        list.RemoveRange(begin, count);

        CharEntity[] replacingEntities = replacing.Select(c => Embody(c, transform)).ToArray();
        list.InsertRange(begin, replacingEntities);
        UpdateIndexes();
    }

    public void ApplyRule(int begin)
    {
        if (curRule == null)
            return;
        if (!IsSubstringEquals(begin, curRule.Value.generative))
            return;

        ReplaceSubstring(begin, curRule.Value.generative.Length, curRule.Value.generated);
        curRule = null;
    }
}
