using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter newKitchenCounter;
    }

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float interactDistance;

    [SerializeField] private LayerMask counterLayerMask;

    [SerializeField] private GameInput gameInput;


    private Vector3 lastInteractionDir;
    private BaseCounter selectedCounter;

    [SerializeField] private Transform objectSpawnPoint;

    private KitchenObject objectInHand;

    private void Awake()
    {
        if(Instance !=  null)
        {
            Debug.LogWarning("More than onw player");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void Update()
    {
        PlayerMovement();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if(movementDirection != Vector3.zero )
        {
            lastInteractionDir = movementDirection;
        }

        if (Physics.Raycast(transform.position, lastInteractionDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out BaseCounter counter) )
            {
                if (counter != selectedCounter)
                {
                    SetSelectedCounter(counter);
                }
            }
        }
        else
        {
            SetSelectedCounter(null);
        }

        //Debug.Log(selectedCounter);
    }
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if(selectedCounter != null)
            selectedCounter.Interact(this);
    }
    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        
        // IF THE PLAYER CANNOT MOVE IN CURRENT DIRECTION
        if(!canMoveInThisDirection(movementDirection))
        {
            Vector3 moveDirX = new Vector3(movementDirection.x, 0, 0).normalized;

            if(canMoveInThisDirection(moveDirX))                                                    // CHECK IF IT CAN MOVE ALONG THE X
            {
                movementDirection = moveDirX;
            }
            else                                                                                     // IF NOT, CHECK IF IT CAN MOVE ALONG THE Z
            {
                Vector3 moveDirZ = new Vector3(0,0,movementDirection.z).normalized;
                if(canMoveInThisDirection(moveDirZ))
                {
                    movementDirection = moveDirZ;
                }
            }
        }

        if(canMoveInThisDirection(movementDirection))
        {
            transform.position += movementDirection * movementSpeed * Time.deltaTime;
        }

        transform.forward = Vector3.Slerp(transform.forward, movementDirection, rotationSpeed * Time.deltaTime);
    }
    bool canMoveInThisDirection(Vector3 directionToMoveIn)
    {
        float playerRadius = 0.7f;
        float playerHeight = 2.0f;
        float moveDistance = movementSpeed * Time.deltaTime;

        if(Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, directionToMoveIn, moveDistance))
        {
            return false;
        }

        return true;
    }

    private void SetSelectedCounter(BaseCounter counter)
    {
        this.selectedCounter = counter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { newKitchenCounter = selectedCounter });
    }

    public Transform GetObjectSpawnPoint()
    {
        return objectSpawnPoint;
    }

    public void SetObjectOnTop(KitchenObject newObjectOnTop)
    {
        objectInHand = newObjectOnTop;
    }

    public KitchenObject GetObjectOnTop()
    {
        if(objectInHand)
            return objectInHand;

        return null;
    }

    public void ClearKitchenObject()
    {
        if (objectInHand)
            objectInHand = null;
    }

    public bool HasObjectOnTop()
    {
        return objectInHand != null;
    }
}
