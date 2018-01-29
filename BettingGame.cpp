
 #include "stdafx.h"
#include "cstdlib"
#include <iostream>
#include <ctime>
#include <string>
#define sizeOfMatrix 20
#define sizeOfCol 2

using namespace std;

int main(int argc, char * argv[]) {
	int a[sizeOfMatrix][sizeOfCol] = {0};
	int guess, number, money, bet, bank;
	bank = 0;
	string surname[20];
	string name[20];
	char answer;
	
	a[0][0] = 20; a[0][1] = 300; name[0] = "Alex"; surname[0] = "Fininis"; /// Predefined players for quicker game!
	a[1][0] = 19; a[1][1] = 200; name[1] = "Peter"; surname[1] = "Griffin";
	a[2][0] = 18; a[2][1] = 400; name[2] = "Steve"; surname[2] = "Smith";
	a[3][0] = 17; a[3][1] = 150; name[3] = "Homer"; surname[3] = "Simpson";


	int s;
	cout << "======================================================================\n";
	cout << "                            GAME MENU                                  " << "\n";
	cout << "======================================================================\n";

	cout << "     1.Incert a player" << "\n";
	cout << "     2.See players information" << "\n";
	cout << "     3.Start the game" << "\n";
	cout << "     4.See results" << "\n";
	cout << "     5.See the balance of the bank" << "\n";
	cout << "     6.Exit the game" << "\n";

	do {
		cout << "Select an option(1-6): ";
		cin >> s;
		cout << endl;
		switch (s) {
		case 1: 	cout << "  Selected:   1.Incert a player" << "\n";
		{
			int i;
			bool trueId = false;
			cout << "Enter a new players number (1-20):";
			cin >> number;
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			for (i = 0; i < sizeOfMatrix; i++) {
				if (a[i][0] == number) {
					trueId = false;
				}
				else {
					trueId = true;
				}
			}
			for (i = 0; i<sizeOfMatrix; i++) {
				if (a[i][0] == 0) {
					if ((number >= 1) && (number <= 20)) {
						a[i][0] = number;
					}
					else {
						trueId = false; break;
					}
					cout << "Enter players name:"; cin >> name[i];
					

					cout << endl;
					cout << "Enter players surname:"; cin >> surname[i];
					
					cout << endl;
					cout << "Enter players money deposit:"; cin >> money;
					if ((money >= 0) && (money <= 10000)) {
						a[i][1] = money;
					}
					else {
						a[i][0] = 0;
						trueId = false; break;
					}
					
					cout << endl;
					cout << "The new player was added successfully! \n";
					for (i = 0; i<sizeOfMatrix; i++) {
						if ((a[i][0] == number) && (a[i][0] != 0)) {
							trueId = true;
							cout << "===========================================================\n";
							cout << "Player ID       Name   &   Surname      Money Deposit  \n";
							cout << "===========================================================\n";

							for (int j = 0; j<1; j++)cout << a[i][0] << "\t\t" << name[i] << "\t" << surname[i] << "\t\t" <<  a[i][1] << "\t\t\n";
						}


					}
					break;
				}
			}

			if (trueId == false) cout << "Wrong value!  \n";
			cout << endl;
		}
			break;
		case 2: 	cout << "  Selected:   2.See players information" << "\n";
		{
			cout << "===========================================================\n";
			cout << "Player ID       Name   &   Surname      Money Deposit  \n";
			cout << "===========================================================\n";

			for (int i = 0; i < sizeOfMatrix; i++) {
				if (a[i][0] != 0) {
					for (int j = 0; j<1; j++)cout << a[i][0] << "\t\t" << name[i] << "\t" << surname[i] << "\t\t" << a[i][1] << "\t\t";
					cout << endl;
				}
			}
		}
			break;
		case 3: 	cout << "  Selected:   3.Start the game" << "\n";
		{
			
			int random, id;
			do {
				
				for (int i = 0; i < sizeOfMatrix; i++) {
					if (a[i][0] != 0) {
						bool trueId = false;
						cout << "Enter a players ID:";
						cin >> id;
						for (int j = 0; j<sizeOfMatrix; j++) {
							if (a[j][0] == id) {
								trueId = true;
								if (a[j][1] == 0)
								{
									cout << "The player is out of money! \n ";
									break;
								}
								do	{
									cout << "The player with surname " << surname[j] << " have to enter money to bet : ";
									cin >> bet;
									cin.clear();
									cin.ignore(numeric_limits<streamsize>::max(), '\n');
									if (bet > a[j][1]) {
									cout << "The money of the bet must be less or equal to the players balance. " << endl;
									cout << "Please enter again a correct betting amount\n" << endl;
									}
								} while (bet > a[j][1]);
								
							do {
								cout << "Guess a number to bet between 1 to 10 :";
								cin >> guess;
								if (guess <= 0 || guess > 10)
									cout << "Invalid number!! the guess have to be from 1 to 10, try again!\n ";
							} while (guess <= 0 || guess > 10);

							srand(time(0));
							random = rand() % 10 + 1;

							if (random == guess)
							{
								cout << "\nThe player won! The winning amount is : " << bet * 10;
								a[j][1] = a[j][1] + bet * 10;
								bank = bank - bet * 10;
							}
							else
							{
								cout << "The player lost! The lost amount is:  " << bet << endl;
								a[j][1] = a[j][1] - bet;
								bank = bank + bet;
							}
							cout << "\nThe number that won is : " << random << endl;
							cout << name[j] << "'s money balance is:  " << a[j][1] << endl;
							if (a[j][1] == 0)
							{
								cout << "The player is out of money! \n ";
								break;
							}
							cout << endl;

							}
						}
						if (trueId == false) cout << "Invalid ID!  \n"; break;
					}
				}
				cout << "\n\nDo you want to continue playing? answer with 'y' for yes or 'n' for no? ";
				cin >> answer;
			} while (answer == 'Y' || answer == 'y');
			


		} break;
			
		case 4: 	cout << "  Selected:   4.See results" << "\n";{
			int hold1,hold2;
			string hold3[20];
			string hold4[20];
			for (int i = 0; i < sizeOfMatrix - 1; i++)
			{
				for ( int j = i + 1; j < sizeOfMatrix; j++)					
				{
					if (a[i][1] > a[j][1]) 
					{
						hold1 = a[i][1];
						hold2 = a[i][0];
						a[i][1] = a[j][1];
						a[i][0] = a[j][0];
						a[j][1] = hold1;
						a[j][0] = hold2;
						hold3[i] = name[i];
						hold4[i] = surname[i];
						name[i] = name[j];
						surname[i] = surname[j];
						name[j] = hold3[i];
						surname[j] = hold4[i];
					}
				}
			}


			cout << "\n The 3 players with the most money, after descending sorting are: \n";
			for (int j = 19; j >= 17; j--){
				if (a[j][0] != 0) {
					cout << "$ "<< a[j][1] << " , with surname: " << surname[j] << endl;
				}
			}

			int high, idH;
			string hold5;
			hold5 = "a";
			high = a[0][0];
			idH = a[0][0];
			for (int i = 0; i < sizeOfMatrix; i++) {
				if (high < a[i][1]) {
					high = a[i][1];
					idH = a[i][0];
					hold5 = surname[i];
				}
			}
			cout << "The winner of the game is: " << hold5 << " with ID: " << idH << " and $ " << high << endl;
		}
			break;
		case 5: 	cout << "  Selected:   5.See the balance of the bank" << "\n";
			cout << "The balance of the Bank is:$ " << bank << endl;
			break;
		case 6:   cout << " Selected: 6.Exit the game: \n" << "Hope you liked it! \n"; break;
		default:cout << "Invalid selection \n";
		}
	} while (s != 6);


	system("pause");
	return EXIT_SUCCESS;
}

