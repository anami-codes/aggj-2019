using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<Transform> spawnPoints;
    public List<Obstacle> phyObstacles;
    public List<GameObject> visObstacles;
    public GameObject stalker;
    public Avasta avasto;
    public bool avastaRunning;

    public float phySpawnTime = 1f;
    public float visSpawnTime = 1f;
    public float avastaSpawnTime = 1f;
    public float rocketSpawnTime = 1f;

    private int spawnPointLastIndex = -1;
    private int phyLastIndex = -1;
    private int visLastIndex = -1;

    private float phySpawnTimer;
    private float visSpawnTimer;
    private float avastaSpawnTimer;
    private float rocketSpawnTimer;

    private bool canSpawn;

    public void Initialize () {
        phySpawnTimer = Time.time + phySpawnTime;
        visSpawnTimer = Time.time + visSpawnTime;
        canSpawn = true;
    }

    void Update () {
        if (!Player.canMove) canSpawn = false;

        if (canSpawn) {
            if (phySpawnTimer <= Time.time) {
                SpawnPhyObstacle();
            }

            if (visSpawnTimer <= Time.time) SpawnVisObstacle();

            if ((avastaSpawnTimer <= Time.time) && (!avastaRunning)) {
                avasto.Initilize();
                avastaRunning = true;
            }

            if (avastaRunning) {
                if (!avasto.isActive) {
                    avastaRunning = false;
                    float t = Random.Range(avastaSpawnTime / 2, avastaSpawnTime * 2 + avastaSpawnTime);
                    avastaSpawnTimer = Time.time + t;
                    return;
                }
                if ((rocketSpawnTimer <= Time.time) && (!avasto.blackhole.activeSelf)) SpawnRocket();
            }
        }
    }

    void SpawnPhyObstacle () {
        Obstacle obs = SelectPhyObstacle();
        Transform spawn = SelectSpawnPoint();

        GameObject obs_ = Instantiate(obs.gameObject, spawn.position, obs.transform.rotation);
        obs_.GetComponent<Obstacle>().SetEnemyBehaviour(spawn.name);

        float t = Random.Range(phySpawnTime / 2, phySpawnTime * 2 + phySpawnTime);
        phySpawnTimer = Time.time + t;
    }

    void SpawnVisObstacle () {
        GameObject obs = SelectVisObstacle();
        obs.SetActive(true);
        obs.GetComponent<VisualObstacle>().Initialize();

        float t = Random.Range(visSpawnTime / 2, visSpawnTime * 2 + visSpawnTime);
        visSpawnTimer = Time.time + t;
    }

    void SpawnRocket () {
        Transform spawn = SelectSpawnPoint();
        Instantiate(stalker, spawn.position, stalker.transform.rotation);

        float t = Random.Range(rocketSpawnTime / 2, rocketSpawnTime * 2 + rocketSpawnTime);
        rocketSpawnTimer = Time.time + t;
    }

    Obstacle SelectPhyObstacle() {
        int i = Random.Range(0, phyObstacles.Count);
        if (i == phyLastIndex) {
            i = Random.Range(0, phyObstacles.Count);
        }

        phyLastIndex = i;

        return phyObstacles[i];
    }

    GameObject SelectVisObstacle() {
        int i = Random.Range(0, visObstacles.Count);
        if (i == visLastIndex) {
            i = Random.Range(0, visObstacles.Count);
        }

        visLastIndex = i;

        return visObstacles[i];
    }

    Transform SelectSpawnPoint () {
        int i = Random.Range(0, spawnPoints.Count);
        if (i == spawnPointLastIndex) {
            i = Random.Range(0, spawnPoints.Count);
        }

        spawnPointLastIndex = i;

        return spawnPoints[i];
    }
}
