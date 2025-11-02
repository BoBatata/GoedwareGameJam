using UnityEngine;

public class AiManager : MonoBehaviour
{
    [SerializeField] private Room[] rooms;
    
    public Room GetRandomRoom()
    {
        Room room = rooms[Random.Range(0, rooms.Length)];
        print(room);
        return room;
    }
    
    public Room GetNearestRoomToPlayer(Transform player)
    {
        Room nearest = null;
        float shortest = Mathf.Infinity;

        foreach (Room r in rooms)
        {
            float dist = Vector3.Distance(player.position, r.transform.position);
            if (dist < shortest)
            {
                shortest = dist;
                nearest = r;
            }
        }
        return nearest;
    }
}
