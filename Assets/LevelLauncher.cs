using UnityEngine;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] Char[] startString, correctString;
    [SerializeField] Rule[] rules;

    public void Launch()
    {
        MainString.inst.startString = startString;
        MainString.inst.correct = correctString;
        RuleGenerator.inst.rules = rules;
        MenuManager.inst.SetMenu(MainString.inst.transform.parent.gameObject);
    }
}
