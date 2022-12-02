using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Он будет разделять логику
public class GameController : MonoBehaviour
{
    [SerializeField]
    private StoneSpawner m_spawner;
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) // Инпут - статический класс
        {
//                System.Object obj;
//                UnityEngine.Object unityobj = transform; //this, gameobject

                Debug.Log("X was pressed");
                if(m_spawner != null) // Лучше всегда проверять
                {
                    m_spawner.Spawn();
                }
                else
                {
                    Debug.LogError("Спавнер равен нулю"); // Приложение уже не упадет
                }
//                m_spawner?.Spawn(); Лучше не делать так,ибо происходит переопределение операторов, на деле компилятор может подумать, что тут еще не нулн

        }
    }
}
