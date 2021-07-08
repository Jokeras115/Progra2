using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proccess : MonoBehaviour
{
    public GameObject[] listaNodosM;
    public GameObject[] listaNodosTM;
    public GameObject[] listaNodosBM;
    public GameObject[] listaNodosML;
    public GameObject[] listaNodosMR;
    public GameObject[] listaNodosC;
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

    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        //SetGrafo();
        SetOtherGrafo();
        //ShowIntMatrix(grafoEst.MId);
        //ShowIntArray(grafoEst.Etiqs);
    }
    void SetGrafo()
    {
        // inicializo TDA
        grafoEst.InicializarGrafo(210, 210, 210);

        //MidNodes
        for (int i = 0; i < listaNodosM.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = listaNodosM[i].GetComponent<NodoClass>().id;
            n1.gameObj = listaNodosM[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);

            // creo los objetos aristas
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = dicAristas.Count + 1;
            a1.idOrig = n1.id;
            a1.idDest = n1.id + 1;
            a1.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);

            // objeto arista
            Obj_Aristas a2 = new Obj_Aristas();
            a2.id = dicAristas.Count + 1;
            a2.idOrig = n1.id;
            a2.idDest = n1.id - 1;
            a2.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a2.id, a2);

            // objeto arista
            Obj_Aristas a3 = new Obj_Aristas();
            a3.id = dicAristas.Count + 1;
            a3.idOrig = n1.id;
            a3.idDest = n1.id + 35;
            a3.peso = 3;

            // agrego aristas al diccionario
            dicAristas.Add(a3.id, a3);

            // objeto arista
            Obj_Aristas a4 = new Obj_Aristas();
            a4.id = dicAristas.Count + 1;
            a4.idOrig = n1.id;
            a4.idDest = n1.id - 35;
            a4.peso = 2;

            // agrego aristas al diccionario
            dicAristas.Add(a4.id, a4);
        }
        //TopMidNodes
        for (int i = 0; i < listaNodosTM.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = listaNodosTM[i].GetComponent<NodoClass>().id;
            n1.gameObj = listaNodosTM[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);

            // creo los objetos aristas
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = dicAristas.Count + 1;
            a1.idOrig = n1.id;
            a1.idDest = n1.id + 1;
            a1.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);

            // objeto arista
            Obj_Aristas a2 = new Obj_Aristas();
            a2.id = dicAristas.Count + 1;
            a2.idOrig = n1.id;
            a2.idDest = n1.id - 1;
            a2.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a2.id, a2);

            // objeto arista
            Obj_Aristas a3 = new Obj_Aristas();
            a3.id = dicAristas.Count + 1;
            a3.idOrig = n1.id;
            a3.idDest = n1.id - 35;
            a3.peso = 2;

            // agrego aristas al diccionario
            dicAristas.Add(a3.id, a3);
        }
        //BotMidNodes
        for (int i = 0; i < listaNodosBM.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = listaNodosBM[i].GetComponent<NodoClass>().id;
            n1.gameObj = listaNodosBM[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);

            // creo los objetos aristas
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = dicAristas.Count + 1;
            a1.idOrig = n1.id;
            a1.idDest = n1.id + 1;
            a1.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);

            // objeto arista
            Obj_Aristas a2 = new Obj_Aristas();
            a2.id = dicAristas.Count + 1;
            a2.idOrig = n1.id;
            a2.idDest = n1.id - 1;
            a2.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a2.id, a2);

            // objeto arista
            Obj_Aristas a3 = new Obj_Aristas();
            a3.id = dicAristas.Count + 1;
            a3.idOrig = n1.id;
            a3.idDest = n1.id + 35;
            a3.peso = 3;

            // agrego aristas al diccionario
            dicAristas.Add(a3.id, a3);
        }
        //MidLeftNodes
        for (int i = 0; i < listaNodosML.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = listaNodosML[i].GetComponent<NodoClass>().id;
            n1.gameObj = listaNodosML[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);

            // creo los objetos aristas
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = dicAristas.Count + 1;
            a1.idOrig = n1.id;
            a1.idDest = n1.id + 1;
            a1.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);

            // objeto arista
            Obj_Aristas a2 = new Obj_Aristas();
            a2.id = dicAristas.Count + 1;
            a2.idOrig = n1.id;
            a2.idDest = n1.id + 35;
            a2.peso = 3;

            // agrego aristas al diccionario
            dicAristas.Add(a2.id, a2);

            // objeto arista
            Obj_Aristas a3 = new Obj_Aristas();
            a3.id = dicAristas.Count + 1;
            a3.idOrig = n1.id;
            a3.idDest = n1.id - 35;
            a3.peso = 2;

            // agrego aristas al diccionario
            dicAristas.Add(a3.id, a3);
        }
        //MidRightNodes
        for (int i = 0; i < listaNodosMR.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = listaNodosMR[i].GetComponent<NodoClass>().id;
            n1.gameObj = listaNodosMR[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);

            // creo los objetos aristas
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = dicAristas.Count + 1;
            a1.idOrig = n1.id;
            a1.idDest = n1.id + 35;
            a1.peso = 3;

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);

            // objeto arista
            Obj_Aristas a2 = new Obj_Aristas();
            a2.id = dicAristas.Count + 1;
            a2.idOrig = n1.id;
            a2.idDest = n1.id - 1;
            a2.peso = 1;

            // agrego aristas al diccionario
            dicAristas.Add(a2.id, a2);

            // objeto arista
            Obj_Aristas a3 = new Obj_Aristas();
            a3.id = dicAristas.Count + 1;
            a3.idOrig = n1.id;
            a3.idDest = n1.id - 35;
            a3.peso = 2;

            // agrego aristas al diccionario
            dicAristas.Add(a3.id, a3);
        }
        CornerNodes();


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
    void CornerNodes()
    {
        // creo el objeto que va a guardar los datos del nodo
        Obj_Nodos n1 = new Obj_Nodos();
        n1.id = listaNodosC[0].GetComponent<NodoClass>().id;
        n1.gameObj = listaNodosC[0];

        // agrego el objeto al diccionario de nodos
        dicNodos.Add(n1.id, n1);

        // creo los objetos aristas
        // objeto arista
        Obj_Aristas a11 = new Obj_Aristas();
        a11.id = dicAristas.Count + 1;
        a11.idOrig = n1.id;
        a11.idDest = n1.id + 1;
        a11.peso = 1;

        // agrego aristas al diccionario
        dicAristas.Add(a11.id, a11);

        // objeto arista
        Obj_Aristas a12 = new Obj_Aristas();
        a12.id = dicAristas.Count + 1;
        a12.idOrig = n1.id;
        a12.idDest = n1.id + 35;
        a12.peso = 3;

        // agrego aristas al diccionario
        dicAristas.Add(a12.id, a12);

        // creo el objeto que va a guardar los datos del nodo
        Obj_Nodos n2 = new Obj_Nodos();
        n2.id = listaNodosC[1].GetComponent<NodoClass>().id;
        n2.gameObj = listaNodosC[1];

        // agrego el objeto al diccionario de nodos
        dicNodos.Add(n2.id, n2);

        // creo los objetos aristas
        // objeto arista
        Obj_Aristas a21 = new Obj_Aristas();
        a21.id = dicAristas.Count + 1;
        a21.idOrig = n2.id;
        a21.idDest = n2.id - 1;
        a21.peso = 1;

        // agrego aristas al diccionario
        dicAristas.Add(a21.id, a21);

        // objeto arista
        Obj_Aristas a22 = new Obj_Aristas();
        a22.id = dicAristas.Count + 1;
        a22.idOrig = n2.id;
        a22.idDest = n2.id + 35;
        a22.peso = 3;

        // agrego aristas al diccionario
        dicAristas.Add(a22.id, a22);

        // creo el objeto que va a guardar los datos del nodo
        Obj_Nodos n3 = new Obj_Nodos();
        n3.id = listaNodosC[2].GetComponent<NodoClass>().id;
        n3.gameObj = listaNodosC[2];

        // agrego el objeto al diccionario de nodos
        dicNodos.Add(n3.id, n3);

        // creo los objetos aristas
        // objeto arista
        Obj_Aristas a31 = new Obj_Aristas();
        a31.id = dicAristas.Count + 1;
        a31.idOrig = n3.id;
        a31.idDest = n3.id + 1;
        a31.peso = 1;

        // agrego aristas al diccionario
        dicAristas.Add(a31.id, a31);

        // objeto arista
        Obj_Aristas a32 = new Obj_Aristas();
        a32.id = dicAristas.Count + 1;
        a32.idOrig = n3.id;
        a32.idDest = n3.id - 35;
        a32.peso = 2;

        // agrego aristas al diccionario
        dicAristas.Add(a32.id, a32);

        // creo el objeto que va a guardar los datos del nodo
        Obj_Nodos n4 = new Obj_Nodos();
        n4.id = listaNodosC[3].GetComponent<NodoClass>().id;
        n4.gameObj = listaNodosC[3];

        // agrego el objeto al diccionario de nodos
        dicNodos.Add(n4.id, n4);

        // creo los objetos aristas
        // objeto arista
        Obj_Aristas a41 = new Obj_Aristas();
        a41.id = dicAristas.Count + 1;
        a41.idOrig = n4.id;
        a41.idDest = n4.id - 1;
        a41.peso = 1;

        // agrego aristas al diccionario
        dicAristas.Add(a41.id, a41);

        // objeto arista
        Obj_Aristas a42 = new Obj_Aristas();
        a42.id = dicAristas.Count + 1;
        a42.idOrig = n4.id;
        a42.idDest = n4.id - 35;
        a42.peso = 2;

        // agrego aristas al diccionario
        dicAristas.Add(a42.id, a42);
    }
    public void AlgoritmoDijkstra(int nodo1, int nodo2)
    {
        // al algoritmo le paso el TDA_Grafo estático con los datos cargados y el vértice origen
        AlgDijkstra.Dijkstra(grafoEst, nodo1, nodo2);
        string ultimoCamino = AlgDijkstra.nodos[AlgDijkstra.nodos.Length - 1];
        MuestroResultadosAlg(AlgDijkstra.distance, nodo2, grafoEst.Etiqs, AlgDijkstra.nodos);
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
    public void ShowIntMatrix(int[,] matrix)
    {
        for (int i = 0; i < 210; i++)
        {
            for (int j = 0; j < 210; j++)
            {
                output.text += $"({matrix[i, j]})";
            }
            output.text += $"\n";
        }
    }
    public void ShowIntArray(int[] array)
    {
        for (int i = 0; i < 210; i++)
        {
            output.text += $"({array[i]})";
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
