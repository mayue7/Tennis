﻿using TennisCalculator.Interfaces;

namespace TennisCalculator.Scores;

public class PlayerSetScore : IPlayerSetScore
{
    public IPlayer Player { get; set; }

    public int WonGamesScore { get; set; }

    public PlayerSetScore(IPlayer player)
    {
        Player = player;
        WonGamesScore = 0;
    }
}
