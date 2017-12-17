using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{

    public static int pusherOneX, pusherOneY;
    public int oldOneX, oldOneY;
    public int width, height;
    public static GameObject[,] pusherGrid;
    public int randomValue;

    public Color[] color;
    public Material clearColor;

    public GameObject pusherOne;
    Vector3 positionOne;

    

    // Use this for initialization
    void Start()
    {
        Color[] color = new Color[6];
        color[0] = Color.black;
        color[1] = Color.blue;
        color[2] = Color.green;
        color[3] = Color.red;
        color[4] = Color.yellow;
        color[5] = Color.white;

        width = 10;
        height = 7;
        pusherOneX = 5;
        pusherOneY = height - 1;
        randomValue = 0;

        pusherGrid = new GameObject[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                positionOne = new Vector3(x * 8, y * 8, 2);
                pusherGrid[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                pusherGrid[x, y].GetComponent<Renderer>().material = clearColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //planning phase
        if (MainControl.planningStart)
        {
            MainControl.resolutionStart = false;
            MainControl.scoringStart = false;
            //pusher one moves counterclockwise
            if (Input.GetButtonDown("pushLeft"))
            {
                oldOneX = pusherOneX;
                oldOneY = pusherOneY;

                if (pusherOneY == 6 && pusherOneX > 0)
                {
                    //move left
                    pusherOneX--;
                }
                else if (pusherOneX == 0 && pusherOneY != 0)
                {
                    //move down
                    pusherOneY--;
                }
                else if (pusherOneY == 0 && pusherOneX < width-1)
                {
                    //move right
                    pusherOneX++;
                }
                else
                {
                    //move up
                    pusherOneY++;
                }
                    return;
                }

            //pusher one moves clockwise
            if (Input.GetButtonDown("pushRight"))
            {
                oldOneX = pusherOneX;
                oldOneY = pusherOneY;

                if (pusherOneY == 6 && pusherOneX < width-1)
                {
                    //move left
                    pusherOneX++;
                }
                else if (pusherOneX == width-1 && pusherOneY != 0)
                {
                    //move down
                    pusherOneY--;
                }
                else if (pusherOneY == 0 && pusherOneX > 0)
                {
                    //move right
                    pusherOneX--;
                }
                else
                {
                    //move up
                    pusherOneY++;
                }
                return;
            }

            MainControl.rowTracker = pusherOneY;
            MainControl.columnTracker = pusherOneX;
            pusherGrid[pusherOneX, pusherOneY].GetComponent<Renderer>().material.color = Color.red;
            pusherGrid[oldOneX, oldOneY].GetComponent<Renderer>().material = clearColor;
            
        }
        
        if (MainControl.resolutionStart)
        {
            pusherGrid[pusherOneX, pusherOneY].GetComponent<Renderer>().material = clearColor;
        }
    }
    }
