using UnityEngine;
using UnityEngine.SceneManagement;
public class Application : MonoBehaviour
{
    [SerializeField] private Controller playerController;
    [SerializeField] private Model playerModel;
    [SerializeField] private View playerView;
    void Start()
    {
        playerModel = new Model();
        var palayerV = gameObject.GetComponent<View>();
        playerController = new Controller(palayerV, playerModel);
    }
    public void ButtonChangeScore ()
    {
        playerController.ScoreAdd();
    }
    
    public void ButtonChangeScene()
    {
        SceneManager.LoadScene("Task2");
    }
}
