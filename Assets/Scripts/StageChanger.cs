using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class StageChanger : MonoBehaviour
{
    [SerializeField] ViewManager viewManager;
    private int _stage = 0;
    private int _2Dor3D = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeStages(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�X�e�[�W��ς���
    public void ChangeStages(int stage, int dim)
    {
        viewManager.InitializeStages();
        if(dim == 0)
        {
            //2D�̂Ƃ�
            viewManager.Stages[stage].mazeCanvas.SetActive(true);
            //����S������
            foreach (Transform n in viewManager.StrokeManager2D.transform)
            {
                Destroy(n.gameObject);
            }
            viewManager.StrokeManager2D.lineRenderers2D = new List<LineRenderer>();
            foreach (Transform n in viewManager.StrokeManager3D.transform)
            {
                Destroy(n.gameObject);
            }
            viewManager.StrokeManager3D.lineRenderers3D = new List<LineRenderer>();
            viewManager.StrokeManager2D.gameObject.SetActive(true);
            viewManager.camera2D.SetActive(true);
            GameManager.elapsedTime = viewManager.Stages[stage].limitTime2D;
        }
        else
        {
            //3D�̂Ƃ�
            //�X�e�[�W�v���n�u��S�ăA�N�e�B�u��
            viewManager.Stages[stage].mazeCubes.SetActive(true);
            foreach (Transform n in viewManager.Stages[stage].mazeCubes.transform)
            {
                n.gameObject.SetActive(true);
            }
            //�v���C���[���w����W�ɔz�u
            viewManager.playerCapsule.transform.position = viewManager.Stages[stage].playerPosition;
            viewManager.playerCapsule.transform.localEulerAngles = viewManager.Stages[stage].playerRotation;
            viewManager.playerCapsule.SetActive(true);
            viewManager.StrokeManager3D.gameObject.SetActive(true);
            viewManager.camera3D.SetActive(true);
            GameManager.elapsedTime = viewManager.Stages[stage].limitTime3D;
        }
        GameManager.nowStage = stage;
        GameManager.now2Dor3D = dim;
    }
}
