using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QUIT_GAME : MonoBehaviour
{

    [SerializeField] private Button BotaoJogar;

    GameObject MenuGameUI;
    private void Awake()
    {
        BotaoJogar.onClick.AddListener(OnButtonPlayClickJogar);
    }
    private void OnButtonPlayClickJogar()
    {
        Debug.Log("SAIR");
        
    }

    public void Sair()
    {
        Application.Quit();
    }


}