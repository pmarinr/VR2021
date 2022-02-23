using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioSource bgMusic;
    //public AudioClip glassHit1, glassHit2, glassHit3, coll1, coll2, coll3, glassIn1, glassIn2, glassIn3, sceneStart, musicBG, pointA, highScore;
    public List<AudioClip> clips;
    

    public int randomN;

    
    void Awake()
    {
        //bgMusic.clip = musicBG;
        //bgMusic.Play();
    }
    private void Start()
    {
        /*gH = new List<AudioClip>();
        gH.Add(glassHit1);
        gH.Add(glassHit2);
        gH.Add(glassHit3);

        gH.GetType.*/
        SceneStart();
        BackgroundMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneStart()
    {
        audioPlayer.clip = clips[11];
        audioPlayer.Stop();
        audioPlayer.Play();
    }
    public void BackgroundMusic()
    {
        bgMusic.clip = clips[9];
        bgMusic.Stop();
        bgMusic.Play();
    }
    public void TableHit()
    {
        audioPlayer.clip = clips[Random.Range(3, 6)];
        audioPlayer.Stop();
        audioPlayer.Play();
    }
    public void GlassHit()
    {
        audioPlayer.clip = clips[Random.Range(0, 3)];
        audioPlayer.Stop();
        audioPlayer.Play();
    }
    public void BallIn()
    {
        audioPlayer.clip = clips[Random.Range(6, 9)];
        
        audioPlayer.Play();
    }
    public void Point()
    {
        audioPlayer.clip = clips[12];
        
        audioPlayer.Play();
        print("sonido de punto");
    }
    public void HighScore()
    {
        audioPlayer.clip = clips[10];
        audioPlayer.Stop();
        audioPlayer.Play();
        
    }
}
