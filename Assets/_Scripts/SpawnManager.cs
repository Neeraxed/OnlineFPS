using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private Spawnpoint[] _spawnpoints;

    void Awake()
    {
        Instance = this;
        _spawnpoints = GetComponentsInChildren<Spawnpoint>();
    }

    public Transform GetSpawnpoint()
    {
        return _spawnpoints[Random.Range(0, _spawnpoints.Length)].transform;
    }
}
