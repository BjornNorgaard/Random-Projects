#pragma once
#include <iostream>
using namespace std;

class DiceThings
{
public:
	DiceThings(int diceNumber, int alikeNumber) {
		// do stuff

		// start Run method
		Run();
	}

	void Run() {
		cout << "Hello from Run()." << endl;
	}

	void IncrementArray(int* ArrayPointer) {

	}

private:
	int _numberOfDice;
	int _possibleCombinations;
	int _numberOfThisManyAlike;
};