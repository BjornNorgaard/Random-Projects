#include <iostream>
using namespace std;

int main()
{
	double a = 0, b = 0, c = 0, d = 0, x1 = 0, x2 = 0;

	cout << "Dette program kan lose en andengradsligning på folgende form: ax^2 + bx + c = 0" << endl
		<< "Indtast venligst koefficienterne:" << endl;

	cout << "A: ";	cin >> a;
	cout << "B: ";	cin >> b;
	cout << "C: ";	cin >> c;

	d = (b*b) - (4 * a*c);

	cout << endl << "Diskrimminanten er: " << d << endl;

	if (d > 0)
	{
		cout << "\nD er positiv, ligningen har 2 rodder." << endl;

		x1 = (-b + sqrt(d)) / (2 * a);
		x2 = (-b - sqrt(d)) / (2 * a);

		cout << "Rod 1 er i: " << x1 << endl
			<< "Rod 2 er i: " << x2 << endl;
	}
	else if (d == 0)
	{
		cout << "D er 0, ligningen har 1 rod." << endl;

		x1 = (-b + sqrt(d)) / (2 * a);

		cout << "Roden er i: " << x1 << endl;
	}
	else if (d < 0)
	{
		cout << "D er negaiv, ligningen har ingen losninger." << endl;
	}
	printf("\n");
}