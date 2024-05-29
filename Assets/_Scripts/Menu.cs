using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;

    public void ChangeStatus(bool status)
    {
        open = status;
        gameObject.SetActive(status);
    }
}