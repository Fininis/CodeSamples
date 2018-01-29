
#include "stdafx.h"
#include<iostream>
#include<fstream>
#define sizeOfMatrix 20
#define sizeOfCol 5

using namespace std;

int main(int argc, char *argv[]) {
	int a[sizeOfMatrix][sizeOfCol];
	
	for (int i = 0; i < sizeOfMatrix; i++) {

		for (int j = 0; j < sizeOfCol; j++)  a[i][j] = { NULL };
	}

	a[0][0] = 1001; a[0][1] = 20; a[0][2] = 30; a[0][3] = 40; a[0][4] = 50;
	a[1][0] = 1002; a[1][1] = 25; a[1][2] = 35; a[1][3] = 44; a[1][4] = 55;
	a[2][0] = 1003; a[2][1] = 22; a[2][2] = 33; a[2][3] = 45; a[2][4] = 74;
	a[3][0] = 1004; a[3][1] = 19; a[3][2] = 49; a[3][3] = 59; a[3][4] = 67;

	int s;
	cout << "======================================================================\n";
	cout << "                                MENU                                  " << "\n";
	cout << "======================================================================\n";

	cout << "     1.View all students' records" << "\n";
	cout << "     2.View a student's records by ID" << "\n";
	cout << "     3.Show the highest and the lowest final scores and the students ID" << "\n";
	cout << "     4.Delete a student's record by ID" << "\n";
	cout << "     5.Input a new students records" << "\n";
	cout << "     6.Exit" << "\n";

	do {
		cout << "Select an option(1-6): ";
		cin >> s;
		cout << endl;
		switch (s) {
		case 1: cout << "View all students records : \n"; {
			cout << "======================================================================\n";
			cout << "StudentID      Quiz1          Quiz2          Mid-term         Final\n";
			cout << "======================================================================\n";

			for (int i = 0; i < sizeOfMatrix; i++) {
				if (a[i][0] != 0) {
				for (int j = 0; j < 5; j++) cout << a[i][j] << "\t\t";
				cout << endl;
				}
			}
		}
				break;

		case 2: cout << "View a students records by ID : \n"; {
			int id, i, j;
			bool trueId = false;
			cout << "Enter a student's ID:";
			cin >> id;

			for (i = 0; i<sizeOfMatrix; i++) {
				if ((a[i][0] == id) && (a[i][0] != 0)) {
					trueId = true;
					cout << "======================================================================\n";
					cout << "StudentID      Quiz1          Quiz2          Mid-term         Final\n";
					cout << "======================================================================\n";

					for (j = 0; j<5; j++)cout << a[i][j] << "\t\t";
				}

				
			}
			if (trueId == false) cout << "Invalid ID!  \n";
		} cout << endl;
				break;
		case 3: cout << "The highest and the lowest final scores and the students ID : \n"; {
			int high, low, idH, idL;

			high = low = a[0][4];
			idH = a[0][0];
			for (int i = 0; i < sizeOfMatrix; i++) {
				if (high < a[i][4]) {
					high = a[i][4];
					idH = a[i][0];
				}
			}


			idL = a[0][0];
			for (int i = 0; i < sizeOfMatrix; i++) {
				if (a[i][4] > 0) {
					if (low > a[i][4]) {
						low = a[i][4];
						idL = a[i][0];
					}
				}
			}

			cout << "The Highest score is: " << high << " from the student with ID: " << idH << endl;
			cout << "The Lowest score is: " << low << " from the student with ID: " << idL << endl;

		}
				break;
		case 4: cout << "Delete a students record by ID  : \n"; {
			int id, i, j;
			bool trueId = false;
			cout << "Enter a student's ID:";
			cin >> id;

			for (i = 0; i<sizeOfMatrix; i++) {
				if (a[i][0] == id) {
					trueId = true;
					a[i][0] = 0;
					a[i][1] = 0;
					a[i][2] = 0;
					a[i][3] = 0;
					a[i][4] = 0;
					
				}
				
			}
			if (trueId == false) cout << "Invalid ID!  \n";
		} cout << endl;
				break;
		case 5: cout << "Input a new students records : \n"; {
			int id, i, j, qz1, qz2, mt, fs;
			bool trueId = false;
			cout << "Enter a new student's ID (1000-1020):";
			cin >> id;

					if (a[i][0] == id) {
					trueId = false;
					}
					else {
						trueId = true;
					}
				for (i = 0; i<sizeOfMatrix; i++) {
					if (a[i][0] == 0) {
						if ((id > 1000) && (id <= 1020)) {
							a[i][0] = id;
						}
						else {
							trueId = false; break;
						}
						cout << "Enter student's quizz1 score(0-100):"; cin >> qz1;
						if ((qz1 >= 0) && (qz1 <= 100)) {
							a[i][1] = qz1;
						}
						else {
							a[i][0] = 0;
							trueId = false; break;
						}

						cout << endl;
						cout << "Enter student's quizz2 score(0-100):"; cin >> qz2;
						if ((qz2 >= 0) && (qz2 <= 100)) {
							a[i][2] = qz2;
						}
						else {
							a[i][0] = 0;
							trueId = false; break;
						}
						cout << endl;
						cout << "Enter student's mid term score(0-100):"; cin >> mt;
						if ((mt >= 0) && (mt <= 100)) {
							a[i][3] = mt;
						}
						else {
							a[i][0] = 0;
							trueId = false; break;
						}
						cout << endl;
						cout << "Enter student's final score(0-100):"; cin >> fs;
						if ((fs >= 0) && (fs <= 100)) {
							a[i][4] = fs;
						}
						else {
							a[i][0] = 0;
							trueId = false; break;
						}
						cout << endl;
						cout << "The new student was added successfully! \n";
						for (i = 0; i<sizeOfMatrix; i++) {
							if ((a[i][0] == id) && (a[i][0] != 0)) {
								trueId = true;
								cout << "======================================================================\n";
								cout << "StudentID      Quiz1          Quiz2          Mid-term         Final\n";
								cout << "======================================================================\n";

								for (j = 0; j<5; j++)cout << a[i][j] << "\t\t";
							}

							
						}
						break;
					}
				}

			if (trueId == false) cout << "Wrong value!  \n";
			cout << endl;
		}
				break;
		case 6: cout << "Exit : \n"; break;
		default:cout << "Invalid selection \n";
		}
	} while (s != 6);


	system("pause");
	return EXIT_SUCCESS;
}