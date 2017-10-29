using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericUnit {

	string name;

	// Must be defined for all units
	int morale;
	int meleeAttack;
	int meleeDefense;
	int meleeAttackRange;
	int chargeBonus;
	int armor;
	int walkSpeed;
	int runSpeed;

	// For ranged units only
	int rangeAttack;
	int rangeAttackRange;
	int reloadSkill;
	int ammunitionCount;
	int accuracy;

	int[] sizes;

	//Sprite spr;

	// Store unit portrait, animations, sounds?
		
	public GenericUnit(string pName, int pMor, int pMA, int pMD, int pMAR, int pCB, int pArm, int pWS, int pRunS,
		int pRA, int pRAR, int pRelS, int pAC, int pAcc, int[] pSizes) {
		this.name = pName;
		this.morale = pMor;
		this.meleeAttack = pMA;
		this.meleeDefense = pMD;
		this.meleeAttackRange = pMAR;
		this.chargeBonus = pCB;
		this.armor = pArm;
		this.walkSpeed = pWS;
		this.runSpeed = pRunS;
		this.rangeAttack = pRA;
		this.rangeAttackRange = pRAR;
		this.reloadSkill = pRelS;
		this.ammunitionCount = pAC;
		this.accuracy = pAcc;
		this.sizes = pSizes;
	}

	// Use -1 to indicate stat is not applicable for unit.
	// Ideal for melee units.
	public GenericUnit(string pName, int pMor, int pMA, int pMD, int pMAR, int pCB, int pArm, int pWS, int pRunS, int[] pSizes) :
		this(pName, pMor, pMA, pMD, pMAR, pCB, pArm, pWS, pRunS, -1, -1, -1, -1, -1, pSizes) {
		
	}

}
