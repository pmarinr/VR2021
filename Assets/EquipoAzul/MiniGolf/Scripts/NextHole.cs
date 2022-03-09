using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHole : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform[] _holesGO;
    private int _currentHole;
    public bool _completedHole;

    void Update()
    {
        if (_completedHole)
        {
            
            StartCoroutine(NextHoleCR());
            _completedHole = false;
        }
    }

    private IEnumerator NextHoleCR()
    {
        yield return new WaitForSeconds(5f);
        _currentHole++;
        print("BRBRRB" + _currentHole);
        _player.transform.position = _holesGO[_currentHole].transform.position;
        _ball.transform.position = _holesGO[_currentHole].GetComponentInChildren<Transform>().position;
    }
}
