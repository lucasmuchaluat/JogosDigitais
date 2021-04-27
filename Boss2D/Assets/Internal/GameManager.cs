using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{

    public enum GameState { MENU, START, GAME, PAUSE, RESUME, ENDGAME };

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public GameState gameState { get; private set; }
    public int vidas;
    public int pontos;
    public int canos;
    private Dictionary<string, Player> playerDict;

    private static GameManager _instance;


    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        vidas = 1;
        pontos = 0;
        gameState = GameState.MENU;
        playerDict = new Dictionary<string, Player>();

    }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.START) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 1;
        pontos = 0;
    }

    public void AddOrActivatePlayer(string name, int score, bool status)
    {
        if (playerDict.Keys.Contains(name))
        {
            playerDict[name].Active = true;
        }
        else
        {
            playerDict[name] = new Player()
            {
                Name = name,
                HighScore = score,
                Active = status,
                CurrentScore = 0
            };
        }

    }

    public void UpdatePlayer(Player player)
    {
        playerDict[player.Name] = player;
    }

    public Player GetPlayer(string name)
    {
        return playerDict[name];
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return playerDict.Values;
    }

    public Player GetActivePlayer()
    {
        return playerDict.Values
            .Where(p => p.Active == true)
            .FirstOrDefault();
    }

}
