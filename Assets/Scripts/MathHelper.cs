using System;
using System.Collections.Generic;

namespace scripts
{
	public static class MathHelper
	{
		// Generate a number (0.0, 1.0) from the normal distribution
		public static double sampleNormal (Random random, double mean, double stddev)
		{
			double r1 = 1 - random.NextDouble ();
			double r2 = 1 - random.NextDouble ();

			double std = Math.Sqrt (-2.0 * Math.Log (r1)) * Math.Cos (2.0 * Math.PI * r2);

			return mean + stddev * std;
		}

		public static int sampleNormalOne (Random r)
		{
			double sample = sampleNormal (r, 50, 25);
				if (sample > 100) {
					sample = 100;
				} else if (sample < 0) {
					sample = 0;
				} 
			return (int) sample;
				
		}


		public static int cumulativeProbability (Random random , int[] probability){
			int [] mean = {25, 50, 75};
			int r = random.Next (1, 100);
			int count = 0;
			foreach (int num in probability) {
				if (r <= num) {
					return (int) sampleNormal (random, mean [count],12);
				} 
				count = count + 1;
			}
			return 50;
		}

		public static int averageList (List<int> list){
			int total = 0;
			foreach (int item in list) {
				total = total + item;
			}
			return total / list.Count;
		}
	}
}

