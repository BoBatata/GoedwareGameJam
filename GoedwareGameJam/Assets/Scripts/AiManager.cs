using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiManager : MonoBehaviour
{
    [SerializeField] private Room[] rooms;
    [SerializeField] public Room playerClosestRoom;
    [SerializeField] public BaseAI[] npcs;
    [SerializeField] public BaseAI[] npcsInfected;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        npcs = FindObjectsOfType<BaseAI>();
    }

    private void Start()
    {
        RandomNPCInfected(1);
    }

    private void Update()
    {
        playerClosestRoom = GetNearestRoomToPlayer(player.transform);
        Debug.DrawLine(player.transform.position, playerClosestRoom.transform.position, Color.red);
    }

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
        private void RandomNPCInfected(int amount)
        {
            npcsInfected = GameManager.Instance.SelectRandom(npcs, amount);
    
            foreach (var npc in npcsInfected)
            {
                npc._bef.isInfected = true;
            }
        }

        public void ActivateInfectedHunt(bool toggle)
        {
            foreach (var infected in npcsInfected)
            {
                infected._bef.isInfectedHuntTime = toggle;
                infected.ForceChangeState(new IdleState(infected));
            }
        }
    
}
