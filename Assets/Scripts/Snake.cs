using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
public class Snake : MonoBehaviour
{
    public static int points = 0;
    int maxPoints = 178;


    public bool isMoved = true;
    internal Vector3 direction;
    internal Vector2 Previous;
    public float Speed = 0.4f;

    Vector2 endPos;
    Vector2 startPos = new Vector2(0, 0);

    public GameObject SpriteObject;
    public GameObject segment;
    GameObject SnakeSegment;
    public GameObject menu;
    public AudioClip audioLoos;

    void Start()
    {
        direction = transform.up;
        //Запускаем движение змейки 
        StartCoroutine(MoveCoroutinte());
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    endPos = touch.position;
                    if (Abs(endPos.x - startPos.x) > 50 || Abs(endPos.y - startPos.y) > 50)
                    {
                        direction = CalculateDirection(endPos - startPos);
                    }
                    break;
            }
        }
        SpriteRotation();

        if(Input.GetKeyDown(KeyCode.W))
        {
            direction = new Vector3(0,1,0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = new Vector3(1,0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = new Vector3(-1,0,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Point"))
        {
            AddSegment();
            Destroy(coll.gameObject);
            Basis.SpawnPoint();
        }
        if (coll.gameObject.tag == "SnakeSegment")
        {
            TheEnd();
        }
    }
    
    public IEnumerator MoveCoroutinte()
    {
        yield return new WaitForSeconds(Speed);
        if (isMoved == false)
        {
            yield return new WaitForSeconds(0f);
        }
        Previous = transform.position;
        transform.Translate(direction);
        Basis.ListVectors.Remove(transform.position);
        if (SnakeSegment != null)
            SnakeSegment.GetComponent<SnakeSegment>().Move(Previous);
        else if (SnakeSegment == null)
            Basis.ListVectors.Add(Previous);
        if (isMoved == true)
        {
            StartCoroutine(MoveCoroutinte());
        }
    }
    void AddSegment()
    {
        points++;
        GetComponent<AudioSource>().Play();
        if (SnakeSegment == null)
        {
            SnakeSegment = Instantiate(segment);
            SnakeSegment.transform.position = Previous;
        }
        else
        {
            SnakeSegment.GetComponent<SnakeSegment>().Add(points);
        }
        if(points>maxPoints)
        {
            TheEnd();
        }
    }
    Vector2 CalculateDirection(Vector2 vector)
    {
        float x = vector.x;
        float y = vector.y;
        if(Abs(x)>Abs(y))
        {
            x = Mathf.Sign(x);
            return new Vector2(x,0);
        }
        else if(Abs(x)<Abs(y))
        {
            y = Mathf.Sign(y);
            return new Vector2(0, y);
        }
        return direction;
    }
    
    void TheEnd()
    {
        isMoved = false;
        GetComponent<AudioSource>().clip = audioLoos;
        GetComponent<AudioSource>().Play();
        if(StaticClass.Load()<points)
        {
            StaticClass.Save();
        }
        menu.GetComponent<GameMenu>().ShowMenuForLoosGame(points);
    }
    void SpriteRotation()
    {
        if (direction.x == 0 && direction.y == 1)
            SpriteObject.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        else if (direction.x == 0 && direction.y == -1)
            SpriteObject.GetComponent<Transform>().rotation = new Quaternion(0, 0, 180, 0);
        else if (direction.x == 1 && direction.y == 0)
            SpriteObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,-90);
        else if (direction.x == -1 && direction.y == 0)
            SpriteObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
    }
   /* private void OnGUI()
    {
        GUI.Label(new Rect(20,20,200,50), direction.ToString());
    }*/
}
