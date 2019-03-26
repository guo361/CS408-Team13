using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour

{
    public string fight1;
    public string fight2;
    public string fight3;
    public string bossfight;


    #region Private Members

    private Animator _animator;

    private CharacterController _characterController;

    private float Gravity = 20.0f;

    private Vector3 _moveDirection = Vector3.zero;

    private InventoryItemBase mCurrentItem = null;

    private HealthBar mHealthBar;

    //private HealthBar mFoodBar;

    private int startHealth;

    //private int startFood;

    #endregion

    #region Public Members

    public float Speed = 5.0f;

    public float RotationSpeed = 240.0f;

    public Inventory Inventory;

    public GameObject Hand;

    public HUD Hud;

    public float JumpSpeed = 7.0f;

    #endregion

    public GameObject diepopup;
    public Text dietext;
    public Text mName;
    public int Health;

    public GameObject enemy1;
    // Use this for initialization
    void Start()
    {
        /*
        if (PlayerPrefs.GetInt("enemy1dead") == 1)
        {
            Debug.Log("fuckup");
            Destroy(enemy1);
        }*/
        if (PlayerPrefs.GetInt("infight") == 1)
        {
            transform.rotation = PlayerPosition.Instance.rotation;
            transform.position = PlayerPosition.Instance.position;
        }
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        Inventory.ItemUsed += Inventory_ItemUsed;
        Inventory.ItemRemoved += Inventory_ItemRemoved;

        mHealthBar = Hud.transform.Find("Bars_Panel/HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = 100;

        startHealth = 100;
        Health = (int)PlayerPrefs.GetFloat("Health");
        mHealthBar.SetValue((int) PlayerPrefs.GetFloat("Health",100.0f));
        Debug.Log("health in demo" + PlayerPrefs.GetFloat("Health", 100.0f));
        diepopup.SetActive(false);
        mName = Hud.transform.Find("Bars_Panel/playerName").GetComponent<Text>();
        mName.text = "Name: " + PlayerPrefs.GetString("Username");
        if (PlayerPrefs.GetInt("haveCards") == 0)
        {
            CardLibrary.Instance.cardNumber = 6;
            for(int i = 0; i < 4; i++)
            {
                Card newCard = new Card();

                newCard.cardName = "Strike";
                CardLibrary.Instance.myCards.Add(newCard);
            }
            for (int i = 0; i < 2; i++)
            {
                Card newCard = new Card();

                newCard.cardName = "Guard";
                CardLibrary.Instance.myCards.Add(newCard);
            }
            PlayerPrefs.SetInt("haveCards", 1);
        }
        /***
        mFoodBar = Hud.transform.Find("Bars_Panel/FoodBar").GetComponent<HealthBar>();
        mFoodBar.Min = 0;
        mFoodBar.Max = Food;
        startFood = Food;
        mFoodBar.SetValue(Food);

        InvokeRepeating("IncreaseHunger", 0, HungerRate);
        ***/
    }

    #region Inventory

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        InventoryItemBase item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;

    }

    private void SetItemActive(InventoryItemBase item, bool active)
    {
        GameObject currentItem = (item as MonoBehaviour).gameObject;
        currentItem.SetActive(active);
        currentItem.transform.parent = active ? Hand.transform : null;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        if (e.Item.ItemType != EItemType.Consumable)
        {
            // If the player carries an item, un-use it (remove from player's hand)
            if (mCurrentItem != null)
            {
                SetItemActive(mCurrentItem, false);
            }

            InventoryItemBase item = e.Item;

            // Use item (put it to hand of the player)
            SetItemActive(item, true);

            mCurrentItem = e.Item;
        }

    }

    private int Attack_1_Hash = Animator.StringToHash("Base Layer.Attack_1");

    public bool IsAttacking
    {
        get
        {
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.fullPathHash == Attack_1_Hash)
            {
                return true;
            }
            return false;
        }
    }

    public void DropCurrentItem()
    {
        _animator.SetTrigger("tr_drop");

        GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;

        Inventory.RemoveItem(mCurrentItem);

        // Throw animation
        Rigidbody rbItem = goItem.AddComponent<Rigidbody>();
        if (rbItem != null)
        {
            rbItem.AddForce(transform.forward * 2.0f, ForceMode.Impulse);

            Invoke("DoDropItem", 0.25f);
        }

    }

    public void DoDropItem()
    {

        // Remove Rigidbody
        Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());

        mCurrentItem = null;
    }

    #endregion

    #region Health





    [Tooltip("Rate in seconds in which the hunger increases")]
    public float HungerRate = 0.5f;

    /***
    public void IncreaseHunger()
    {
        Food--;
        if (Food < 0)
            Food = 0;

        mFoodBar.SetValue(Food);

        if (IsDead)
        {
            CancelInvoke();
            _animator.SetTrigger("death");
        }
    }
    ***/

    public bool IsDead
    {
        get
        {
            return Health == 0;
        }
    }

    public bool IsArmed
    {
        get
        {
            if (mCurrentItem == null)
                return false;

            return mCurrentItem.ItemType == EItemType.Weapon;
        }
    }

    /***
    public void Eat(int amount)
    {
        Food += amount;
        if (Food > startFood)
        {
            Food = startFood;
        }

        mFoodBar.SetValue(Food);

    }
    ***/

    public void Rehab(int amount)
    {
        Health += amount;
        if (Health > startHealth)
        {
            Health = startHealth;
        }

        mHealthBar.SetValue(Health);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;

        mHealthBar.SetValue(Health);
        PlayerPrefs.SetFloat("Health", Health);

        if (IsDead)
        {
            _animator.SetTrigger("death");
        }

    }

    #endregion


    void FixedUpdate()
    {
        if (!IsDead)
        {
            // Drop item
            if (mCurrentItem != null && Input.GetKeyDown(KeyCode.R))
            {
                DropCurrentItem();
            }
        }
    }

    private bool mIsControlEnabled = true;

    public void EnableControl()
    {
        mIsControlEnabled = true;
    }

    public void DisableControl()
    {
        mIsControlEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            diepopup.SetActive(true);
            dietext.text = "You Died ! ";
        }
        if (!IsDead && mIsControlEnabled)
        {
            // Interact with the item
            if (mInteractItem != null && Input.GetKeyDown(KeyCode.F))
            {
                // Interact animation
                mInteractItem.OnInteractAnimation(_animator);
            }

            // Execute action with item
            if (mCurrentItem != null && Input.GetMouseButtonDown(0))
            {
                // Dont execute click if mouse pointer is over uGUI element
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // TODO: Logic which action to execute has to come from the particular item
                    _animator.SetTrigger("attack_1");
                }
            }

            // Get Input for axis
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Calculate the forward vector
            Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

            if (move.magnitude > 1f) move.Normalize();

            // Calculate the rotation for the player
            move = transform.InverseTransformDirection(move);

            // Get Euler angles
            float turnAmount = Mathf.Atan2(move.x, move.z);

            transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

            if (_characterController.isGrounded)
            {
                _moveDirection = transform.forward * move.magnitude;

                _moveDirection *= Speed;

                if (Input.GetButton("Jump"))
                {
                    _animator.SetBool("is_in_air", true);
                    _moveDirection.y = JumpSpeed;

                }
                else
                {
                    _animator.SetBool("is_in_air", false);
                    _animator.SetBool("run", move.magnitude > 0);
                }
            }

            _moveDirection.y -= Gravity * Time.deltaTime;

            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }

    public void InteractWithItem()
    {
        if (mInteractItem != null)
        {
            mInteractItem.OnInteract();

            if (mInteractItem is InventoryItemBase)
            {
                InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
                Inventory.AddItem(inventoryItem);
                inventoryItem.OnPickup();

                if (inventoryItem.UseItemAfterPickup)
                {
                    Inventory.UseItem(inventoryItem);
                }
            }
        }

        Hud.CloseMessagePanel();

        mInteractItem = null;
    }

    private InteractableItemBase mInteractItem = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("redEnemy") && PlayerPrefs.GetInt("infight") != 1)
        {
            PlayerPrefs.SetInt("infight", 1);
            Debug.Log("nowayjskdfffffffffffffffffffffffffffffffff");
            PlayerPosition.Instance.position = transform.position;
            PlayerPosition.Instance.rotation = transform.rotation;
            SceneManager.LoadScene(fight1);
        }else if (other.gameObject.CompareTag("stoneEnemy1") && PlayerPrefs.GetInt("infight") != 1)
        {
            PlayerPrefs.SetInt("infight", 1);
            PlayerPosition.Instance.position = transform.position;
            PlayerPosition.Instance.rotation = transform.rotation;
            SceneManager.LoadScene(fight2);

        }
        else if (other.gameObject.CompareTag("stoneEnemy2") && PlayerPrefs.GetInt("infight") != 1)
        {
            PlayerPrefs.SetInt("infight", 1);
            PlayerPosition.Instance.position = transform.position;
            PlayerPosition.Instance.rotation = transform.rotation;
            SceneManager.LoadScene(fight3);


        }
        else if (other.gameObject.CompareTag("boss") && PlayerPrefs.GetInt("infight") != 1)
        {
            PlayerPrefs.SetInt("infight", 1);
            PlayerPosition.Instance.position = transform.position;
            PlayerPosition.Instance.rotation = transform.rotation;
            SceneManager.LoadScene(bossfight);

        }
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();

        if (item != null)
        {
            if (item.CanInteract(other))
            {

                mInteractItem = item;

                Hud.OpenMessagePanel(mInteractItem);
            }
        }





    }

    private void OnTriggerExit(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();
        if (item != null)
        {
            Hud.CloseMessagePanel();
            mInteractItem = null;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
//        UnityEditor.EditorApplication.isPlaying = false;
//        Debug.Log("Quit!");

    }

    public void RestartButton()
    {
        CardLibrary.Instance.cardNumber = 0;
        CardLibrary.Instance.myCards = new List<Card>();
        PlayerPrefs.SetInt("infight", 0);
        PlayerPrefs.SetInt("haveCards", 0);
        PlayerPrefs.SetInt("enemy1dead", 0);
        PlayerPrefs.SetInt("enemy2dead", 0);
        PlayerPrefs.SetInt("enemy3dead", 0);
        PlayerPrefs.SetInt("bossdead", 0);
        PlayerPrefs.SetFloat("Health", 100.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
