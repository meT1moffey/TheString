using UnityEngine;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject[] preloaded;
    GameObject prevMenu, curMenu;
    static public MenuManager inst;

    void OnEnable()
    {
        if(inst == null)
            inst = this;

        curMenu = startMenu;
        foreach(GameObject menu in preloaded)
            SetMenu(menu);
    }

    void Start()
    {
        SetMenu(startMenu);
    }

    public void SetMenu(GameObject newMenu)
    {
        (prevMenu = curMenu).SetActive(false);
        (curMenu = newMenu).SetActive(true);
    }

    public void Back()
        => SetMenu(prevMenu);
}
