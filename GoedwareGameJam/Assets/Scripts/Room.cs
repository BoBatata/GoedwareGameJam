using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    public List<Transform> walkPoints = new List<Transform>();

    public Vector3 GetRandomPointInRoom()
    {
        if (walkPoints.Count == 0)
            return transform.position;

        Transform t = walkPoints[Random.Range(0, walkPoints.Count)];
        return t.position;
    }
}
