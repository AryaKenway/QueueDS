using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<NpcCharacter> cylinderQueue = new();
    public List<NpcCharacter> copiedArray = new();
    public int front = -1;
    public int rear = -1;
    [field: SerializeField] public NpcCharacter CylinderGameObject { get; set; }
    [field: SerializeField] public Color CylinderColor { get; private set; }

    public PlayerController()
    {
        cylinderQueue = new List<NpcCharacter>();
    }
    public void CreateAndEnqueue()
    {
        var character = Create();
        Enqueue(character);
        if (front == 0)
        {
            Moveit();
        }
    }
    public async void Moveit()
    {
        await Task.Delay(2000);
        CylinderGameObject.transform.position = new Vector3(2, 2, 6f);
        await Task.Delay(2000);
        CylinderGameObject.transform.position = new Vector3(2, 2, 5.5f);
        await Task.Delay(2000);
        CylinderGameObject.transform.position = new Vector3(2, 2, 4f);
        CylinderGameObject.transform.position = new Vector3(2, 2, 3.5f);

    }

    public NpcCharacter Create()
    {
        var character = Instantiate(CylinderGameObject);
        int number = Random.Range(0, 100);
        var color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        character.Color = color;
        character.PersonNumber = number;
        return character;
    }
    public void Enqueue(NpcCharacter character)
    {
        if (front == -1)
        {
            front = 0;
            cylinderQueue.Add(character);
            //cylinderQueue[rear] = character;
            Debug.Log($"NPC enqueued is {character.PersonNumber}");
            rear++;
        }
        else
        {
            {
                //cylinderQueue.Add(character);
                cylinderQueue.Add(character);
                // character.AddComponent<PlayerController>();
                Debug.Log($"NPC enqueued is {character.PersonNumber}");
                rear++;
            }
        }
    }
    public void Dequeue()
    {
        Peek();
        if (front >= rear)
        {
            Destroy(cylinderQueue[front].gameObject);
            cylinderQueue.RemoveAt(front);
            Debug.Log(rear);
            front = -1;
            rear = -1;
        }
        else
        {
            Destroy(cylinderQueue[front].gameObject);
            cylinderQueue.RemoveAt(front);
            Debug.Log(rear);
            rear--;
        }
    }
    public void Shift()
    {
        if (cylinderQueue[0] = null)
        {
            cylinderQueue[0] = cylinderQueue[0 + 1];
        }
    }
    public void Peek()
    {
        if (front == -1 && rear == -1)
        {
            Debug.Log("Underflow");
        }
        else
        {
            int cylindernum;
            cylindernum = cylinderQueue[front].PersonNumber;
            Debug.Log($"NPC is {cylindernum}");
        }
    }
    public void IsEmpty()
    {
        if (front == -1 && rear == -1)
        {
            Debug.Log("Is Empty");
        }
    }
}

