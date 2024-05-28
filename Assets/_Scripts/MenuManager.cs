using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] Menu[] _menus;

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (_menus[i].MenuName == menuName)
            {
                _menus[i].ChangeStatus(true);
            }
            else if (_menus[i].IsOpen)
            {
                CloseMenu(_menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            if (_menus[i].IsOpen)
            {
                CloseMenu(_menus[i]);
            }
        }
        menu.ChangeStatus(true);
    }

    public void CloseMenu(Menu menu)
    {
        menu.ChangeStatus(false);
    }
}