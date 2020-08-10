using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Snake;
    public GameObject menu;
    public GameObject menu2;
    public GameObject textPoints;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDoubleTap())
        { Pause(); }
    }
    void Pause()
    {
        Snake.GetComponent<Snake>().isMoved = false;
        menu.SetActive(true);
    }
    public void Resume()
    {
        Snake.GetComponent<Snake>().isMoved = true;
        StartCoroutine(Snake.GetComponent<Snake>().MoveCoroutinte());
        menu.SetActive(false);
    }
    public void InMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void ShowMenuForLoosGame(int points)
    {
        menu2.SetActive(true);
        textPoints.GetComponent<Text>().text = points.ToString();
    }
}