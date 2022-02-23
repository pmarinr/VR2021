using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioSource bgMusic;
    public AudioSource pointSource;
    public AudioSource inGlass;

    public List<AudioClip> clips;
    

    public int randomN;

    
    void Awake()
    {
        //bgMusic.clip = musicBG;
        //bgMusic.Play();
    }
    private void Start()
    {

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
       
        audioPlayer.Play();
    }
    public void BackgroundMusic()
    {
        bgMusic.clip = clips[9];
       
        bgMusic.Play();
    }
    public void TableHit()
    {
        audioPlayer.clip = clips[Random.Range(3, 6)];
       
        audioPlayer.Play();
    }
    public void GlassHit()
    {
        audioPlayer.clip = clips[Random.Range(0, 3)];
       
        audioPlayer.Play();
    }
    public void BallIn()
    {
        inGlass.clip = clips[Random.Range(6, 9)];
        
        inGlass.Play();
    }
    public void Point()
    {
        pointSource.clip = clips[12];
        
        pointSource.Play();
        print("sonido de punto");
    }
    public void HighScore()
    {
        audioPlayer.clip = clips[10];
        
        audioPlayer.Play();
        
    }
}
