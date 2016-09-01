using System;
using System.Collections.Generic;

namespace scripts
{
	public class Person
	{
		//Fields
		//Identity Fields
		public string ethnicity;
		public string party;
		// Opinion position and importance
		// imm = immigration
		// abort = abortion
		public int imm;
		public int immImport;
		public int trade;
		public int tradeImport;
		// Perception of Democrat Candidate
		public List<int> immD;
		public int immDImport;
		public List<int> tradeD;
		public int tradeDImport;
		//Perception of Republican Candidate
		public List<int> immR;
		public int immRImport;
		public List<int> tradeR;
		public int tradeRImport;
		// Personality Desire
		public int care;
		public int careD;
		public int careR;
		// scores
		public int politicsImport;
		public int scoreD;
		public int scoreR;
		public string vote;
		Random random;


		public Person ()
		{	
			random = new Random ();
			ethnicity = IdentityGenerator.generateEthnicity (random);
			party = IdentityGenerator.generateParty (random, ethnicity);
			imm = OpinionGenerator.generateImm (random, party, ethnicity);
			trade = OpinionGenerator.generateTrade (random, party, ethnicity);
			tradeImport = MathHelper.sampleNormalOne (random);
			immImport = MathHelper.sampleNormalOne (random);
			politicsImport = MathHelper.sampleNormalOne (random);
			care = MathHelper.sampleNormalOne (random);
			immD = new List<int>();
			immDImport = 0;
			tradeD = new List<int>();
			tradeDImport = 0;
			immR = new List<int>();
			immRImport = 0;
			tradeR = new List<int>();
			tradeRImport = 0;
			careD = 0;
			careR = 0;
			scoreD = 0;
			scoreR = 0;	
		}

		public void ad (string topic, string party, int position, int import, int careChange)
		{
			switch (topic) {
			case "imm": 
				if (party == "democrat") {
					immD.Add (position);
					immDImport = immDImport + import;
					careD = careD + careChange;
				} else {
					immR.Add (position);
					immRImport = immRImport + import;
					careR = careR + careChange;
				}
				break;
			case "trade":
				if (party == "democrat") {
					tradeD.Add (position);
					tradeDImport = tradeDImport + import;
					careD = careD + careChange;
				} else {
					tradeR.Add (position);
					tradeRImport = tradeRImport + import;
					careD = careD + careChange;
				}
				break;
			}
		}

		public void decide(){
			int immDScore = (100 - 2 * Math.Abs(imm - MathHelper.averageList(immD))) * immImport;
			int tradeDScore = (100 - 2 * Math.Abs(trade - MathHelper.averageList(tradeD))) * tradeImport;
			int immRScore = (100 - 2 * Math.Abs(imm - MathHelper.averageList(immR))) * immImport;
			int tradeRScore = (100 - 2 * Math.Abs(trade - MathHelper.averageList(tradeR))) * tradeImport;
			scoreD = immDScore + tradeDScore;
			scoreR = immRScore + tradeRScore;
			if (scoreD > scoreR + 20 ) {
				vote = "democrat";
			} else if (scoreR > scoreD + 20){
				vote = "republican";
			} else {
				vote = "undecided";
			}
		}

		public string pollPerson(){
			return vote;
		}

	}
}

