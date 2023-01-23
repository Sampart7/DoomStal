using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10; //szybkość gracza
    public float playerSprint = 20;
    private float controlSpeed;

    public float myGravity = -10; //ustawianie wartosci grawitacji
    public float momentumDumping = 5; //Waga poślizgu, momentu zatrzymania
    
    private CharacterController MainCharacter; //postać
    public Animator camAnim; //Animacja ruchu
    
    private bool isWalking; //sprawdza czy postac chodzi
    private Vector3 inputVector, movementVector; //Vector3 funkcja która robi łubudubu w 3 wymiarach
    
    private PlayerSword swd;
    public GameObject Sword;
    
    void Start()
    {
        controlSpeed = playerSpeed;
        MainCharacter = GetComponent<CharacterController>(); //pobieranie sterowania gracza
        swd = Sword.GetComponent<PlayerSword>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));  //daje do Vectora3 dane naszej fasolki 
            inputVector.Normalize(); //Ogarnia żeby zamiast iść prosto i w prawo to idzie na skos normalizuje ruch
            inputVector = transform.TransformDirection(inputVector); //ustalanie żeby patrzył do przodu zamiast w strone idącego kierunku

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, Time.deltaTime * momentumDumping); //Obliczenie poślizgu, momentu zatrzymania
            isWalking = false;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && swd.stamina > 10)
        {
            swd.stamina -= playerSprint * Time.deltaTime;
            playerSpeed = playerSprint;
        }
        else
        {
            playerSpeed = controlSpeed;
        }
        
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity); //wartość chodzenia z wcześniej ustalonych parametrów
        MainCharacter.Move(movementVector * Time.deltaTime); //sama czynność chodzenia razy czas zeby chodził tyle ile naciskamy zamiast się teleportował
        camAnim.SetBool("isWalking", isWalking); //dodanie funkcji aniamcji isWalking do animacji o nazwie isWalking w Unity
    }
    
    public void SetSpeed(float amount)
    {
        playerSpeed += amount;
        controlSpeed = playerSpeed;
        playerSprint += 2*amount;
    }
}
