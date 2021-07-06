using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    [Header("Privates Variables")]
    [Space]
    private GameObject currentBulletPrefab;
    [SerializeField] private GameObject basicBulletPrefab;
    [SerializeField] private GameObject blueBulletPrefab;
    [SerializeField] private GameObject greenBulletPrefab;
    [SerializeField] private GameObject redBulletPrefab;
    [SerializeField] private PlayerHealth lifeController;
    private Queue<Ammo> ammo = new Queue<Ammo>();
    private Stack<MediPack> mediPacks = new Stack<MediPack>();
    private float nextFire;
    private float nextHeal;
    private float fireRate = 0.2f;
    [Header("Privates References")]
    [Space]
    private PlayerHealth health;
    private MovementController movement;
    #endregion

    #region Public Variables
    [Header("Public References")]
    [Space]
    public Rigidbody2D rb;
    public Transform shootPoint;
    public BulletTypes ammoType;
    public MediPackTypes mediPackType;
    public int magazine;
    #endregion

    #region Unity Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<MovementController>();
        health = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        currentBulletPrefab = basicBulletPrefab;
        mediPackType = MediPackTypes.White;
    }

    void Update()
    {
        CheckAmmoType();
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject tempBullet = Instantiate(currentBulletPrefab, shootPoint.position, shootPoint.rotation);
            magazine--;
            if (!movement.facingRight)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }

        }
        if (Input.GetButtonDown("Fire2") && Time.time > nextHeal)
        {
            nextHeal = Time.time + fireRate;
            PullMediPack();
        }
    }
    #endregion

    #region Public Functions
    #endregion

    #region Private Functions
    private void CheckAmmoType()
    {
        if (ammo.Count > 0)
        {
            if(ammoType == BulletTypes.Basic)
            {
                Ammo tempAmmo = ammo.Dequeue();
                magazine = tempAmmo.quantity;
                ammoType = tempAmmo.ammoType;
                switch (ammoType)
                {
                    case BulletTypes.Blue:
                        currentBulletPrefab = blueBulletPrefab;
                        break;
                    case BulletTypes.Green:
                        currentBulletPrefab = greenBulletPrefab;
                        break;
                    case BulletTypes.Red:
                        currentBulletPrefab = redBulletPrefab;
                        break;
                    default:
                        break;
                }
            }
            else if(magazine <= 0)
            {
                Ammo tempAmmo = ammo.Dequeue();
                magazine = tempAmmo.quantity;
                ammoType = tempAmmo.ammoType;
                switch (ammoType)
                {
                    case BulletTypes.Blue:
                        currentBulletPrefab = blueBulletPrefab;
                        break;
                    case BulletTypes.Green:
                        currentBulletPrefab = greenBulletPrefab;
                        break;
                    case BulletTypes.Red:
                        currentBulletPrefab = redBulletPrefab;
                        break;
                    default:
                        break;
                }
            }
        }
        else if(magazine <= 0 && ammoType != BulletTypes.Basic)
        {
            ammoType = BulletTypes.Basic;
            currentBulletPrefab = basicBulletPrefab;
            magazine = int.MaxValue;
        }
    }
    void PullMediPack()
    {
        if (mediPacks.Count > 0)
        {
            MediPack tempPack = mediPacks.Pop();
            health.GetHeal(tempPack.healAmmount);
            if (mediPacks.Count > 0)
            {
                tempPack = mediPacks.Peek();
                mediPackType = tempPack.mediPackType;
            }
            else
                mediPackType = MediPackTypes.White;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ammo tempAmmo = collision.gameObject.GetComponent<Ammo>();
        if (tempAmmo != null)
        {
            ammo.Enqueue(new Ammo(tempAmmo.ammoType, tempAmmo.quantity));
            Destroy(collision.gameObject);
        }
        MediPack tempMediPack = collision.gameObject.GetComponent<MediPack>();
        if (tempMediPack != null)
        {
            mediPacks.Push(new MediPack(tempMediPack.mediPackType, tempMediPack.healAmmount));
            mediPackType = tempMediPack.mediPackType;
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
