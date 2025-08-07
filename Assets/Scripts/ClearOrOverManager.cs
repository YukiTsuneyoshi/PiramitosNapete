using UnityEngine;

public class ClearOrOverManager : MonoBehaviour
{
    [SerializeField] ViewManager viewManager;
    [SerializeField] PlayerController playerController;
    private int _stage = 0;
    private int _2Dor3D = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkElapsedTime();
    }
    void checkElapsedTime()
    {
        //�o�ߎ��Ԃ��v��
        if (GameManager.now2Dor3D == 0)
        {
            //2D�̂Ƃ�
            if (GameManager.elapsedTime > viewManager.Stages[GameManager.nowStage].limitTime2D)
            {
                //�������Ԃ𒴂�����3D�X�e�[�W�ֈړ�
                playerController.ChangeStages(GameManager.nowStage, 1);
            }
        }
        else
        {
            //3D�̂Ƃ�
            if (GameManager.elapsedTime > viewManager.Stages[GameManager.nowStage].limitTime3D)
            {
                //�������Ԃ𒴂�����Q�[���I�[�o�[
                GameOver();
            }
        }
        GameManager.elapsedTime += Time.deltaTime;
    }

    public void StageClear()
    {
        //���̃X�e�[�W��2D��ʂɐi��
        if (GameManager.nowStage == 2)
        {
            _stage = 0;
        }
        else
        {
            _stage++;
        }
        _2Dor3D = 0;
        playerController.ChangeStages(_stage, _2Dor3D);
    }
    void GameOver()
    {
        //�����X�e�[�W��2D��ʂɖ߂�
        playerController.ChangeStages(GameManager.nowStage, 0);
    }
}
