using System.Collections;
using System.Collections.Generic;
using UnityEngine;                                  //Author : Pratyush Mishra

public class Spawningcircels : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private Vector2 pos;
    public GameObject circlePrefab;

    public GameObject linePrefab;
    public LayerMask circleLayer;

    private LineRenderer currentLine;
    private bool isDrawing = false;

    private void Start()
    {
        //setting the boundry in which circles will be created and then creating the circles
        SetMinAndMax();
        SpawnCircles(); // process repeats on clicking Restart button
    }

    private void Update()
    {
        //Handling the touch and trying the delete circles that can be detected.
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began )
            {
                StartDrawingLine(touch.position);
            } 
            else if (touch.phase == TouchPhase.Moved )
            {
                if(isDrawing)
                {
                    UpdateLine(touch.position);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndDrawingLine();
            }
        }
    }

    void StartDrawingLine(Vector2 position)
    {
        GameObject lineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine = lineObject.GetComponent<LineRenderer>();
        //currentLine.positionCount = 1;
        currentLine.SetPosition(0, Camera.main.ScreenToWorldPoint(position));
        isDrawing = true;
    }

    void UpdateLine(Vector2 position)
    {
        currentLine.positionCount++;
        currentLine.SetPosition(currentLine.positionCount - 1, Camera.main.ScreenToWorldPoint(position));
    }

    void EndDrawingLine()
    {
        isDrawing = false;
        Destroy(currentLine.gameObject); //destroying line at the end of the touch 

        //checking for colision with circles and make them invisible
        RaycastHit2D[] hits = Physics2D.LinecastAll(currentLine.GetPosition(0), currentLine.GetPosition(currentLine.positionCount - 1), circleLayer);
        foreach(RaycastHit2D hit in hits) // for any circle with raycast that collides with the line.
        {
            if (hit.collider.CompareTag("circle"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
    
    private void SetMinAndMax()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float border = 3.5f;
        
        minX = -Bounds.x + border;
        maxX = Bounds.x - border;
        minY = -Bounds.y + border;
        maxY = Bounds.y - border;
    }

    public void SpawnCircles()
    {
        int numberOfObjects = Random.Range(5, 11); // range : 5 to 10

        for(int i = 1; i <= numberOfObjects; i++)
        {
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject obj = Instantiate(circlePrefab, pos, Quaternion.identity);
            obj.transform.parent = transform;
            //Debug.Log(pos);
        }
    }

    // BUG detected : 1. In some cases it is not working. 
    // Line looking disconnected
}
