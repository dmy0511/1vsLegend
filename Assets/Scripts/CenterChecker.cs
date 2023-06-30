using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterChecker : MonoBehaviour
{
    private bool isOccupied = false; // ���� �߾��� �����Ǿ������� �����ϴ� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Center"))
        {
            isOccupied = true; // ���� �߾��� �����Ǿ��ٰ� ǥ��
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Center"))
        {
            isOccupied = false; // ���� �߾��� �������Ǿ��ٰ� ǥ��
        }
    }

    public bool IsOccupied()
    {
        return isOccupied; // ���� ���� �߾��� ���� ���� ��ȯ
    }
}
