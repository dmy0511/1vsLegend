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
    public float currentCoolTime = 0.1f; // 현재 쿨타임

    private float coolTime; // 쿨타임
    private float timer; // 타이머

    private void Start()
    {
        currentCoolTime = 0.1f;
        coolTime = currentCoolTime;
        timer = coolTime;
    }


    private void Update()
    {
        if (timer > 0f)
        {
            if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
            {
                // 키 이동 여부가 false인 경우 아무 작업도 수행하지 않음
                
               

                 
                 
            
                
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

            GameObject spawnedObject = Instantiate(randomObject.prefab, transform.position, Quaternion.identity); // 랜덤한 프리팹 생성

            Renderer renderer = spawnedObject.GetComponent<Renderer>();

            //Color randomColor = Random.Range(0, 2) == 0 ? Color.red : Color.blue; // 랜덤한 색상 선택
            //renderer.material.color = randomColor;

            // 생성된 오브젝트의 속성을 수정하거나 설정할 수 있음

            timer = coolTime;
        }
    }
}







