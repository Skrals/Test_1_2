using UnityEngine;

public class Controller 
{
    [SerializeField] private View playerView;
    [SerializeField] private Model playerModel;

    public Controller (View view , Model model)
    {
        playerView = view;
        playerModel = model;
    }

    public void ScoreAdd ()
    {
        playerModel.ChangeScore();
        playerView.ChangeText(playerModel.score);
    }
}
