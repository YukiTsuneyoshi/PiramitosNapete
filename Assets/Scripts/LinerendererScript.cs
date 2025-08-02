using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerendererScript : MonoBehaviour
{
    LineRenderer linerend;

    void Start()
    {
        linerend = gameObject.AddComponent<LineRenderer>();

        Vector3[] positions = new Vector3[]{
        new Vector3(0, -3, 0),
        new Vector3(3, 3, 0),
        new Vector3(-1, 4, 0),
        };

        // �_�̐����w�肷��
        linerend.positionCount = positions.Length;

        //�}�e���A���̐ݒ�
        linerend.material = new Material(Shader.Find("Sprites/Default"));
        //�F���w�肷��
        linerend.startColor = Color.blue;
        linerend.endColor = Color.red;

        // ���������ꏊ���w�肷��
        linerend.SetPositions(positions);
    }
}