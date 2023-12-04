using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainString : String
{
    static public MainString inst;
    public CharEntity charEntity;

    [SerializeField] Char[] correct;
    [SerializeField] String correctEntity;
    [SerializeField] GameObject winMenu;

    public Rule? curRule;
    List<(Rule, int)> history = new();

    void Awake()
    {
        if(inst == null)
            inst = this;

        correctEntity.startString = correct;
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
        history.Add((curRule.Value, begin));

        if (list.Count == correct.Length && IsSubstringEquals(0, correct))
            MenuManager.inst.SetMenu(winMenu);
    }

    public void Undo()
    {
        if (history.Count == 0)
            return;

        var undoing = history.Last();
        ReplaceSubstring(undoing.Item2, undoing.Item1.generated.Length, undoing.Item1.generative);
        history.RemoveAt(history.Count - 1);
    }

    public void ResetString()
    {
        ReplaceSubstring(0, list.Count, startString);
        history.Clear();
    }
}
