using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{

    public GameObject slotWorkplace;
    public GameObject slotPistol;
    public GameObject slotBottle;
    public GameObject slotAir;
    public GameObject slotDoor;
    public GameObject slotKeyhole;
    public GameObject slotCactus;
    public GameObject slotKey;
    public GameManager gameManager;
    
    public GameObject robotGood;
    public GameObject robotBad;

    // these variables save for each slot which item is in it. 0 = empty, 1 = Pistol, 2 = Bottle, 3 = Cactus, 4 = Key
    private int slotWorkplaceFilled;
    private int slotPistolFilled;
    private int slotBottleFilled;
    private int slotAirFilled;
    private int slotDoorFilled;
    private int slotCactusFilled;
    private int slotKeyFilled;
    private bool doorClosed;
    private bool gasSwitched;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {

            Debug.Log("F pressed!");

            // get items
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            GameObject key = FindObjectThroughName(items, "key_gold");
            GameObject cactus = FindObjectThroughName(items, "Cactus Pot");
            GameObject bottle = FindObjectThroughName(items, "cola2");
            GameObject pistol = FindObjectThroughName(items, "Pistol");

            Debug.Log("Key: " + key);
            Debug.Log("Cactus: " + cactus);
            Debug.Log("Bottle: " + bottle);
            Debug.Log("Pistol: " + pistol);

            // get position comparison function
            var MoveItemsScript = gameObject.GetComponent<MoveItems>();

            // get switch & door state
            doorClosed = gameObject.GetComponent<MoveItems>().doorClosed;
            gasSwitched = gameObject.GetComponent<GasSwitch>().status;

            // test which slot is filled with what:
            // slot Workplace
            if (key != null && MoveItemsScript.ComparePositions(slotWorkplace.transform.position, key.transform.position))
            {
                slotWorkplaceFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotWorkplace.transform.position, cactus.transform.position))
            {
                slotWorkplaceFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotWorkplace.transform.position, bottle.transform.position))
            {
                slotWorkplaceFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotWorkplace.transform.position, pistol.transform.position))
            {
                slotWorkplaceFilled = 1;
            }
            else
            {
                slotWorkplaceFilled = 0;
            }

            // slot Pistol
            if (key != null && MoveItemsScript.ComparePositions(slotPistol.transform.position, key.transform.position))
            {
                slotPistolFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotPistol.transform.position, cactus.transform.position))
            {
                slotPistolFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotPistol.transform.position, bottle.transform.position))
            {
                slotPistolFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotPistol.transform.position, pistol.transform.position))
            {
                slotPistolFilled = 1;
            }
            else
            {
                slotPistolFilled = 0;
            }

            // slot Bottle
            if (key != null && MoveItemsScript.ComparePositions(slotBottle.transform.position, key.transform.position))
            {
                slotBottleFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotBottle.transform.position, cactus.transform.position))
            {
                slotBottleFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotBottle.transform.position, bottle.transform.position))
            {
                slotBottleFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotBottle.transform.position, pistol.transform.position))
            {
                slotBottleFilled = 1;
            }
            else
            {
                slotBottleFilled = 0;
            }

            // slot Air
            if (key != null && MoveItemsScript.ComparePositions(slotAir.transform.position, key.transform.position))
            {
                slotAirFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotAir.transform.position, cactus.transform.position))
            {
                slotAirFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotAir.transform.position, bottle.transform.position))
            {
                slotAirFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotAir.transform.position, pistol.transform.position))
            {
                slotAirFilled = 1;
            }
            else
            {
                slotAirFilled = 0;
            }

            // slot Door
            if (key != null && MoveItemsScript.ComparePositions(slotDoor.transform.position, key.transform.position))
            {
                slotDoorFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotDoor.transform.position, cactus.transform.position))
            {
                slotDoorFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotDoor.transform.position, bottle.transform.position))
            {
                slotDoorFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotDoor.transform.position, pistol.transform.position))
            {
                slotDoorFilled = 1;
            }
            else
            {
                slotDoorFilled = 0;
            }


            // slot Cactus
            if (key != null && MoveItemsScript.ComparePositions(slotCactus.transform.position, key.transform.position))
            {
                slotCactusFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotCactus.transform.position, cactus.transform.position))
            {
                slotCactusFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotCactus.transform.position, bottle.transform.position))
            {
                slotCactusFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotCactus.transform.position, pistol.transform.position))
            {
                slotCactusFilled = 1;
            }
            else
            {
                slotCactusFilled = 0;
            }

            // slot Key
            if (key != null && MoveItemsScript.ComparePositions(slotKey.transform.position, key.transform.position))
            {
                slotKeyFilled = 4;
            }
            else if (MoveItemsScript.ComparePositions(slotKey.transform.position, cactus.transform.position))
            {
                slotKeyFilled = 3;
            }
            else if (MoveItemsScript.ComparePositions(slotKey.transform.position, bottle.transform.position))
            {
                slotKeyFilled = 2;
            }
            else if (MoveItemsScript.ComparePositions(slotKey.transform.position, pistol.transform.position))
            {
                slotKeyFilled = 1;
            }
            else
            {
                slotKeyFilled = 0;
            }

            // slots that dont have eny effect in the outcome
            Debug.Log("slotPistolFilled: " + slotPistolFilled);
            Debug.Log("slotBottleFilled: " + slotBottleFilled);
            Debug.Log("slotCactusFilled: " + slotCactusFilled);
            Debug.Log("slotKeyFilled: " + slotKeyFilled);

            // slots that do
            Debug.Log("slotWorkplaceFilled: " + slotWorkplaceFilled);
            Debug.Log("slotAirFilled: " + slotAirFilled);
            Debug.Log("slotDoorFilled: " + slotDoorFilled);

            // states
            Debug.Log("Door state: " + (doorClosed ? "closed" : "open"));
            Debug.Log("Switch state: " + (gasSwitched ? "switched" : "not switched"));

            // ACTUAL GAME CODE 3 HOURS BEFORE THE DEADLINE!
            if (!doorClosed && !gasSwitched && slotAirFilled == 0 && slotDoorFilled == 0)
            {
                robotBad.GetComponent<AnimationenAbspielen>().gasExplosion();
                Debug.Log("ERGEBNIS: Das Opfer wurde ermordet und das Haus ging hoch!");
                gameManager.endTry(ExitState.FAIL);
                StartCoroutine(Fail());

            }

            else if (!doorClosed && gasSwitched && slotAirFilled == 0 && slotDoorFilled == 0)
            {
                robotBad.GetComponent<AnimationenAbspielen>().gasExplosion();
                Debug.Log("ERGEBNIS: Das Opfer wurde ermordet aber das Haus ging nicht hoch!");
                gameManager.endTry(ExitState.FAIL);
                StartCoroutine(Fail());
            }

            else if (!doorClosed && slotDoorFilled != 0 && slotDoorFilled != 3)
            {
                robotGood.GetComponent<Abspielen2>().abhauen();
                robotBad.GetComponent<AnimationenAbspielen>().abhauen();
                Debug.Log("ERGEBNIS: Der Mörder bekam einen Gegenstand ins Gesicht und floh!");
                gameManager.endTry(ExitState.SCARE);
                StartCoroutine(Mediocre());
            }

            else if (!doorClosed && slotDoorFilled == 3)
            {
                robotGood.GetComponent<Abspielen2>().wehtun();
                robotBad.GetComponent<AnimationenAbspielen>().wehtun();
                Debug.Log("ERGEBNIS: Der Mörder bekam einen Kaktus ins Gesicht und konnte überwältigt werden!");
                gameManager.endTry(ExitState.DISABLE);
                StartCoroutine(Success());
            }

            else if (!doorClosed && slotWorkplaceFilled != 1 && slotDoorFilled == 0)
            {
                Debug.Log("ERGEBNIS: Das Opfer hat den Mörder bemerkt und sie haben sich gegenseintig umgebracht!");
                gameManager.endTry(ExitState.FAIL);
                StartCoroutine(Fail());
                // person wird gewarnt, personen erstechen sich gegeseitig
                // TODO: sound
            }

            else if (!doorClosed && slotWorkplaceFilled == 1 && slotDoorFilled == 0)
            {
                robotGood.GetComponent<Abspielen2>().erschiessen();
                robotBad.GetComponent<AnimationenAbspielen>().schiessen();
                Debug.Log("ERGEBNIS: Das Opfer hat den Mörder bemerkt und hat ihn erschossen!");
                gameManager.endTry(ExitState.KILL);
                StartCoroutine(Mediocre());
                // person wird gewarnt, erschießt mörder
                // TODO: sound & pistole bewegen
            }

            else if (doorClosed)
            {
                Debug.Log("ERGEBNIS: Die Tür war abgeschlossen und der Mörder kam nicht herein!");
                gameManager.endTry(ExitState.DOOR);
                StartCoroutine(Mediocre());
                robotBad.GetComponent<AnimationenAbspielen>().nichtReinkommen();
                // person kommt nicht rein (tür wird bei schlüsselanimation zugemacht) (Fluransicht)
            }
            
            else
            {
                Debug.Log("Nice, du hast das Game gefreezet!");
            }
            
            // get item in air
            GameObject airItem = null;
            switch (slotAirFilled)
            {
                case 1:
                    airItem = pistol;
                    break;
                case 2:
                    airItem = bottle;
                    break;
                case 3:
                    airItem = cactus;
                    break;
                case 4:
                    airItem = key;
                    break;
            }
            
            // get item over door
            GameObject doorItem = null;
            switch (slotDoorFilled)
            {
                case 1:
                    doorItem = pistol;
                    break;
                case 2:
                    doorItem = bottle;
                    break;
                case 3:
                    doorItem = cactus;
                    break;
                case 4:
                    doorItem = key;
                    break;
            }

            Debug.Log("Air Item: " + airItem);
            if (airItem != null)
            {
                // TODO: airItem runterfallen lassen
                Debug.Log(airItem + "fiel runter");
                Rigidbody rigidbody = airItem.AddComponent<Rigidbody>();
            }
            
            Debug.Log("Door Item: " + doorItem);
            if (doorItem != null)
            {
                // TODO: doorItem runterfallen lassen
                Debug.Log(doorItem + "fiel auf den Mörder");
                Rigidbody rigidbody = doorItem.AddComponent<Rigidbody>();
            }

        }
    }

    private GameObject FindObjectThroughName(GameObject[] items, String name)
    {
        foreach (GameObject item in items)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }

    private IEnumerator Success() {
        yield return new WaitForSeconds(5);
        gameManager.showSuccessfulEndscreen();
    }

    IEnumerator Fail() {
        yield return new WaitForSeconds(5);
        gameManager.showBadEndscrene();
    }
    IEnumerator Mediocre() {
        yield return new WaitForSeconds(5);
        gameManager.showMediocreEndscrenn();
    }


}
