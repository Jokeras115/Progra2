using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static Queue<GameObject> items;
    public GameObject used;

    public List<Vector3> positions;
    public List<GameObject> weaponsFigures;
    private float TotalFigures;

    //Granades
    public static Stack<GameObject> granades;

    public List<Vector3> granadePositions;
    public List<GameObject> granadeFigures;
    private float TotalGranadeFigures;

    // Start is called before the first frame update
    void Start()
    {
        items = new Queue<GameObject>();
        granades = new Stack<GameObject>();
        TotalFigures = 3;
        TotalGranadeFigures = 3;

        for (int i=0; i<TotalFigures; i++)
        {
            PushItemIntoQueue();
        }

        for (int i = 0; i < TotalGranadeFigures; i++)
        {
            PushItemIntoStack();
        }

        UpdateQueuePositions();
        UpdateStackPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PullItemFromQueue();
            PushItemIntoQueue();
            UpdateQueuePositions();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            PullItemFromStack();
            UpdateStackPositions();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PushItemIntoStack();
            UpdateStackPositions();
        }
    }
    private void PushItemIntoQueue()
    {
        var temp = Instantiate(weaponsFigures[Random.Range(0, (int)TotalFigures)]);
        items.Enqueue(temp);
    }

    private void PushItemIntoStack()
    {
        if (granades.Count >= TotalGranadeFigures)
            return;
        var temp = Instantiate(granadeFigures[Random.Range(0, (int)TotalFigures)]);
        granades.Push(temp);
    }

    private void PullItemFromQueue()
    {
        var temp = items.Dequeue();
        used.transform.localScale = used.transform.localScale;
        used.GetComponent<Renderer>().material = temp.GetComponent<Renderer>().material;
        Destroy(temp);
    }

    private void PullItemFromStack()
    {
        if (granades.Count <= 0)
            return;
        var temp = granades.Pop();
        used.transform.localScale = used.transform.localScale;
        Destroy(temp);
    }

    private void UpdateQueuePositions()
    {
        int index = 0;

        foreach(GameObject item in items)
        {
            item.transform.position = positions[index];
            index ++;
        }
    }

    private void UpdateStackPositions()
    {
        int index = 0;

        foreach (GameObject granade in granades)
        {
            granade.transform.position = granadePositions[index];
            index++;
        }
    }
}
