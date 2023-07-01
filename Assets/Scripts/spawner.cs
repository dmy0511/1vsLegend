using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab; // 생성할 프리팹 오브젝트
    }

    public SpawnableObject[] objectsToSpawn; // 생성할 오브젝트 배열
    public float currentCoolTime = 1f; // 현재 쿨타임

    private float coolTime; // 쿨타임
    private float timer; // 타이머

    private void Start()
    {
        coolTime = currentCoolTime;
        timer = coolTime;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
            {

            }
            else
            {
                timer -= Time.deltaTime;
            }

        }
        else
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            SpawnableObject randomObject = objectsToSpawn[randomIndex];

            GameObject spawnedObject = Instantiate(randomObject.prefab, transform.position, Quaternion.identity); // 랜덤 프리팹 생성

            Renderer renderer = spawnedObject.GetComponent<Renderer>();

            Color randomColor = Random.Range(0, 2) == 0 ? Color.red : Color.blue; // pick a random color
            renderer.material.color = randomColor;

            // 생성된 오브젝트에 대한 속성을 수정하거나 설정할 수 있습니다.

            timer = coolTime;
        }
    }
}







