using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationBehaviour : AIBehavior
{
    private void OnDestroy()
    {
        VegetationSpawner.countObject--;
    }
    protected override void Move()
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
   
 
}
