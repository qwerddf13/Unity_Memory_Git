using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
