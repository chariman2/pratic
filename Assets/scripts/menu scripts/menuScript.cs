 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//������ ��� ������������ ����� �������
public class menuScript : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("out");
        Application.Quit();
    }
    public void toMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
