using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraBehaviour : MonoBehaviour
{
   
    
    [Tooltip("��������� ���������� ������ �� Z, �� 100 ������ ��������")]
    [Range(1f, 5f)] [SerializeField] private float move�ameraBackPerPower=2;
    [Tooltip("������������ ������ ������ ���������, ����� ������������� ����� ������ �� ������� ������")]
    [SerializeField] private float maxSize = 25f;
    private float initVitVirtualCameraSize;
    private CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        Initial();
    }

  
    private void Initial()
    {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        initVitVirtualCameraSize = virtualCamera.m_Lens.OrthographicSize;
        
    }
    public  void move�ameraBack(int power)
    {
        virtualCamera.m_Lens.OrthographicSize = initVitVirtualCameraSize + (power / 100f) * (move�ameraBackPerPower);
        if (virtualCamera.m_Lens.OrthographicSize > maxSize)
        {
            virtualCamera.m_Lens.OrthographicSize = maxSize;
        }
    }
}
