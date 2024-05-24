using UnityEngine;

public class Menu : MonoBehaviour
{
    public string MenuName;
    public bool IsOpen;

    public void ChangeStatus(bool status)
    {
        IsOpen = status;
        gameObject.SetActive(true);
    }
}