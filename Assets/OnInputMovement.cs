using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityAtoms.BaseAtoms;
using UniRx;

public class OnInputMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2Variable movementVar;
    private PlayerInput playerInput;
private void Awake()
{ 
    playerInput = GetComponent<PlayerInput>(); 
}

private void Start()
{
    playerInput.currentActionMap.FindAction("Move", true).AsObservable()
    .Subscribe(action => movementVar.SetValue(action.ReadValue<Vector2>()))
    .AddTo(this);
    ;
}
}

public static class aClass {
    public static IObservable<InputAction.CallbackContext> AsObservable(this InputAction action) =>
Observable.FromEvent<InputAction.CallbackContext>(
    h =>
    {
        action.performed += h;
        action.canceled += h;
    },
    h =>
    {
        action.performed -= h;
        action.canceled -= h;
    });
}
