using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameMode : MonoBehaviour
{
    [SerializeField]
    private InputsManager _inputsManager;

    private async void Start()
    {
        while(GameManager.Instance == null)
        {
            await Task.Yield();
        }
        GameManager.Instance.GameMode = this;
    }

    public InputsManager InputsManager => _inputsManager;
}
