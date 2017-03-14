using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class GenericActorController : MonoBehaviour {

    #region Accessor Properties
    private Rigidbody2D _rigidbody2D;
    protected new Rigidbody2D rigidbody2D
    {
        get
        {
            if (_rigidbody2D == null)
                _rigidbody2D = GetComponent<Rigidbody2D>();

            return _rigidbody2D;
        }
    }
    #endregion

    public Vector2 velocity;
    public float moveSpeed = 1;
    public float weight = 1;
    
    void Start()
    {

    }
    //void Update()
    //{
    //    //rigidbody2D.
    //}

}
