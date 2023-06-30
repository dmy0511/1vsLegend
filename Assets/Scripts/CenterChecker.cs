using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterChecker : MonoBehaviour
{
    private bool isOccupied = false; // 상자 중앙이 점유되었는지를 추적하는 변수

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Center"))
        {
            isOccupied = true; // 상자 중앙이 점유되었다고 표시
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Center"))
        {
            isOccupied = false; // 상자 중앙이 비점유되었다고 표시
        }
    }

    public bool IsOccupied()
    {
        return isOccupied; // 현재 상자 중앙의 점유 상태 반환
    }
}
