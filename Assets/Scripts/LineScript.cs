using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LineScript : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;

    [SerializeField]
    private float minimumDistance = 0.1f;
    [SerializeField]
    private float widthOfLine = 0.2f;

    private void Start()
    {
        line = GetComponent<LineRenderer>(); // attached to same game object
        line.positionCount = 1;
        previousPosition = transform.position;  
        line.startWidth = line.endWidth = widthOfLine;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;

            if(Vector3.Distance(currentPosition, previousPosition) > minimumDistance)
            {
                if(previousPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);

                }
                previousPosition = currentPosition;
            }
        }
    }
}
