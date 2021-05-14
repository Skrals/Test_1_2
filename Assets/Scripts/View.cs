using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Text scoreText;
    
    public void ChangeText (int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
