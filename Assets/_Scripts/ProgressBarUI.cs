using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private CuttingCounter parentCuttingCounter;
    // Start is called before the first frame update
    void Start()
    {
        parentCuttingCounter.OnProgressChanged += ParentCuttingCounter_OnProgressChanged;
        progressBar.fillAmount = 0f;
        Hide();
    }

    private void ParentCuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        progressBar.fillAmount = e.progressNormalized;

        if(e.progressNormalized == 0f || e.progressNormalized == 1f) 
        { 
            Hide();
        }
        else
        {
            Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
