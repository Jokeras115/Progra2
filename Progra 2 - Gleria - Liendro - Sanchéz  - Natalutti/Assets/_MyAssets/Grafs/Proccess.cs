using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proccess : MonoBehaviour
{
    public Text output;
    public GameObject[] fila1;
    public GameObject[] fila2;
    public GameObject[] fila3;
    public GameObject[] fila4;
    public GameObject[] fila5;
    public GameObject[] fila6;

    Dictionary<int, Obj_Nodos> dicNodos = new Dictionary<int, Obj_Nodos>();
    Dictionary<int, Obj_Aristas> dicAristas = new Dictionary<int, Obj_Aristas>();

    GrafoMA grafoEst = new GrafoMA();

    void Start()
    {
        SetOtherGrafo();
    }
    void SetOtherGrafo()
    {
        // inicializo TDA
        grafoEst.InicializarGrafo(210, 210, 210);

        FilaBot(fila1);
        FilaMid(fila2);
        FilaMid(fila3);
        FilaMid(fila4);
        FilaMid(fila5);
        FilaTop(fila6);

        // cargo el TDA Grafos a partir de los diccionarios  /////////////////////////////////////////

        // agrego las nodos al TDA_Grafo a partir del diccionario
        foreach (KeyValuePair<int, Obj_Nodos> nodo in dicNodos)
        {
            // agrego los vértices (nodos)
            grafoEst.AgregarVertice(nodo.Key);
        }

        // agrego las aristas al TDA_Grafo a partir del diccionario
        foreach (KeyValuePair<int, Obj_Aristas> arista in dicAristas)
        {
            // agrego las aristas
            grafoEst.AgregarArista(arista.Key, arista.Value.idOrig, arista.Value.idDest, arista.Value.peso);
        }
    }
    void FilaBot(GameObject[] fila)
    {
        for (int i = 0; i < fila.Length; i++)
        {
            if (i == 0)
            {
                Obj_Nodos ni = new Obj_Nodos();
                ni.id = fila[i].GetComponent<NodoClass>().id;
                ni.gameObj = fila[i];

                dicNodos.Add(ni.id, ni);

                Obj_Aristas ai1 = new Obj_Aristas();
                ai1.id = dicAristas.Count + 1;
                ai1.idOrig = ni.id;
                ai1.idDest = ni.id + 1;
                ai1.peso = 1;

                dicAristas.Add(ai1.id, ai1);

                Obj_Aristas ai2 = new Obj_Aristas();
                ai2.id = dicAristas.Count + 1;
                ai2.idOrig = ni.id;
                ai2.idDest = ni.id + 35;
                ai2.peso = 1;

                dicAristas.Add(ai2.id, ai2);
            }
            else if (i == fila.Length - 1)
            {
                Obj_Nodos nf = new Obj_Nodos();
                nf.id = fila[i].GetComponent<NodoClass>().id;
                nf.gameObj = fila[i];

                dicNodos.Add(nf.id, nf);

                Obj_Aristas af1 = new Obj_Aristas();
                af1.id = dicAristas.Count + 1;
                af1.idOrig = nf.id;
                af1.idDest = nf.id - 1;
                af1.peso = 1;

                dicAristas.Add(af1.id, af1);

                Obj_Aristas af2 = new Obj_Aristas();
                af2.id = dicAristas.Count + 1;
                af2.idOrig = nf.id;
                af2.idDest = nf.id + 35;
                af2.peso = 1;

                dicAristas.Add(af2.id, af2);
            }
            else
            {
                Obj_Nodos node = new Obj_Nodos();
                node.id = fila[i].GetComponent<NodoClass>().id;
                node.gameObj = fila[i];

                dicNodos.Add(node.id, node);

                Obj_Aristas a1 = new Obj_Aristas();
                a1.id = dicAristas.Count + 1;
                a1.idOrig = node.id;
                a1.idDest = node.id - 1;
                a1.peso = 1;

                dicAristas.Add(a1.id, a1);

                Obj_Aristas a2 = new Obj_Aristas();
                a2.id = dicAristas.Count + 1;
                a2.idOrig = node.id;
                a2.idDest = node.id + 35;
                a2.peso = 1;

                dicAristas.Add(a2.id, a2);

                Obj_Aristas a3 = new Obj_Aristas();
                a3.id = dicAristas.Count + 1;
                a3.idOrig = node.id;
                a3.idDest = node.id + 1;
                a3.peso = 1;

                dicAristas.Add(a3.id, a3);
            }
        }
    }
    void FilaMid(GameObject[] fila)
    {
        for (int i = 0; i < fila.Length; i++)
        {
            if (i == 0)
            {
                Obj_Nodos ni = new Obj_Nodos();
                ni.id = fila[i].GetComponent<NodoClass>().id;
                ni.gameObj = fila[i];

                dicNodos.Add(ni.id, ni);

                Obj_Aristas ai1 = new Obj_Aristas();
                ai1.id = dicAristas.Count + 1;
                ai1.idOrig = ni.id;
                ai1.idDest = ni.id + 1;
                ai1.peso = 1;

                dicAristas.Add(ai1.id, ai1);

                Obj_Aristas ai2 = new Obj_Aristas();
                ai2.id = dicAristas.Count + 1;
                ai2.idOrig = ni.id;
                ai2.idDest = ni.id + 35;
                ai2.peso = 1;

                dicAristas.Add(ai2.id, ai2);

                Obj_Aristas ai3 = new Obj_Aristas();
                ai3.id = dicAristas.Count + 1;
                ai3.idOrig = ni.id;
                ai3.idDest = ni.id - 35;
                ai3.peso = 1;

                dicAristas.Add(ai3.id, ai3);
            }
            else if (i == fila.Length - 1)
            {
                Obj_Nodos nf = new Obj_Nodos();
                nf.id = fila[i].GetComponent<NodoClass>().id;
                nf.gameObj = fila[i];

                dicNodos.Add(nf.id, nf);

                Obj_Aristas af1 = new Obj_Aristas();
                af1.id = dicAristas.Count + 1;
                af1.idOrig = nf.id;
                af1.idDest = nf.id - 1;
                af1.peso = 1;

                dicAristas.Add(af1.id, af1);

                Obj_Aristas af2 = new Obj_Aristas();
                af2.id = dicAristas.Count + 1;
                af2.idOrig = nf.id;
                af2.idDest = nf.id + 35;
                af2.peso = 1;

                dicAristas.Add(af2.id, af2);

                Obj_Aristas af3 = new Obj_Aristas();
                af3.id = dicAristas.Count + 1;
                af3.idOrig = nf.id;
                af3.idDest = nf.id - 35;
                af3.peso = 1;

                dicAristas.Add(af3.id, af3);
            }
            else
            {
                Obj_Nodos node = new Obj_Nodos();
                node.id = fila[i].GetComponent<NodoClass>().id;
                node.gameObj = fila[i];

                dicNodos.Add(node.id, node);

                Obj_Aristas a1 = new Obj_Aristas();
                a1.id = dicAristas.Count + 1;
                a1.idOrig = node.id;
                a1.idDest = node.id - 1;
                a1.peso = 1;

                dicAristas.Add(a1.id, a1);

                Obj_Aristas a2 = new Obj_Aristas();
                a2.id = dicAristas.Count + 1;
                a2.idOrig = node.id;
                a2.idDest = node.id + 35;
                a2.peso = 1;

                dicAristas.Add(a2.id, a2);

                Obj_Aristas a3 = new Obj_Aristas();
                a3.id = dicAristas.Count + 1;
                a3.idOrig = node.id;
                a3.idDest = node.id + 1;
                a3.peso = 1;

                dicAristas.Add(a3.id, a3);

                Obj_Aristas a4 = new Obj_Aristas();
                a4.id = dicAristas.Count + 1;
                a4.idOrig = node.id;
                a4.idDest = node.id - 35;
                a4.peso = 1;

                dicAristas.Add(a4.id, a4);
            }
        }
    }
    void FilaTop(GameObject[] fila)
    {
        for (int i = 0; i < fila.Length; i++)
        {
            if (i == 0)
            {
                Obj_Nodos ni = new Obj_Nodos();
                ni.id = fila[i].GetComponent<NodoClass>().id;
                ni.gameObj = fila[i];

                dicNodos.Add(ni.id, ni);

                Obj_Aristas ai1 = new Obj_Aristas();
                ai1.id = dicAristas.Count + 1;
                ai1.idOrig = ni.id;
                ai1.idDest = ni.id + 1;
                ai1.peso = 1;

                dicAristas.Add(ai1.id, ai1);

                Obj_Aristas ai2 = new Obj_Aristas();
                ai2.id = dicAristas.Count + 1;
                ai2.idOrig = ni.id;
                ai2.idDest = ni.id - 35;
                ai2.peso = 1;

                dicAristas.Add(ai2.id, ai2);
            }
            else if (i == fila.Length - 1)
            {
                Obj_Nodos nf = new Obj_Nodos();
                nf.id = fila[i].GetComponent<NodoClass>().id;
                nf.gameObj = fila[i];

                dicNodos.Add(nf.id, nf);

                Obj_Aristas af1 = new Obj_Aristas();
                af1.id = dicAristas.Count + 1;
                af1.idOrig = nf.id;
                af1.idDest = nf.id - 1;
                af1.peso = 1;

                dicAristas.Add(af1.id, af1);

                Obj_Aristas af2 = new Obj_Aristas();
                af2.id = dicAristas.Count + 1;
                af2.idOrig = nf.id;
                af2.idDest = nf.id - 35;
                af2.peso = 1;

                dicAristas.Add(af2.id, af2);
            }
            else
            {
                Obj_Nodos node = new Obj_Nodos();
                node.id = fila[i].GetComponent<NodoClass>().id;
                node.gameObj = fila[i];

                dicNodos.Add(node.id, node);

                Obj_Aristas a1 = new Obj_Aristas();
                a1.id = dicAristas.Count + 1;
                a1.idOrig = node.id;
                a1.idDest = node.id - 1;
                a1.peso = 1;

                dicAristas.Add(a1.id, a1);

                Obj_Aristas a2 = new Obj_Aristas();
                a2.id = dicAristas.Count + 1;
                a2.idOrig = node.id;
                a2.idDest = node.id - 35;
                a2.peso = 1;

                dicAristas.Add(a2.id, a2);

                Obj_Aristas a3 = new Obj_Aristas();
                a3.id = dicAristas.Count + 1;
                a3.idOrig = node.id;
                a3.idDest = node.id + 1;
                a3.peso = 1;

                dicAristas.Add(a3.id, a3);
            }
        }
    }
    public void AlgoritmoDijkstra(int nodo1, int nodo2)
    {
        // al algoritmo le paso el TDA_Grafo estático con los datos cargados y el vértice origen
        AlgDijkstra.Dijkstra(grafoEst, nodo1, nodo2);
        string ultimoCamino = AlgDijkstra.nodos[AlgDijkstra.nodos.Length - 1];
        //MuestroResultadosAlg(AlgDijkstra.distance, nodo2, grafoEst.Etiqs, AlgDijkstra.nodos);
        IluminarCamino(ultimoCamino.Split(','));
    }
    public void MuestroResultadosAlg(int[] distance, int verticesCount, int[] Etiqs, string[] caminos)
    {
        string distancia = "";

        for (int i = 0; i < verticesCount; ++i)
        {
            if (distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = distance[i].ToString();
            }

            output.text = $"Camino: {caminos[i]}\nDistancia: {distancia}";
        }
    }
    void IluminarCamino(string[] camino)
    {
        int[] nodos = new int[camino.Length];
        for (int i = 0; i < camino.Length; i++)
        {
            nodos[i] = int.Parse(camino[i]);
        }
        foreach (KeyValuePair<int, Obj_Nodos> nodo in dicNodos)
        {
            for (int i = 0; i < nodos.Length - 1; i++)
            {
                if (nodo.Key == nodos[i])
                {
                    nodo.Value.gameObj.GetComponent<NodoClass>().sprite.enabled = true;
                }
            }
        }
        StartCoroutine(ExecuteAfterTime(1.5f, nodos));
    }
    IEnumerator ExecuteAfterTime(float time, int[] nodos)
    {
        yield return new WaitForSeconds(time);

        foreach (KeyValuePair<int, Obj_Nodos> nodo in dicNodos)
        {
            for (int i = 0; i < nodos.Length - 1; i++)
            {
                if (nodo.Key == nodos[i])
                {
                    nodo.Value.gameObj.GetComponent<NodoClass>().sprite.enabled = false;
                }
            }
        }
    }
}
