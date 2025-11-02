using UnityEngine;

public class InteractableSearch : InteractableBase
{
    [SerializeField] private int searchLevel;
    [SerializeField] private float timeToSearch;
    [SerializeField] private float timeLapsed;

    private void Update()
    {
        SearchHandler();
    }

    public void SearchHandler()
    {
        if (isBeingInteracted)
        {
            timeLapsed += Time.deltaTime;

            if (timeLapsed >= timeToSearch)
            {
                searchLevel += 1;
                timeLapsed = 0;
            }
        }
        else if (!isBeingInteracted)
        {
            timeLapsed = 0;
        }
    }
}
