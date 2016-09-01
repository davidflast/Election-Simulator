using System;

namespace scripts
{
	public static class IdentityGenerator
	{	
		//generates ethnicity
		public static string generateEthnicity (Random r)
		{
			string ethnicity;
			int e = r.Next (1,100);
			if (e <= 17) {
				ethnicity = "black";
			} else if (e <= 42) {
				ethnicity = "hispanic";
			} else {
				ethnicity = "white";
			}
			return ethnicity;
	
		}
		//generates party
		public static string generateParty (Random r, string e)
		{
			string party;
			int p = r.Next (1, 100);
			if (e == "black") {
				if (p <= 82) {
					party = "dem";
				} else if(p <= 86){
					party = "rep";
				} else {
					party = "ind";
				}
			} else if (e == "hispanic") {
				if (p <= 39) {
					party = "dem";
				} else if(p <= 69){
					party = "rep";
				} else {
					party = "ind";
				}
			} else {
				if (p <= 33) {
					party = "dem";
				} else if(p <= 77){
					party = "rep";
				} else {
					party = "ind";
				}
			}
			return party;
		}

	}
}

