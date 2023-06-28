using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public float initialSpeed;
    }

    public SpawnableObject[] objectsToSpawn;
    public float currentCoolTime = 0.5f;
    public float speedIncreaseRate = 0.1f;

    private float coolTime;
    private float timer;

    private void Start()
    {
        coolTime = currentCoolTime;
        timer = coolTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            SpawnableObject randomObject = objectsToSpawn[randomIndex];

            GameObject spawnedObject = Instantiate(randomObject.prefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.right * randomObject.initialSpeed;
            }

            Renderer renderer = spawnedObject.GetComponent<Renderer>();

            Color randomColor = Random.Range(0, 2) == 0 ? Color.red : Color.blue;
            renderer.material.color = randomColor;

            timer = coolTime;
        }

        coolTime = Mathf.Max(coolTime, 0f);

        foreach (SpawnableObject obj in objectsToSpawn)
        {
            obj.initialSpeed += speedIncreaseRate * Time.deltaTime;
        }
    }
}

