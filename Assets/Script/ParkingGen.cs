using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingGen : MonoBehaviour
{
    
    [SerializeField] GameObject[] _carTab;
    [SerializeField] int[] _carNum;

    private void right(int i) {
        /* gauche haut */
        int r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        GameObject chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(-10.5f, 18.3f - 2.1f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
        /* gauche bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(-10.5f, 1.5f - 2.1f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
    }

    private void firstCol(int i) {
        /* rangee 2 haut */
        int r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        GameObject chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(19f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2 bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(19f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2bis haut */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(22.5f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
        /* rangee 2bis bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(22.5f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
    }

    private void secondCol(int i) {
        /* rangee 2 haut */
        int r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        GameObject chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(1.74f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2 bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(1.74f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2bis haut */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(5.55f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
        /* rangee 2bis bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(5.55f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
    }

    private void thirdCol(int i) {
        /* rangee 2 haut */
        int r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        GameObject chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(35f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2 bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(35f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* rangee 2bis haut */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(39f, 18.76f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
        /* rangee 2bis bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(39f, 2.29f - 2.3f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, -90);
        }
    }

    private void left(int i) {
        /* droite haut */
        int r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        GameObject chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(50f, 18.3f - 2.1f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
        /* droite bas */
        r = Random.Range(0,7);
        while (_carNum[r] <= 0)
            r = Random.Range(0,7);
        _carNum[r]--;
        chosenCar = _carTab[r];
        if (chosenCar) {
            GameObject tmpCar = Instantiate(chosenCar, new Vector3(50f, 1.5f - 2.1f*i, 0), Quaternion.identity);
            tmpCar.transform.Rotate(0, 0, 90);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            right(i);
            firstCol(i);
            secondCol(i);
            thirdCol(i);
            left(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
