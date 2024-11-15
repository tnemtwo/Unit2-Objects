using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private List<Enemy> listOfAllEnemiesAlive;
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        StartCoroutine(SpawnWaveOfEnemies());
        SpawnEnemy();
    }

    private Enemy SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPointsArray.Length);
        Transform randomSpawnPoint = spawnPointsArray[randomIndex];

        Enemy enemyClone = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        listOfAllEnemiesAlive.Add(enemyClone);
        return enemyClone;
        //enemyClone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
    }

    public void RemoveEnemyFromList(Enemy enemyToBeRemoved)
    {

        listOfAllEnemiesAlive.Remove(enemyToBeRemoved);

        /*
        for(int index = 0; index < listOfAllEnemiesAlive.Count; index++)
        {
            if(listOfAllEnemiesAlive[index] == null)
            {
                listOfAllEnemiesAlive.RemoveAt(index);
            }
        }
        */
    }


    private IEnumerator SpawnWaveOfEnemies()
    {
        //do something here
        while(true) //enemies are less than 20
        {
            if(listOfAllEnemiesAlive.Count < 20)
            {
                Enemy clone = SpawnEnemy();
                //yield return new WaitForEndOfFrame();
                //clone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
            }

            yield return new WaitForSeconds(Random.Range(1, 4));
            
        }
        //do something else here after 5 house
    }

}
