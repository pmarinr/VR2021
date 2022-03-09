using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace VR2021
{
    [Serializable]
    public class Score
    {
        public string game;
        public string player;
        public int score;
        public DateTime date;

        public Score(string game, string player, int score)
        {
            this.game = game;
            this.score = score;
            this.player = player;
            date = DateTime.Now;
        }
    }

    [Serializable]
    public class ScoreList
    {
        public List<Score> scoreList;
    }

    
}

