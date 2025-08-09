using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearOrOverManager : MonoBehaviour
{
    [SerializeField] ViewManager viewManager;
    [SerializeField] StageChanger stageChanger;
    [SerializeField] GameObject clearImage;
    private int _stage = 0;
    private int _2Dor3D = 0;
    private bool clearStarted = false;
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
        //GameManager.isWaiting��false�̂Ƃ��A�o�ߎ��Ԃ��v�����ăN���A���Q�[���I�[�o�[�����肷��
        if (!GameManager.isWaiting)
        {
            if (GameManager.now2Dor3D == 0)
            {
                //2D�̂Ƃ�
                if (GameManager.elapsedTime <= 0)
                {
                    //�������Ԃ𒴂�����3D�X�e�[�W�ֈړ�
                    stageChanger.ChangeStages(GameManager.nowStage, 1);
                }
            }
            else
            {
                //3D�̂Ƃ�
                if (GameManager.elapsedTime <= 0)
                {
                    //�������Ԃ𒴂�����Q�[���I�[�o�[
                    GameOver();
                }
            }
            GameManager.elapsedTime -= Time.deltaTime;
        }
    }

    public void StageClear()
    {
        //�N���A���o�̃R���[�`�������s
        if(!clearStarted)
        {
            StartCoroutine(ClearEffect());
            clearStarted = true;
        }
        
    }

    void GameOver()
    {
        //�����X�e�[�W��2D��ʂɖ߂�
        stageChanger.ChangeStages(GameManager.nowStage, 0);
    }

    public IEnumerator ClearEffect() {
        //�N���A�摜�\��
        GameManager.isWaiting = true;
        yield return new WaitForSeconds(1);
        var image = clearImage.GetComponent<Image>();
        image.DOFade(1, 2);
        yield return new WaitForSeconds(5);

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
        stageChanger.ChangeStages(_stage, _2Dor3D);
        //������
        image.DOFade(0, 0);
        clearStarted = false;
    }
}
