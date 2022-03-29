using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    //enable the spawner
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);    
    }

    //stop the spawner
    private void OnDisable(){
        CancelInvoke(nameof(Spawn));
    }

    //spawn pipes
    private void Spawn(){
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);    
    }
}
