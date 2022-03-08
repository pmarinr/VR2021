using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHole : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform[] _holesGO;
    private int _currentHole;
    public bool _completedHole;
 
    void Start()
    {
    }

    void Update()
    {
        if (_completedHole)
        {
            _completedHole = false;
            StartCoroutine(NextHoleCR());
        }
    }

    private IEnumerable NextHoleCR()
    {
        yield return new WaitForSeconds(5f);
        _currentHole++;
        _player.transform.position = _holesGO[_currentHole].transform.position;
    }
}
