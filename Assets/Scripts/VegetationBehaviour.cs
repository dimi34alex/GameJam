using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationBehaviour : MonoBehaviour
{
    [Tooltip("������������ ���������, �� ������� ����� ������� �����, � ������� ����� ��������� ������")]
    [Range(0f, 100f)] [SerializeField] private float maxDistance = 1f;
    
    [SerializeField] private float Speed = 1f;
    [Tooltip("��������� ��������, ��������� ����� ����� �������� �� ������� [1/value:value]")]
    [SerializeField] private float SpeedMultiplier = 2f;
     private float desiredDuration = 1f;
    private float elapsedTime = 0f;
    private Vector3 target;
    private float progress = -1f;
    private Vector3 positionFrom;

    private void Start()
    {
        target = transform.position;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
       
        //����� ������������ (��� is_following = true ���������� ���������� ���� ������ ���, ����� progress<0, �.�. ������� �� ������ ��� ��������)
        if (progress < 0f)
        {

            target = GetRandomTarget();

        
            //����� � ��������� ������ ����� ������������� � ��������� ������   
            
            progress = 0f;
            elapsedTime = 0;
            positionFrom = transform.position;
            desiredDuration = (target - positionFrom).magnitude * GetSpeedMultiplier() * Speed;


        }
        //�������� � �������� �������
        if (progress >= 0 && progress < 1)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / desiredDuration;
            transform.position = Vector2.Lerp(positionFrom, target, progress);
        }
        //���� ����� �� ����� 
        if (progress >= 1)
        {
            progress = -.1f;
        }
    }
    private float GetSpeedMultiplier()
    {
        float multiplier;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            multiplier = UnityEngine.Random.Range(1f, SpeedMultiplier);
            Debug.Log(1);
        }
        else
        {
            multiplier =1/UnityEngine.Random.Range(1f, SpeedMultiplier);
            Debug.Log(2);
        }
        return multiplier;
    }
    private Vector3 GetRandomTarget()
    {
        Vector3 newTarget=target;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            newTarget.x += UnityEngine.Random.Range(0, maxDistance);
        }
        else
        {
            newTarget.x += -UnityEngine.Random.Range(0, maxDistance);
        }
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            newTarget.y += UnityEngine.Random.Range(0, maxDistance);
        }
        else
        {
            newTarget.y += -UnityEngine.Random.Range(0, maxDistance);
        }



        if (!LevelSettings.Instance.isInsideBorders(newTarget))
        {
            Vector3 tempTarget = target;

            tempTarget.x = UnityEngine.Random.Range(LevelSettings.Instance.borders[Borders.LEFT], LevelSettings.Instance.borders[Borders.RIGHT]);
            tempTarget.y = UnityEngine.Random.Range(LevelSettings.Instance.borders[Borders.BOTTOM], LevelSettings.Instance.borders[Borders.TOP]);

            newTarget = tempTarget;
        }
        return newTarget;
    }
}
