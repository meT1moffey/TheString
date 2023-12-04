using UnityEngine;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject curMenu;
    static public MenuManager inst;

    void Start()
    {
        if(inst == null)
            inst = this;
    }

    public void SetMenu(GameObject newMenu)
    {
        curMenu.SetActive(false);
        (curMenu = newMenu).SetActive(true);
    }
}
