using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static Queue<GameObject> items;
    public GameObject nextItem;

    public List<Vector3> positions;
    public List<GameObject> weaponsFigures;
    private float TotalFigures;

    // Start is called before the first frame update
    void Start()
    {
        items = new Queue<GameObject>();
        TotalFigures = 2;

        for(int i=0; i<TotalFigures; i++)
        {
            PushItemIntoQueue();
        }

        UpdateStackPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PullItemFromQueue();
            PushItemIntoQueue();
            UpdateStackPositions();
        }
    }

    /* Se instancia una figura random del tetris y se guarda en un objeto temporal
     * Se agrega el objeto temporal a la cola
     */
    private void PushItemIntoQueue()
    {
        /* A completar */
        var temp = Instantiate(weaponsFigures[Random.Range(0, (int)TotalFigures)]);
        items.Enqueue(temp);
    }

    /* Se extrae un objeto de la cola
     * Se copia la escala y el material del objeto extraido de la cola al objeto "nextItem"
     * Se destruye el objeto extraido de la cola
     */
    private void PullItemFromQueue()
    {
        /* A completar */
        var temp = items.Dequeue();
        nextItem.transform.localScale = temp.transform.localScale;
        nextItem.GetComponent<Renderer>().material = temp.GetComponent<Renderer>().material;
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
