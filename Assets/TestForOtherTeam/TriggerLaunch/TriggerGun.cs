
using UnityEngine;
using Random = UnityEngine.Random;

public class TriggerGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Look;
    protected Animator animator;
    protected Transform muzzlePos;
    protected Transform shellPos;

   
    
    protected Vector2 mousePos;
    protected Vector2 direction;
    protected float flipY;

    public float interval;

    //protected TimerTools _timerTools = new TimerTools();

    // Start is called before the first frame update
    void Awake()
    {
        //_timerTools.SetTime(interval);
        flipY = transform.localScale.y;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        Shoot();
    }

    protected virtual void Shoot()
    {
        //_timerTools.Run();
        if (Input.GetButton("Fire1"))
        {
            // if (!_timerTools.isTimeExist)
            // {
            //     _timerTools.SetTime(interval);
            //    
                Fire();
            // }
        }
    }

    public float backPower = 0.2f;

    protected virtual void Fire()
    {
        direction = transform.up;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;

        float angel = Random.Range(-15f, 15f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);
    }
}