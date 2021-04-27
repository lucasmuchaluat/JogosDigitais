using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{

    public Text message;

    GameManager gm;
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        gm.canos = 0;

        if (gm.vidas <= 0)
        {
            message.text = "Você Perdeu!!";
        }
        else
        {
            message.text = "Você Ganhou!!!";
        }
    }

    public void Voltar()
    {
        SceneManager.LoadScene(0);
        gm.ChangeState(GameManager.GameState.MENU);
    }


    
}
