using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace VR2021
{
    public class ScoreBoard : MonoBehaviour
    {
        public TextMeshProUGUI title;
        public GameObject scoreRowPrefab;
        public Transform scoreContent;
 
        public void Setup(string gameName,List<Score> scoreList)
        {
            title.text = gameName;
            transform.name = "ScoreBoard_" + gameName;
            foreach(Transform child in scoreContent)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (Score score in scoreList)
            {
                GameObject newRow = Instantiate(scoreRowPrefab,scoreContent);
                newRow.GetComponent<ScoreRow>().Setup(score);
            }
        }
    }
}
