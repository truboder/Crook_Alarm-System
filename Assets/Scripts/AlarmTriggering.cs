using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTriggering : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChange = 0.01f;

    private bool _isPlayerInRoom = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isPlayerInRoom = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isPlayerInRoom = false;
    }

    private void FixedUpdate()
    {
        switch (_isPlayerInRoom)
        {
            case false:
                if (_audio.volume > 0)
                {
                    _audio.volume -= _volumeChange;
                }
                break;

            case true:
                if (_audio.volume < 1)
                {
                    _audio.volume += _volumeChange;
                }
                break;
        }

        Debug.Log(_audio.volume);
    }
}
