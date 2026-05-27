using UnityEngine;

public class FishSpawner : MonoBehaviour {
    public GameObject[] ikanPrefabs; // Array buat banyak ikan
    public float spawnInterval = 1f;

    void Start() {
        InvokeRepeating(nameof(SpawnFish), 0f, spawnInterval);
    }

    void SpawnFish() {
        // Pilih ikan acak dari list
        int indexAcak = Random.Range(0, ikanPrefabs.Length);
        float randomY = Random.Range(-3f, 3f);
        Vector3 spawnPos = new Vector3(-15f, randomY, 0f);
        
        Instantiate(ikanPrefabs[indexAcak], spawnPos, Quaternion.identity);
    }
}