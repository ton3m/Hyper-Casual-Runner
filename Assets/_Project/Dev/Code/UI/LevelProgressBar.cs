using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaMaker.Code.UI
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TMP_Text _levelText;
    
        public void SetLevelText(int level)
        {
            _levelText.text = level.ToString();
        }

        public void UpdateProgress(float value)
        {
            _progressSlider.value = value;
        }
    }
}