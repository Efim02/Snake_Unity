using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    
    private GameObject NextSnake;
    public GameObject segment;

    public Vector2 Previous;
    void Start()
    {

    }
    void Update()
    {
        
    }
    
    internal void Move(Vector2 vector)
    {
        Previous = transform.position;
        transform.position = vector;
        if(NextSnake !=null)
            NextSnake.GetComponent<SnakeSegment>().Move(Previous);
        else if(NextSnake == null)
        {
            Basis.ListVectors.Add(Previous);
        }
    }
    internal void Add(int pCount)
    {
        if(NextSnake == null)
        {
            NextSnake = Instantiate(segment);
            NextSnake.transform.position = Previous;
            FlipSprite();
        }
        else
        {
            NextSnake.GetComponent<SnakeSegment>().Add(pCount);
        }
    }
    internal void FlipSprite()
    {
        NextSnake.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
    
}
