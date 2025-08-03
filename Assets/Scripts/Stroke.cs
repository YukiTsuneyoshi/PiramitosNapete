using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stroke : MonoBehaviour
{
    //���̍ގ�
    [SerializeField] Material lineMaterial;
    //���̐F
    [SerializeField] Color lineColor;
    //���̑���
    [Range(0.01f, 0.5f)]
    [SerializeField] float lineWidth;

    [SerializeField] GameObject MazeCubes;
    [SerializeField] private float worldCenterX;
    [SerializeField] private float worldCenterY;
    [SerializeField] private float blockSize = 4f;
    [SerializeField] private float blockPixel = 300f;

    //�ǉ��@LineRdenerer�^�̃��X�g�錾
    List<LineRenderer> lineRenderers, lineRenderers3D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�ǉ��@List�̏�����
        lineRenderers = new List<LineRenderer>();
        lineRenderers3D = new List<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //lineObj�𐶐����A����������
            _addLineObject();
            _addLineObject3D();
        }

        //�ǉ��@�N���b�N���i�X�g���[�N���j
        if (Input.GetMouseButton(0))
        {
            _addPositionDataToLineRendererList();
            _addPositionDataToLineRendererList3D();
        }
    }

    //�ǉ��@�N���b�N�����甭��
    void _addLineObject()
    {
        //��̃Q�[���I�u�W�F�N�g�쐬
        GameObject lineObj = new GameObject();
        //�I�u�W�F�N�g�̖��O��Stroke�ɕύX
        lineObj.name = "Stroke";
        //lineObj��LineRendere�R���|�[�l���g�ǉ�
        lineObj.AddComponent<LineRenderer>();
        //lineRenderer���X�g��lineObj��ǉ�
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj.transform.SetParent(transform);

        //lineObj����������
        _initRenderers();
    }

    void _addLineObject3D()
    {
        //��̃Q�[���I�u�W�F�N�g�쐬
        GameObject lineObj3D = new GameObject();
        //�I�u�W�F�N�g�̖��O��Stroke�ɕύX
        lineObj3D.name = "Stroke3D";
        //lineObj��LineRendere�R���|�[�l���g�ǉ�
        lineObj3D.AddComponent<LineRenderer>();
        //lineRenderer���X�g��lineObj��ǉ�
        lineRenderers3D.Add(lineObj3D.GetComponent<LineRenderer>());
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj3D.transform.SetParent(MazeCubes.transform);
        //lineObj����������
        _initRenderers3D();
    }

    //lineObj����������
    void _initRenderers()
    {
        //�����Ȃ��_��0�ɏ�����
        lineRenderers.Last().positionCount = 0;
        //�}�e���A����������
        lineRenderers.Last().material = lineMaterial;
        //�F�̏�����
        lineRenderers.Last().material.color = lineColor;
        //�����̏�����
        lineRenderers.Last().startWidth = lineWidth;
        lineRenderers.Last().endWidth = lineWidth;
    }

    void _initRenderers3D()
    {
        //�����Ȃ��_��0�ɏ�����
        lineRenderers3D.Last().positionCount = 0;
        //�}�e���A����������
        lineRenderers3D.Last().material = lineMaterial;
        //�F�̏�����
        lineRenderers3D.Last().material.color = lineColor;
        //�����̏�����
        lineRenderers3D.Last().startWidth = lineWidth*10;
        lineRenderers3D.Last().endWidth = lineWidth*10;
    }

    void _addPositionDataToLineRendererList()
    {
        //�}�E�X�|�C���^������X�N���[�����W���擾
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);

        //�X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //���[���h���W�����[�J�����W�ɕϊ�
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition.x, worldPosition.y, -1.0f);

        //lineRenderers�̍Ō��lineObj�̃��[�J���|�W�V��������L�̃��[�J���|�W�V�����ɐݒ�
        lineRenderers.Last().transform.localPosition = localPosition;

        //lineObj�̐��Ɛ����Ȃ��_�̐����X�V
        lineRenderers.Last().positionCount += 1;

        //LineRenderer�R���|�[�l���g���X�g���X�V
        lineRenderers.Last().SetPosition(lineRenderers.Last().positionCount - 1, worldPosition);

        //���Ƃ���`����������ɗ���悤�ɒ���
        lineRenderers.Last().sortingOrder = lineRenderers.Count;
    }

    void _addPositionDataToLineRendererList3D()
    {
        //�}�E�X�̃X�N���[�����W����3D���[�h���̃��[���h���W�ɕϊ�
        Vector3 worldPosition3D = new Vector3(worldCenterX + (Input.mousePosition.x-960f) / blockPixel * blockSize, 0.5f, worldCenterY + (Input.mousePosition.y - 540f) / blockPixel * blockSize);

        //���[���h���W�����[�J�����W�ɕϊ�
        Vector3 localPosition3D = transform.InverseTransformPoint(worldPosition3D.x, worldPosition3D.y, -1.0f);

        //lineRenderers�̍Ō��lineObj�̃��[�J���|�W�V��������L�̃��[�J���|�W�V�����ɐݒ�
        lineRenderers3D.Last().transform.localPosition = localPosition3D;

        //lineObj�̐��Ɛ����Ȃ��_�̐����X�V
        lineRenderers3D.Last().positionCount += 1;

        //LineRenderer�R���|�[�l���g���X�g���X�V
        lineRenderers3D.Last().SetPosition(lineRenderers3D.Last().positionCount - 1, worldPosition3D);

        //���Ƃ���`����������ɗ���悤�ɒ���
        lineRenderers3D.Last().sortingOrder = lineRenderers3D.Count;
    }
}
