using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace scripts
{
	public class Population : MonoBehaviour {
		Person [] pop;
		private int demSupport;
		private int repSupport;
		private int undecided;
		public int popSize;
		public Text demPoll;
		public Text repPoll;
		public Text undPoll;

		// Use this for initialization
		void Start () {
			popSize = 10000;
			pop = new Person[popSize];
			for (int i = 0; i < popSize; ++i) {
				pop [i] = new Person ();
			}

		}

		public void runEthnicAd(int [] ethinicChance, string topic, string party, int position, int import, int careChange){
			for (int i = 0; i < popSize; i++) {
				Person p = pop [i];
				if (p.ethnicity == "black") {
					if (Random.Range (1, 100) > ethinicChance [0]) {
						p.ad(topic, party, position, import, careChange);
					}
				} else if (p.ethnicity == "hispanic") {
					if (Random.Range (1, 100) > ethinicChance [1]) {
						p.ad(topic, party, position, import, careChange);
					}
				} else {
					if (Random.Range (1, 100) > ethinicChance [2]) {
						p.ad(topic, party, position, import, careChange);
					}
				}
			}
		}
		public void runPartyAd(int [] partyChance, string topic, string party, int position, int import, int careChange){
			for (int i = 0; i < popSize; i++) {
				Person p = pop [i];
				if (p.party == "democrat") {
					if (Random.Range (1, 100) >partyChance [0]) {
						p.ad(topic, party, position, import, careChange);
					}
				} else if (p.ethnicity == "republican") {
					if (Random.Range (1, 100) > partyChance [1]) {
						p.ad(topic, party, position, import, careChange);
					}
				} else {
					if (Random.Range (1, 100) > partyChance [2]) {
						p.ad(topic, party, position, import, careChange);
					}
				}
			}
		}

		public void poll (){
			demSupport = 0;
			repSupport = 0;
			undecided = 0;
			for (int i = 0; i < popSize; i++) {
				string vote = pop [i].pollPerson ();
				if (vote == "democrat") {
					demSupport++;
				} else if (vote == "republican") {
					repSupport++;
				} else {
					undecided++;
				}
			}
			demPoll.text = "Democrats: " + demSupport;
			repPoll.text = "Republicans: " + repSupport;
			undPoll.text = "Undecided: " + undecided;
		}
			
		// Update is called once per frame
		void Update () {
		
		}
	}
}

