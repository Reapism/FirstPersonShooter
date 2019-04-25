using UnityEngine;

public class SpawnGameObjects : MonoBehaviour {
    // public variables
    public float secondsBetweenSpawning = 0.1f;
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 8.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;
    public GameObject[] spawnObjects; // what prefabs to spawn

    private float nextSpawnTime;

    // Use this for initialization
    private void Start() {
        // determine when to spawn the next object
        this.nextSpawnTime = Time.time + this.secondsBetweenSpawning;
    }

    // Update is called once per frame
    private void Update() {
        // exit if there is a game manager and the game is over
        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver)
                return;
        }

        // if time to spawn a new game object
        if (Time.time >= this.nextSpawnTime) {
            // Spawn the game object through function below
            MakeThingToSpawn();

            // determine the next time to spawn the object
            this.nextSpawnTime = Time.time + this.secondsBetweenSpawning;
        }
    }

    private void MakeThingToSpawn() {
        Vector3 spawnPosition;

        // get a random position between the specified ranges
        spawnPosition.x = Random.Range(this.xMinRange, this.xMaxRange);
        spawnPosition.y = Random.Range(this.yMinRange, this.yMaxRange);
        spawnPosition.z = Random.Range(this.zMinRange, this.zMaxRange);

        // determine which object to spawn
        int objectToSpawn = Random.Range(-1, this.spawnObjects.Length);
        GameObject spawnedObject;

        if (objectToSpawn >=-1 && objectToSpawn < 1) {
            spawnedObject = Instantiate(this.spawnObjects[0], spawnPosition, this.transform.rotation) as GameObject;
        } else {
            spawnedObject = Instantiate(this.spawnObjects[objectToSpawn], spawnPosition, this.transform.rotation) as GameObject;
        }

        // actually spawn the game object

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = this.gameObject.transform;
        Destroy(spawnedObject, 5.0f);
    }
}
