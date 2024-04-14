using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New model object", menuName = "Model object")]
//ScriptableObject � �������� ����������� � ������
public class modelObject : ScriptableObject
{
    //���� ��������
    public GameObject model;
    public Sprite modelImage;
    //��������� �������� � ���
    public string modelName;
    public string modelDescription;
    public bool isCurrentObject;
};    

