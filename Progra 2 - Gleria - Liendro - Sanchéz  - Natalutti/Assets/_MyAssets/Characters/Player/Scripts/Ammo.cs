using UnityEngine;

public class Ammo : MonoBehaviour
{
    public BulletTypes ammoType;
    public int quantity;

    public Ammo(BulletTypes type, int q)
    {
        ammoType = type;
        quantity = q;
    }
}
