using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainControl : MonoBehaviour
{

    public GameObject basicCube;
    public GameObject pusherOne;
    public GameObject pusherTwo;
    public static GameObject onePosition;
    public Button actionButton;
    Vector3 basicPosition;
    Vector3 positionOne;
    Vector3 positionTwo;

    public GameObject[,] grid;
    public Color[] colors;
    public List<int> possibleNumbers;

    int maxWidth, maxHeight;
    int maxGridWidth, maxGridHeight;
    int gridWidth, gridHeight;
    int colorTracker;
    int randomValue;
    int storedValue;
    int pusherOneX, pusherOneY;
    int pusherTwoX, pusherTwoY;
    int oldOneX, oldOneY;
    int oldTwoX, oldTwoY;

    public static bool actionStart;
    bool planningStart;

    // Use this for initialization
    void Start()
    {
        maxWidth = 11;
        maxHeight = 8;
        maxGridWidth = 9;
        maxGridHeight = 6;
        gridWidth = 8;
        gridHeight = 5;
        colorTracker = 0;

        actionStart = false;
        planningStart = true;
        List<int> possibleNumbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5 });

        GameObject[,] grid = new GameObject[maxWidth, maxHeight];
        Color[] colors = new Color[6];
        colors[0] = Color.black;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.red;
        colors[4] = Color.yellow;
        colors[5] = Color.white;

        //creates grid and sets colors
        for (int x = 1; x < maxGridWidth; x++)
        {
            for (int y = 1; y < maxGridHeight; y++)
            {
                basicPosition = new Vector3(x * 4, y * 4, 0);
                grid[x, y] = Instantiate(basicCube, basicPosition, Quaternion.identity);
            }
        }

        pusherOneX = 5;
        pusherOneY = maxGridHeight;
        pusherTwoX = maxGridWidth;
        pusherTwoY = 2;

        positionOne = new Vector3(pusherOneX*4, pusherOneY*4, 0);
        positionTwo = new Vector3(pusherTwoX*4, pusherTwoY*4, 0);

        Instantiate(pusherOne, positionOne, Quaternion.identity);
        Instantiate(pusherTwo, positionTwo, Quaternion.identity);


        //cubes are colored by row for simplicity. Checks to see if there is a matching color.
        //Will get a new color if the one above it is the same color.

        //row one
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 1;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y < 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y + 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row two
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 2;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row three
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 3;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row four
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 4;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row five
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 5;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

    }

    public void startAction(bool x)
    {
        actionStart = x;
        print("action starting");
    }

        // Update is called once per frame
        void Update()
        {
        //planning phase
        if (planningStart)
        {
            if (Input.GetButtonDown("pushLeft"))
            {
                onePosition = pusherOne;
                oldOneX = pusherOneX;
                oldOneY = pusherOneY;
                //pusher one moves counterclockwise
                if (pusherOneY == maxGridHeight && pusherOneX > 0)
                {
                    //move left
                    pusherOneX--;
                } else if (pusherOneX == 0 && pusherOneY != 0){
                    //move down
                    pusherOneY--;
                } else if (pusherOneY == 0 && pusherOneX < maxGridWidth)
                {
                    //move right
                    pusherOneX++;
                } else
                {
                    //move up
                    pusherOneY++;
                }
                positionOne = new Vector3(pusherOneX * 4, pusherOneY * 4, 0);
                print("x pos: " + pusherOneX + " y pos: " + pusherOneY);
                Instantiate(pusherOne, positionOne, Quaternion.identity);
                return;
            }

            if (Input.GetButtonDown("pushRight"))
            {
                //pusher one moves clockwise
            }
            if (Input.GetButtonDown("pushUp"))
            {
                //pusher two moves counterclockwise
            }
            if (Input.GetButtonDown("pushDown"))
            {
                //pusher two moves clockwise
            }
        }

        

        //action phase

        if (actionStart == true)
        {
            print("actioning");
            planningStart = false;
            if (Time.timeSinceLevelLoad <= 4)
            {
                //onmousedown destroy cubes

                
                print("Success");
            } else
            {
                actionStart = false;
                print("Success End");
            }
        }


    }
    
}

