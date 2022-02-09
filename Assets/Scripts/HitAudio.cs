using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudio : MonoBehaviour {
    public bool debug = false;
    public AudioSource hitSound;
    public bool hitEnergyAffectsVolume = true;
    public bool hitEnergyAffectsPitch = true;
    public float fullVolumeAtJoules = 20f;

    public int maxConcurrentHitSounds = 2;
    private int soundCounter = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (debug) Debug.Log(gameObject.name + "<-" + collision.gameObject.name + ":" + KineticEnergy((collision.rigidbody == null ? 1 : collision.rigidbody.mass), collision.relativeVelocity.sqrMagnitude) + " julios");
        if (hitSound == null)
        {
            Debug.LogWarning(gameObject.name + " hited " + collision.gameObject.name + " but there's no Clip assigned to play!!!");
        }
        else
        {
            if (collision.relativeVelocity.magnitude > 0)
            {
                if (hitEnergyAffectsVolume) hitSound.volume = KineticEnergyVolume(KineticEnergy((collision.rigidbody == null ? 1 : collision.rigidbody.mass), collision.relativeVelocity.sqrMagnitude));
                if (hitEnergyAffectsPitch) hitSound.pitch = 2* Mathf.Lerp(0f, 1f, hitSound.volume);

                Play();
            }
        }
    }

    /// <summary>
    /// Returns the kinetic energy of the hit using it's mass and the sqrMagnitude of it's relativeVelocity
    /// </summary>
    /// <param name="mass"></param>
    /// <param name="sqrMagnitude"></param>
    /// <returns></returns>
    public static float KineticEnergy(float mass, float sqrMagnitude)
    {
        // mass in kg, velocity in meters per second, result is joules
        return 0.5f * mass * sqrMagnitude;
    }

    /// <summary>
    /// Returns a float between 0 and 1 relative to the joules value between 0 and fullVolumeAtJoules
    /// </summary>
    /// <param name="joules">Kinetic energy in joules of the hit</param>
    /// <returns></returns>
    public float KineticEnergyVolume(float joules)
    {
        return Mathf.InverseLerp(0, fullVolumeAtJoules, joules);
    }


    /// <summary>
    /// Plays the hit sound taking care that there's not more than maxConcurrentHitSounds sounding at the same time
    /// </summary>
    public void Play()
    {
        if (debug) Debug.Log("Clip: " + hitSound.clip.name + " sounding " + soundCounter + " of " + maxConcurrentHitSounds + " times available");
        if (soundCounter < maxConcurrentHitSounds)
        {
            hitSound.PlayOneShot(hitSound.clip, hitSound.volume);
            soundCounter++;
            Invoke("RemoveFromSoundCounter", hitSound.clip.length);
        }

    }

    /// <summary>
    /// Removes one from the sound counter. Call it when the Clip length time has passed.
    /// </summary>
    public void RemoveFromSoundCounter()
    {
        soundCounter--;
    }


}
