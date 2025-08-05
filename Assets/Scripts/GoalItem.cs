using UnityEngine;

public class GoalItem : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ClearOrOverManager clearOrOverManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //�v���C���[�ƐڐG�����ꍇ
        if (col.gameObject.name == player.name)
        {
            clearOrOverManager.StageClear();
        }
    }

}
