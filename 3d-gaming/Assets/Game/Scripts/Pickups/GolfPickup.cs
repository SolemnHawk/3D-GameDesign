	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class GolfPickup : MonoBehaviour {

		public GameObject hinttext;
		public GameObject boosttext1;
		public GameObject boosttext2;
		public GameObject boosttext3;

		//Golf powers: 1 Power, 2 Trail, 3 stop button, 4 ??

		void OnTriggerEnter(Collider other){

			System.Random r = new System.Random ();
			int powerboost=r.Next(1,4);
			if (other.tag == "Player") {
			
				hinttext.SetActive (false);
			if (powerboost == 1)
					boosttext1.SetActive(true);
				else if (powerboost == 2)
					boosttext2.SetActive (true);
				else if (powerboost == 3)
					boosttext3.SetActive (true);
			}
			}

		}