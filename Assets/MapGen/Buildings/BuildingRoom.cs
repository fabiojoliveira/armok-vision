﻿using RemoteFortressReader;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class BuildingRoom : MonoBehaviour
    {
        public GameObject part;

        List<GameObject> setParts = new List<GameObject>();

        internal void Initialize(BuildingInstance buildingInput)
        {
            if (setParts.Count > 0)
                return;
            foreach (var item in setParts)
            {
                Destroy(item.gameObject);
            }
            setParts.Clear();
            var room = buildingInput.room;
            if (room == null || room.extents.Count == 0)
                return;
            for (int x = 0; x < room.width; x++)
                for (int y = 0; y < room.height; y++)
                {
                    var set = room.extents[x + y * room.width];
                    if (set == 0)
                        continue;
                    GameObject newPart = Instantiate(part, GameMap.DFtoUnityCoord(room.pos_x + x, room.pos_y + y, buildingInput.pos_z_max), Quaternion.identity, transform);
                    setParts.Add(newPart);
                }
        }
    }
}
