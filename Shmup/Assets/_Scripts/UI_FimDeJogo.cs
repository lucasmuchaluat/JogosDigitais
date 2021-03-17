using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas > 0 || gm.pontos >= 1000)
        {
            message.text = "Você Ganhou!!!";
        }
        else
        {
            message.text = "Você Perdeu!!";
        }
    }

    public void MainMenu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }

    public void JogarNovamente()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene(0);
    }

    
}
