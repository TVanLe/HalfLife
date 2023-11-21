using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{
    public static InputManger Instance { get; private set; }
    public float horizontal { get; private set; }
    public bool jump { get; private set; }
    public bool shoot { get; private set; }
    public Vector3 mousePostion { get; private set; }
    private void Awake()
    {
        if (InputManger.Instance != null)
        {
            Debug.LogError("Onlly 1 InputManger allow to exist");
        }
        
        else
        {
            InputManger.Instance = this;
        }
    }

    private void Update()
    {
        GetMousePos();
        GetKeyHorizontal();
        GetKeyJump();
        IsMouseShoot();
    }

    public void GetMousePos()
    {
        mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetKeyHorizontal()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    protected virtual void GetKeyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            jump = true;
        else
            jump = false;
    }

    protected virtual void IsMouseShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }
    }
}

