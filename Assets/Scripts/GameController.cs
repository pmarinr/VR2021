using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VR2021.Events;

namespace VR2021
{
    [Serializable]
    public class GameController : MonoBehaviour
    {
        
        public ScoreList scoreList;
        public GameObject scoreBoardPrefab;
        private void Awake()
        {
            EventManager.StartListening(EventNames.EndLevel, OnEndLevel);
        }

        private void OnEndLevel(object obj)
        {
            Score score = obj as Score;
            scoreList.scoreList.Add(score);
            string scoreListJson = JsonUtility.ToJson(scoreList);
            PlayerPrefs.SetString("Score", scoreListJson);
            PlayerPrefs.Save();
            UpdateScore();
        }

        // Start is called before the first frame update
        void Start()
        {
            scoreList.scoreList = new List<Score>();
            string saveScores = PlayerPrefs.GetString("Score");
            if (!string.IsNullOrEmpty(saveScores)) scoreList = JsonUtility.FromJson<ScoreList>(saveScores);
            UpdateScore();
        }

        void UpdateScore()
        {
            List<string> gameNames = scoreList.scoreList.Select(x => x.game).Distinct().ToList();

            foreach(string game in gameNames)
            {
                GameObject scoreBoard = GameObject.Find("ScoreBoard_" + game);
                if (scoreBoard == null) scoreBoard = Instantiate(scoreBoardPrefab);
                List<Score> newGameScore = scoreList.scoreList.Where(x => x.game == game).ToList();
                scoreBoard.GetComponent<ScoreBoard>().Setup(game, newGameScore);
            }
            
        }
        void AddScores()
        {
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Jenga", "PMR", 0));
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Feria", "PMR", 0));
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Bolas", "PMR", 0));
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Jenga", "JLM", 5));
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Feria", "JML", 10));
            EventManager.TriggerEvent(EventNames.EndLevel, new Score("Jenga", "SSS", 100));
        }
        public void LoadGame(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
