using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab; // 생성할 프리팹 오브젝트
        public float initialSpeed; // 초기 속도
    }

    public SpawnableObject[] objectsToSpawn; // 생성할 오브젝트 배열
    public float currentCoolTime = 0.5f; // 현재 쿨타임
    public float speedIncreaseRate = 0.1f; // 속도 증가 비율
    public Transform boxTransform; // 상자의 Transform

    private float coolTime; // 쿨타임
    private float timer; // 타이머
    
    //public bool canMove = true;

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

            GameObject spawnedObject = Instantiate(randomObject.prefab, transform.position, Quaternion.identity); // 랜덤한 프리팹 생성

            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.right * randomObject.initialSpeed; // 초기 속도로 이동
            }
            //if (canMove){}

            Renderer renderer = spawnedObject.GetComponent<Renderer>();

            Color randomColor = Random.Range(0, 2) == 0 ? Color.red : Color.blue; // 랜덤한 색상 선택
            renderer.material.color = randomColor; // 선택한 색상으로 설정

            BoxCollider2D boxCollider = boxTransform.GetComponent<BoxCollider2D>();
            timer = coolTime;
        }

        coolTime = Mathf.Max(coolTime, 0f); // 쿨타임이 0 이하가 되지 않도록 보정

        foreach (SpawnableObject obj in objectsToSpawn)
        {
            obj.initialSpeed += speedIncreaseRate * Time.deltaTime; // 속도 증가
        }
    }
}







