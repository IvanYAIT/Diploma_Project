using UnityEngine;

public class BildSystem : MonoBehaviour
{
    public GameObject buildableObject; // ������ ������� ��� �������������

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���� ������ ����� ������ ����
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10))
            {
                Vector3 spawnPosition = hit.point + hit.normal; // ���������� �������, ��� ����� ���������� ������

                Instantiate(buildableObject, spawnPosition, Quaternion.identity); // �������� ������ ��� �������������
            }

        }
    }
}
