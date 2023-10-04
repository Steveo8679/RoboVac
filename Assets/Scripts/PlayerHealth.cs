using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float chargeMax = 1f;
    private float chargeCurrent;
    private bool isCharging;
    private float chargeMin = 0.0f;

    [SerializeField] Image chargeBar;
    [SerializeField] TextMeshProUGUI chargeWarning;
    // Start is called before the first frame update
    void Start()
    {
        chargeCurrent = chargeMax;
        chargeBar.fillAmount = chargeCurrent;
        InvokeRepeating("UpdateChargePercent", 1f, 1f);  //1s delay, repeat every 1s
        chargeWarning.enabled = false;
    }

    void UpdateChargePercent()
    {
        if (isCharging)
        {
            if (chargeCurrent < chargeMax)
            {
                chargeCurrent += 0.04f;
            }
        }
        else
        {
            if (chargeCurrent <= chargeMin)
            {
                Debug.Log("Dead");
            }
            else
            {
                chargeCurrent -= 0.01f;
            }
        }

        chargeBar.fillAmount = chargeCurrent;

        if (chargeCurrent <= .25)
        {
            chargeBar.color = Color.red;
            chargeWarning.text = Mathf.Round((chargeCurrent*100)).ToString() + "% Charge!";
            chargeWarning.enabled = true;
        }
        else
        {
            chargeBar.color = Color.green;
            chargeWarning.enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Dock")
        {
            isCharging = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dock")
        {
            isCharging = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        {
            if (collision.gameObject.tag == "Dock")
            {
                isCharging = false;
            }
        }
    }
}
