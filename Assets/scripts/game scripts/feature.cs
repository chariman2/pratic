using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���������� �������� ���� ��������� ������������
public interface Ifeature
{
    string Name { get; }
    public GameObject Model { get; set; }
    //�������, ������� ��������� ���������� ���� ������, ������� ���� ����� ��������
    public void FeatureRealization();
}
