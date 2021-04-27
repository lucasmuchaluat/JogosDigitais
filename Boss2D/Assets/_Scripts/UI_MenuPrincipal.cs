using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuPrincipal : MonoBehaviour
{
    GameManager gm;

    public InputField InputName;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        
    }
    
    public void Comecar()
    {
        gm.AddOrActivatePlayer(InputName.text, 0, true);
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
