using System.Collections.Generic;
using UnityEngine;
using State;
using TMPro;
using System.Collections;

namespace Score
{
    public class ScoreCalkulateByTruks : MonoBehaviour
    {
        [SerializeField] private StateMashin stateMashin;
        [SerializeField] private TextMeshProUGUI textScore;

        private Dictionary<string, int> scoreForTruks = new Dictionary<string, int>
        {
            {"plaerRotashionLocalX", 3},
            {"plaerRotashionLocalY", 4},
            {"SolevoiTrucs", 3},
            {"RotashionDoynHeadTruk", 10}
        };

        private string nameTrukDo;
        private float timerDoTruks;
        private bool startTimertruks;
        public int allScore { get; private set; }
        private float score;
        void Start()
        {
            stateMashin.svitchStateMove += StopTimer;
            stateMashin.svitchStateDaed += StopTimerBecasuDaed;
        }

        void FixedUpdate()
        {
            if (startTimertruks)
            {
                timerDoTruks += Time.deltaTime;
                if (timerDoTruks > 0.5f)
                {
                    if(!textScore.enabled)
                        textScore.enabled= true;
                    score = timerDoTruks * scoreForTruks[nameTrukDo];
                    textScore.text = ((int)score).ToString();
                }
            }
        }

        public void StartTimer(string nameTrukDo)
        {
            startTimertruks = true;
            timerDoTruks = 0;
            this.nameTrukDo = nameTrukDo;
        }

        public void StopTimer()
        {
            startTimertruks = false;
            StartCoroutine(TimerBefoDisableTextScore());
            if (textScore.enabled)
            {
                allScore += (int)score;
            }
        }

        private void StopTimerBecasuDaed()
        {
            startTimertruks = false;
            textScore.enabled = false;
        }

        private IEnumerator TimerBefoDisableTextScore()
        {
            yield return new WaitForSeconds(1f);

            textScore.enabled = false;
        }
    }
}