using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePointer : MonoBehaviour
{
    private GameObject _player;
    void Start()
    {
        _player = GameObject.Find("XR Origin");
    }

    void Update()
    {
        transform.LookAt(_player.transform.position);
    }
}
