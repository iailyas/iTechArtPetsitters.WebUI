#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <math.h>
#include <time.h>
#include <mpi.h>
#include <fstream>
#include <time.h>
#include <list>
#include <algorithm>
#include <omp.h>
using namespace std;
// var3
//const variables
const int N = 9;
const int M = 9;
int matr[N][M];
int numbers[N];
double a, b, c, d;
unsigned int n, m;
unsigned int K;


//thread MPI function (Multi)
int Calc(int i)
{
	for (i = 0; i < N; i++)
	{
		numbers[i] = 0;

	}

	for (i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j += 2)
		{
			numbers[i] += matr[j][i];
		}
	}
	int max = numbers[0];
	for ( i = 0; i < 10; ++i) {
		if (numbers[i] > max) {
			max = numbers[i];
		}
	}
	/*cout << "maxMulti: " << max << endl;
	for (int j = 0; j < N - 1; j++)
	{
		cout << numbers[j] << endl;
	}
	*/
	int tmp;
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - 1; j++)
		{
			if (numbers[j + 1] <numbers[j])
			{
				tmp = numbers[j + 1];
				numbers[j + 1] = numbers[j];
				numbers[j] = tmp;
			}
		}
	}
	return numbers[i];// result
}
//random generating matrix[N][M]
void GenerateMatrix() 
{
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j++)
		{
			matr[i][j] = rand() % 90 - 10;
			cout.width(4);
			cout << matr[i][j];

		}
		cout << endl;
	}
}
//non-thread function (mono)
int CalcMono()
{
	for (int i = 0; i < N; i++)
	{
		numbers[i] = 0;

	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j += 2)
		{
			numbers[i] += matr[j][i];
		}
	}
	//1 2 3
	//4 5 6
	//7 8 9
	//numbers[i]=1+7 
	//numbers[i+1]=2+8                                <--  example
	//max= max{7,8}=8
	
	int max = numbers[0];
	for (int i = 0; i < 10; ++i) {
		if (numbers[i] > max) {
			max = numbers[i];
		}
	}
	//cout << "max: " << max << endl;
	/*for (int j = 0; j < N - 1; j++)
	{
		cout << numbers[j] << endl;
	}*/
	cout << max << endl;
	return max;
}


int main(int argc, char* argv[])
{
	GenerateMatrix();	
	srand(time(NULL));		
	unsigned int funcNumber = 0;

	double timerMultiStart, timerMultiEnd;
	double timerMonoStart, timerMonoEnd; // used for time calculation

	K -= 1;
	int world_size, world_rank;

	MPI_Init(&argc, &argv);

	MPI_Comm_size(MPI_COMM_WORLD, &world_size);
	MPI_Comm_rank(MPI_COMM_WORLD, &world_rank);

	
	double sum = 0;

	timerMultiStart = MPI_Wtime();
	if (world_rank == 0)
	{
		for (int i = 1; i < world_size; i++)
		{
			double data;
			MPI_Recv
			(
				&data,
				1, 
				MPI_DOUBLE,
				i,
				0, 
				MPI_COMM_WORLD, 
				MPI_STATUS_IGNORE 
			);

			sum += data;
		}
	}
	else
	{
		double data = Calc(world_rank - 1);
	
		MPI_Send
		(
			&data, 
			1,
			MPI_DOUBLE, 
			0, 
			0,
			MPI_COMM_WORLD 
		);
	}
	timerMultiEnd = MPI_Wtime();

	if (world_rank == 0)
	{
		std::cout << "multi: " << timerMultiEnd - timerMultiStart << std::endl;
		timerMonoStart = MPI_Wtime();
		std::cout << CalcMono() << std::endl;
		timerMonoEnd = MPI_Wtime();
		std::cout << "mono: " << timerMonoEnd - timerMonoStart << std::endl;
	}

	MPI_Finalize();
}
