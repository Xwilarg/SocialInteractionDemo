using UnityEngine;
using UnityEngine.UI;

public class GodController : MonoBehaviour
{
    private int _currentSlot = 0;

    [SerializeField]
    private Image _spell1, _spell2, _spell3, _spell4;

    [SerializeField]
    private GameObject _slowZone;

    private void RemoveAllSpells()
    {
        _spell1.color = Color.white;
        _spell2.color = Color.white;
        _spell3.color = Color.white;
        _spell4.color = Color.white;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveAllSpells();
            _currentSlot = 1;
            _spell1.color = Color.grey;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveAllSpells();
            _currentSlot = 2;
            _spell2.color = Color.grey;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveAllSpells();
            _currentSlot = 3;
            _spell3.color = Color.grey;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RemoveAllSpells();
            _currentSlot = 4;
            _spell4.color = Color.grey;
        }

        if (Input.GetMouseButtonDown(0) && _currentSlot != 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0f;
            var pos = Camera.main.ScreenToWorldPoint(mousePos);

            //Destroy(Instantiate(_slowZone, pos, Quaternion.identity), 10f);
        }
    }
}
