using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameField gameField;
    public GameObject enemy;
    public int mobCount = 3;
    public float spawningOffsetInSeconds = 10f;
    bool _justSpawned = true;

    void Start()
    {
        for (int i = 0; i < mobCount; i++)
        {
            Instantiate(enemy, gameField.GetRandomFieldPosition(), Quaternion.identity);
        }
    }
    
    void SpawnMore()
    {
        _justSpawned = true;
        mobCount += 1;
        for (int i = 0; i < mobCount; i++)
        {
            Instantiate(enemy, gameField.GetRandomFieldPosition(), Quaternion.identity);
        }
    }

    void Update()
    {
        if(_justSpawned)
        {
            _justSpawned = false;
            Invoke("SpawnMore", spawningOffsetInSeconds);
        }
    }
}