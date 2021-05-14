using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject instanceObject;
    [SerializeField] private float cooldown;
    [SerializeField] private float timer;
    [SerializeField] bool spawn;
    void Start()
    {
        cooldown = Data.cooldownTime;
        InstanceObject();
    }
    void Update()
    {
        Timer();
    }
    public void TimerValueUpdate()
    {
        cooldown = Data.cooldownTime;
        timer = cooldown;
    }
    public void Timer()
    {
        if (timer <= 0)
        {
            timer = cooldown;
            spawn = true;
            InstanceObject();
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    public void InstanceObject()
    {
        if (spawn)
        {
            var obj = Instantiate(instanceObject, gameObject.transform.position, Quaternion.identity);
            obj.AddComponent<ObjectLogic>();
            spawn = false;
        }
    }

}
