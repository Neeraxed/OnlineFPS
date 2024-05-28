using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField] private GameObject _graphics;

    private void Awake()
    {
        _graphics.SetActive(false);
    }
}
