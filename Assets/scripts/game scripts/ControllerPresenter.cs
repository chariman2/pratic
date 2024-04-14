using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPresenter : MonoBehaviour
{
    public MyDictioanary TypePresenterDict;

    public Canvas canvas;
    public Text nameModel;
    public Text description;
    public Button next;
    public Button prev;
    public Dropdown featureDropdown;

    public GameController GameController;

    GameObject spawnedUI;

    private void Awake()
    {
        GameController.OnModelChanged += ChangeUI;
        next.onClick.AddListener(() =>
        {
            GameController.NextModel();
        });
        prev.onClick.AddListener(() =>
        {
            GameController.PrevModel();
        });
    }

    public void ChangeUI(modelObject currentModelObject)
    {
        Destroy(spawnedUI);
        nameModel.text = currentModelObject.modelName;
        description.text = currentModelObject.modelDescription;
        currentModelManager currentModel = currentModelObject.model.GetComponent<currentModelManager>();

        //���������� ����������� ���������
        List<string> DropOptions = new() { "������� ���������" };

        featureDropdown.ClearOptions();
        featureDropdown.onValueChanged.RemoveAllListeners();

        //���������� ������������ � �������� ���� ��� ������
        for (int i = 0; i < currentModel.CurrentFeatureList.Length; i++)
        {
            DropOptions.Add(currentModel.CurrentFeatureList[i]?.Name);
        }
        featureDropdown.AddOptions(DropOptions);

        //���������� ������� � Dropdown �� ����� �� �������
        featureDropdown.onValueChanged.AddListener(ActivateFeature);
    }

    //�������, ������� ���������� ������ ��������� ����������� � ����������� �� ������ ��������� ����� � �������� ����
    public void ActivateFeature(int value)
    {
        Destroy(spawnedUI);
        value--;
        GameController.SpawnModel();
        if (value >= 0)
        {           
            Ifeature[] featureList = GameController.changeableObject.GetComponent<currentModelManager>().CurrentFeatureList;
            
            foreach (var (key, item) in TypePresenterDict)
            {
                if (featureList[value].GetType() == item.featureType.Type)
                {
                    spawnedUI = Instantiate(key, Vector3.zero, Quaternion.identity, canvas.transform);
                    FeaturePresentor featurePresentor = spawnedUI.GetComponent<FeaturePresentor>();
                    spawnedUI.transform.localPosition = Vector3.zero;
                    //���������� ������� ������� ���������
                    featurePresentor.Init(GameController);
                    featurePresentor.CurrentFeatureUIPresent(featureList[value]);
                }
            }                    
        }
    }
}


[Serializable]
public class MyDictioanary : SerializableDictionaryBase<GameObject, FeatureType> { }

[Serializable]
public class FeatureType 
{
    [Inherits(typeof(Ifeature), ShortName = true)] public TypeReference featureType;
}
