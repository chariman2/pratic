using System;
using UnityEngine;

//������ ��� ������ ��������� ������ ������������ ������
public class currentModelManager : MonoBehaviour
{
    //������ ���� ������������, ������� ����� ������� ��� ������
    public GameObject model;
    [SerializeReference, SubclassSelector] public Ifeature[] CurrentFeatureList = Array.Empty<Ifeature>();
    private void Awake()
    {
        for (int i = 0; i < CurrentFeatureList.Length; i++)
        {
            CurrentFeatureList[i].Model = model;
        }
    }
}
