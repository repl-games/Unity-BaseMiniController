using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBaseController : MonoBehaviour {
  // internal
  private bool m_gameOver = false;
  private bool m_gameStarted = false;

  protected bool m_gameWon = false; // consuming class sets this if game won

  protected float timer; // Countdown timer
  private float gameTime = 30f; // 30 seconds
  //

  // components
  protected AudioSource m_audioSource;
  //

  // Start is called before the first frame update
  protected virtual void Start() {
    timer = gameTime;
    m_audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  protected virtual void Update() {
    if (!m_gameStarted) {
      return;
    }

    if(m_gameStarted) {
      timer -= Time.deltaTime;
    }

    if (timer <= 0f) {
      EndGame();
    }
  }

  protected virtual void StartGame() {

  }

  protected virtual void SetupPreGame() {
    m_gameStarted = true;
    m_gameWon = false;
    m_gameOver = false;


    StartGame();
  }

  protected virtual void EndGame() {
    m_gameOver = true;
    m_gameStarted = false;
  }
}
