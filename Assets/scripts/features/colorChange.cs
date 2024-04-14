using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class colorChange : Ifeature
{
    public GameObject Model { get; set; }
    public Color colorToChange;

    readonly string Name = "����� �����";
    string Ifeature.Name => Name;
    
    public void FeatureRealization()
    {
        ChangeColor(colorToChange);
        Debug.Log("����� �����");
    }
    public void ChangeColor(Color color)
    {
        //��� ����� ���������������
        for (int i = 0; i < Model.transform.childCount; i++)
        {
            if (Model.transform.GetChild(i).TryGetComponent(out MeshRenderer mesh))
            {
                mesh.materials[0].color = color;
            }
        }
    }
}
