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

    // Start is called before the first frame update
    void Start()
    {
        items = new Queue<GameObject>();
        TotalFigures = 3;

        for(int i=0; i<TotalFigures; i++)
        {
            PushItemIntoQueue();
        }

        UpdateStackPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PullItemFromQueue();
            PushItemIntoQueue();
            UpdateStackPositions();
        }
    }
    private void PushItemIntoQueue()
    {
        var temp = Instantiate(weaponsFigures[Random.Range(0, (int)TotalFigures)]);
        items.Enqueue(temp);
    }

    private void PullItemFromQueue()
    {
        var temp = items.Dequeue();
        used.transform.localScale = used.transform.localScale;
        used.GetComponent<Renderer>().material = temp.GetComponent<Renderer>().material;
        Destroy(temp);
    }

    private void UpdateStackPositions()
    {
        int index = 0;

        foreach(GameObject item in items)
        {
            item.transform.position = positions[index];
            index ++;
        }
    }
}
