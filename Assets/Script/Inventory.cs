using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    public GameObject[] itemPrefabs;
    public int selectedItemIndex = 0;
    public float placementRange = 2.0f;  // How close the player needs to be to place an item

    // Place the currently selected item if near a placement point
    void PlaceSelectedItem()
    {
        if (items.Count > 0 && selectedItemIndex < itemPrefabs.Length && itemPrefabs[selectedItemIndex] != null)
        {
            // Find the nearest placement point within the range
            GameObject nearestPlacementPoint = FindNearestPlacementPoint();

            if (nearestPlacementPoint != null)
            {
                // Get the position of the placement point
                Vector3 placePosition = nearestPlacementPoint.transform.position;

                // Instantiate the item at the placement point
                Instantiate(itemPrefabs[selectedItemIndex], placePosition, Quaternion.identity);

                Debug.Log("Item placed at " + placePosition);
            }
            else
            {
                Debug.Log("No valid placement point found nearby.");
            }
        }
        else
        {
            Debug.Log("Cannot place item: Index is out of bounds or itemPrefab is missing.");
        }
    }

    // Find the nearest placement point within the specified range
    GameObject FindNearestPlacementPoint()
    {
        // Find all objects tagged as "PlacementPoint"
        GameObject[] placementPoints = GameObject.FindGameObjectsWithTag("PlacementPoint");
        GameObject nearestPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject point in placementPoints)
        {
            float distance = Vector3.Distance(transform.position, point.transform.position);
            if (distance < placementRange && distance < closestDistance)
            {
                closestDistance = distance;
                nearestPoint = point;
            }
        }

        return nearestPoint;
    }

    void Update()
    {
        // Scroll through items
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedItemIndex = (selectedItemIndex - 1 + items.Count) % items.Count;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedItemIndex = (selectedItemIndex + 1) % items.Count;
        }

        // Place item with "Q" key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceSelectedItem();
        }
    }
    public void AddItem(string itemName, Sprite itemIcon)
    {
        if (!items.Contains(itemName))
        {
            items.Add(itemName);
            // Add corresponding code to handle UI updates...
        }
        else
        {
            Debug.Log("Item already in inventory.");
        }
    }
    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
