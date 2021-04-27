using System.Linq;
using UnityEngine;

public class ActiveOnSomeStates : MonoBehaviour
{
    public GameManager.GameState[] activeStates;
    GameManager gm;

    void Start()
    {
        GameManager.changeStateDelegate += UpdateVisibility;
        gm = GameManager.GetInstance();

        UpdateVisibility();
    }

    private void OnDestroy()
    {
        GameManager.changeStateDelegate -= UpdateVisibility;
    }

    void UpdateVisibility()
    {
        if (activeStates.Contains(gm.gameState))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}