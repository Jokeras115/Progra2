using UnityEngine;

public class MediPack : MonoBehaviour
{
    public MediPackTypes mediPackType;
    public int healAmmount;

    public MediPack(MediPackTypes type, int heal)
    {
        mediPackType = type;
        healAmmount = heal;
    }
}
