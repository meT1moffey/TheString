using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class String : MonoBehaviour
{
    public Char[] startString;

    public List<CharEntity> list { get; private set; } = new();

    void Start()
    {
        foreach(Char data in startString)
            list.Add(CharEntity.Embody(data, transform));
        UpdateIndexes();
    }

    void UpdateIndexes()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].index = i;
            list[i].UpdatePosition();
        }
    }

    public bool IsSubstringEquals(int begin, Char[] comparing)
    {
        if (begin + comparing.Length > list.Count)
            return false;

        for (int i = 0; i < comparing.Length; i++)
            if (list[i + begin].GetData() != comparing[i])
                return false;

        return true;
    }

    public void ReplaceSubstring(int begin, int count, Char[] replacing)
    {
        for (int i = begin; i < begin + count; i++)
            Destroy(list[i].gameObject);
        list.RemoveRange(begin, count);

        CharEntity[] replacingEntities = replacing.Select(c => CharEntity.Embody(c, transform)).ToArray();
        list.InsertRange(begin, replacingEntities);
        UpdateIndexes();
    }
}
