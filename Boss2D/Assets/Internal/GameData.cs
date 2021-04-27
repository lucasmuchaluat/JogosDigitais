﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* ----------------------------------------------------------------- //
// Esse código não deve ser alterado, caso precise ser feito algum   //
// ajuste, entrar em contato com o professor da disciplina.          //
// ----------------------------------------------------------------- */

// Class para gerenciar 
public class GameData
{

    // atributo que define se mensagens do jogo irão aparecer no console do Unity
    public static bool debugging = false;

    // tempo inicial de uma partida (em segundos)
    public static float initialTime = 5.0f;

    static List<int> lastScenes = new List<int>();
    public static int level { get; private set; } = 0;
    public static int lives = 3;

    // caso jogador perca uma partida essa variável se torna verdade temporariamente
    public static bool lost = false;

    // Método usado para iniciar e re-iniciar os dados
    public static void reset(int lives) {
        GameData.lives = lives;
        GameData.level = 0;
    }

    public static bool CanLoadScene(int buildIndex)
    {
        GameData.DebugLog($"[GameData] last loaded scenes {lastScenes.ToString()}");
        if (lastScenes.Contains(buildIndex)) return false;
        lastScenes.Insert(0, buildIndex);

        if (lastScenes.Count > Mathf.Min(SceneManager.sceneCountInBuildSettings - 2, 3))
        {
            lastScenes.RemoveAt(lastScenes.Count - 1);
        }
        level++;
        return true;
    }

    // Retorna o tempo (em segundos) que deve durar uma partida em função do nível dela
    public static float GetTime()
    {
        return initialTime - Mathf.Log10(level+1);
    }

    // Caso debugging ligado, envia mensagens para console do Unity
    public static void DebugLog(string message)
    {
        if (debugging)
        {
            Debug.Log(message);
        }
    }

}
