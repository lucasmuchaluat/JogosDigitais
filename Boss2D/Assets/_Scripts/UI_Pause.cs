using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    
    public void Retornar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Inicio()
    {
        SceneManager.LoadScene(0);
        gm.ChangeState(GameManager.GameState.MENU);
    }

}
