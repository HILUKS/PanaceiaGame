using UnityEngine;
using UnityEngine.UI;
    public class CanvasUIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private GameObject keyImage;
        [SerializeField] private Text coinText;
        private HistoryManager _historyManager;
        private void Awake()
        {
            _historyManager = FindObjectOfType<HistoryManager>();
        }
        private void Update()
        {
            CoinTextUpdate();
            ChekKey();
        }
        public void CoinTextUpdate()
        {
            coinText.text = "" + _historyManager.coin;
        }
        public void ChekKey()
        {
            if (_historyManager.keyEnabled)
            {
                keyImage.SetActive(true);
            }
        }
    }