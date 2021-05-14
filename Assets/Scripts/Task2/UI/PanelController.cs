using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private InputField cooldownInput;
    [SerializeField] private InputField speedInput;
    [SerializeField] private InputField distanceInput;
    private void Start()
    {
        Data.cooldownTime = float.Parse(cooldownInput.text);
        Data.objectSpeed = float.Parse(speedInput.text);
        Data.pathLenght = float.Parse(distanceInput.text);
    }
    public void ChangeCooldownTime()
    {
        var value = float.Parse(cooldownInput.text);
        Data.cooldownTime = value;
        spawner.GetComponent<Spawner>().TimerValueUpdate();

    }
    public void ChangeSpeed()
    {
        var value = float.Parse(speedInput.text);
        Data.objectSpeed = value;
    }
    public void ChangeDistance()
    {
        var value = float.Parse(distanceInput.text);
        Data.pathLenght = value;

    }
}
