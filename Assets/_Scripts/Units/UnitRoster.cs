using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRoster {

	ArrayList<GenericUnit> roster;

	public UnitRoster() {
		roster = new ArrayList<GenericUnit> ();
		roster.add(new GenericUnit("SampleLightMeleeUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
		roster.add(new GenericUnit("SampleMediumMeleeUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
		roster.add(new GenericUnit("SampleHeavyMeleeUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
		roster.add(new GenericUnit("SampleLightMissileUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
		roster.add(new GenericUnit("SampleMediumMissileUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
		roster.add(new GenericUnit("SampleHeavyMissileUnit", 1, 1, 1, 1, 1, 1, 1, 1, new int[] { 80,120,160 } ));
	}

	// =======================================
	// For modifying roster in-game
	// =======================================

	/**
	 * Adds new unit to roster
	 */
	public void AddUnit(GenericUnit gu) {
		roster.add (gu);
	}

	public void AddUnit(string pName, int pMor, int pMA, int pMD, int pMAR, int pCB, int pArm, int pWS, int pRunS,
		int pRA, int pRAR, int pRelS, int pAC, int pAcc, int[] pSizes) {
		roster.add (new GenericUnit(pName, pMor, pMA, pMD, pMAR, pCB, pArm, pWS, pRunS,
			pRA, pRAR, pRelS, pAC, pAcc, pSizes));
	}

	public void AddUnit(string pName, int pMor, int pMA, int pMD, int pMAR, int pCB, int pArm, int pWS, int pRunS, int[] pSizes) {
		roster.add (new GenericUnit(pName, pMor, pMA, pMD, pMAR, pCB, pArm, pWS, pRunS, pSizes));
	}

	/**
	 * Updates existing unit in roster
	 */
	public void UpdateUnit() {

	}

	/**
	 * Removes existing unit from roster
	 */
	public void RemoveUnit() {

	}



}
