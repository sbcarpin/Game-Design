using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyX;
    public GameObject superEnemy;
    public GameObject gem;
    private float lspawnX = -35;
    private float hspawnX = 5;
    private float lspawnZ = -6;
    private float hspawnZ = 32;
    //Cude enemy time
    private float startDelay = 5;
    private float spawnInterval = 7f;
    //Cude enemyX time
    private float XDelay = 90;
    private float XInterval = 7f;
    //Agent enemy time
    private float SuperEInterval = 20f;
    private float SuperEDelay = 15f;
    //token time
    private float TokDelay = 0;
    private float TokInterval = 4f;

    public float spawnPosX;
    public float spawnPosZ;


    // Start is called before the first frame update
    void Start()
    {
        //add a while loop to stop when game is over ?
        CallEnemy();  
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CallEnemy()
    {
            InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
            InvokeRepeating("SpawnEnemyX", XDelay, XInterval);
            InvokeRepeating("SpawnSuperEnemy", SuperEDelay, SuperEInterval);
            InvokeRepeating("SpawnGems", TokDelay, TokInterval);
            
    }

    public void SpawnEnemy()
    {
        spawnPosX = Random.Range(lspawnX, hspawnX);
        spawnPosZ = Random.Range(lspawnZ, hspawnZ);
        Vector3 spawnPos = new Vector3(spawnPosX, 1.5f, spawnPosZ);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }

    public void SpawnEnemyX()
    {
        spawnPosX = Random.Range(lspawnX, hspawnX);
        spawnPosZ = Random.Range(lspawnZ, hspawnZ);
        Vector3 spawnPos = new Vector3(spawnPosX, 1.5f, spawnPosZ);
        Instantiate(enemyX, spawnPos, enemyX.transform.rotation);
    }

    public void SpawnSuperEnemy()
    {
        spawnPosX = Random.Range(lspawnX, hspawnX);
        spawnPosZ = Random.Range(lspawnZ, hspawnZ);
        Vector3 spawnPos = new Vector3(spawnPosX, 1f, spawnPosZ);
        Instantiate(superEnemy, spawnPos, superEnemy.transform.rotation);
    }

    public void SpawnGems()
    {
        spawnPosX = Random.Range(lspawnX, hspawnX);
        spawnPosZ = Random.Range(lspawnZ, hspawnZ);
        Vector3 spawnPos = new Vector3(spawnPosX, 2f, spawnPosZ);
        Instantiate(gem, spawnPos, gem.transform.rotation);
    }
}
