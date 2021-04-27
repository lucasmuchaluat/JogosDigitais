using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public GameManager gm;
    public bool Cached;
    private IEnumerable<Player> cachedPlayers;
    private List<GameObject> cachedTable;


    // Use this for initialization
    void Start()
    {

        gm = GameManager.GetInstance();
        cachedTable = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.gameState == GameManager.GameState.ENDGAME)
        {
            try
            {
                var activePlayer = gm.GetActivePlayer();

                activePlayer.UpdatePlayer(gm.pontos);
                gm.UpdatePlayer(activePlayer);
                gm.pontos = 0;
            }
            catch { }
            
        }
        var players = gm.GetAllPlayers().OrderByDescending(p => p.HighScore);
        if (players != cachedPlayers)
        {
            cachedPlayers = players;
            Cached = false;
        }

        if (!Cached & gm.gameState == GameManager.GameState.ENDGAME)
        {
            entryTemplate.gameObject.SetActive(false);
            float templateHeight = 30f;

            foreach (var clone in cachedTable)
            {
                Destroy(clone);
            }

            var i = 0;
            foreach (var p in cachedPlayers)
            {
                Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                entryTransform.gameObject.SetActive(true);

                i += 1;
                entryTransform.Find("PLACE_POS").GetComponent<Text>().text = i.ToString();
                entryTransform.Find("PLACE_NAME").GetComponent<Text>().text = p.Name;
                entryTransform.Find("PLACE_SCORE").GetComponent<Text>().text = p.HighScore.ToString();
                cachedTable.Add(entryTransform.gameObject);
            }

            if (players.Any())
            {
                Cached = true;
            }
        }
    }
}
