using System;
using System.Collections.Generic;
//�������, ������� ������ ������ ���������� ��� ������ �����������
public static class FeaturePresentorDictionary
{
    public static Dictionary<Type, Type> featurePresenterDict = new()
    {   //���� - ��� ����� �����������, �������� - ��� ������� ����������
        {typeof(cutFeature), typeof(CutFeaturePresenter)},
        {typeof(decomposeFeature), typeof(DecomposeFeaturePresenter)},
        {typeof(colorChange), typeof(ColorFeaturePresentor)},
    };    
}
