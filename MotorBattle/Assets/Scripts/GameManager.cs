using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int nbAlivePlayers;
    [HideInInspector]
    public float gameSpeed = 1;
    public int[] scores;
    Player[] players;

    private void Start()
    {
        players = FindObjectsOfType<Player>();
        nbAlivePlayers = players.Length;
    }

    public void KillPlayer()
    {
        nbAlivePlayers--;
        if(nbAlivePlayers <= 1)
        {
            gameSpeed = 0;
            GetWinner();
        }
    }

    void GetWinner()
    {
        foreach(Player p in players)
        {
            if (p.isAlive)
            {
                switch (p.playerNum)
                {
                    case 1:
                        scores[0]++;
                        break;
                    case 2:
                        scores[1]++;
                        break;
                    case 3:
                        scores[2]++;
                        break;
                    case 4:
                        scores[3]++;
                        break;
                }
            }
        }
    }
}
