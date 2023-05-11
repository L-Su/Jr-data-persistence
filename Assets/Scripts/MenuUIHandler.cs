using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if (nameInput.text == null)
        {
            nameInput.text = "Player";
        }
        DataManager.Instance.m_name = nameInput.text;
        //Debug.Log("input: "+DataManager.Instance.b_name);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveBestScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
