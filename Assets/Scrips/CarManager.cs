using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    GameObject[] cars;

    [SerializeField] Gride grid;

    public Target Target;
    public GridePlate Plate;

    public static CarManager instant;

    private void Awake()
    {
        if (instant == null)
        {
            instant = this;
        }
        else
        {
            Destroy(this);
        }

        cars = null;
    }

    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Car");
    }

    // Update is called once per frame
    private void Update()
    {
        if ((Target != null) && (Plate != null) && Input.GetKeyDown(KeyCode.Mouse0))
        { 
            MoveTarget();
            Target = null;
            Plate = null;
        }
    }

    public void SetTarget(Target target)
    {
        Target = target;
    }

    public void GetPlate(GridePlate plate)
    {
        Plate = plate;
    }

    void MoveTarget()
    {
        int move = 0;

        if (Target.isFaceForword)
        {
            move = Plate.Y - Target.currentPlate.Y;
            Debug.Log("Y: " + move);
        }
        else if (!Target.isFaceForword)
        {
            move = Plate.X - Target.currentPlate.X;
            Debug.Log("X: " + move);
        }

        if (move < 0)
        {
            move *= -1;
            StartCoroutine(Target.MoveBackword(move));
        }
        else
        {
            StartCoroutine(Target.MoveForword(move));
        }
    }
}
