using UnityEngine;

public class AudioLisenerForEnemy : MonoBehaviour
{
    void Start()
    {
        // �������� ������ � ���������
        string microphone = Microphone.devices[0]; // ������ ��������� ��������
        int bufferSize = 4096; // ������ ������ ��� ���������� ����� ������ (����� ��������)
        int frequency = 44100; // ������� ������������� ����� ������ (����� ��������)

        // ��������� ��������
        AudioClip clip = Microphone.Start(microphone, true, 1, frequency);
        while (Microphone.GetPosition(null) <= 0) { } // ����, ���� �������� �� ����������

        // ������ ����� ������ �� ��������� � ������������ ���������
        float[] samples = new float[bufferSize];
        float volume = 0f;
        while (true)
        {
            // ������ ����� ������ � �����
            int position = Microphone.GetPosition(null) - bufferSize;
            if (position < 0) continue; // ���� ����� ��� �� ��������, ���������� �������
            clip.GetData(samples, position); // ��������� ����� ������

            // ������������ ���������
            for (int i = 0; i < bufferSize; i++)
            {
                volume += Mathf.Abs(samples[i]);
            }
            volume /= bufferSize;

            // ���������� ���������� ��������� �� ������ ���������� (��������, ������� � �������)
            Debug.Log("Microphone volume: " + volume);

            // ��� ������������� ����� �������� �������� � ����� ��� �������� �������� �� ���������
            // System.Threading.Thread.Sleep(16); // �������� � 16 ����������� (60 ������ � �������)
        }

        // ������������� ��������
        Microphone.End(microphone);
    }
}
