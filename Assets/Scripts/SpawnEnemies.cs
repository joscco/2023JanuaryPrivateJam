using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameField gameField;
    public GameObject enemy;
    public int mobCount = 3;
    bool _spawned = true;

    void Start()
    {
        for (int i = 0; i < mobCount; i++)
        {
            Instantiate(enemy, gameField.GetRandomFieldPosition(), Quaternion.identity);
        }
    }


    void SpawnMore()
    {
        _spawned = true;
        mobCount += 1;
        for (int i = 0; i < mobCount; i++)
        {
            Instantiate(enemy, gameField.GetRandomFieldPosition(), Quaternion.identity);
        }
    }

    void Update()
    {
        if(_spawned)
        {
            _spawned = false;
            Invoke("SpawnMore",10);
        }
    }
}