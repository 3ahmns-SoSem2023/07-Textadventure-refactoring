using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject{

    //private static readonly System.Random getrandom = new System.Random(123);

    [TextArea(10,14)][SerializeField] string storyText;
    [TextArea(5, 14)] [SerializeField] string storyNextchoices;
    public State[] nextStates;
    public State[] randomStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public string GetStateStoryMenue()
    {
        return storyNextchoices;
    }

    public State[] GetNextStates()
    {
        if (randomStates.Length == 0)
        {
            return nextStates; 
        }

        State[] extendedArray = new State[nextStates.Length + 1];

        int rnd = PickBiasedRandomState(0, 0, randomStates.Length, 0.7);
        extendedArray[0] = randomStates[rnd];
        for (int i = 0; i < nextStates.Length; i++)
        {
            extendedArray[i + 1] = nextStates[i];
        }

        return extendedArray;
    }

    int PickBiasedRandomState(int idxPrefered, int randomMin, int randomMax, double probabilityPrefered)
    {
        //return getrandom.NextDouble() < 0.8 ? idxPrefered : getrandom.Next(idxMin, idxMax);
     
        if (RandomState.getrandom.NextDouble() < probabilityPrefered)
        {
            Debug.Log("< " + probabilityPrefered);
            return idxPrefered;
        }
        Debug.Log("> " + probabilityPrefered);
        return RandomState.getrandom.Next(randomMin, randomMax);
    }

}
