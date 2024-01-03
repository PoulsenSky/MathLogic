using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTurn : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    public static MusicTurn instance;
    public bool isMute = false;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        //BGM = GetComponent<AudioSource>();

        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void TurnON() {
        if(!isMute) {
            BGM.volume = 1f;
        }
    }

    public void TurnOff() {
        if(isMute) {
            BGM.volume = 0f;
        }
    }
}
