using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator _animator;
    private const string CUT = "Cut";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCutPerformed += CuttingCounter_OnCutPerformed;
    }

    private void CuttingCounter_OnCutPerformed(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(CUT);
    }
}
