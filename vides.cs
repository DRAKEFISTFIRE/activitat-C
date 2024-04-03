#include <stdio.h>

#include <stdlib.h>

 

// Defineix la mida de la graella

#define ROW 5

#define COL 4

 

// Funció per imprimir una línia de la graella

void printRowLine() {

    printf("\n");

    for(int i = 0; i < COL; i++) {

        printf(" -----");

    }

    printf("\n");

}

 

// Funció per comptar els veïns vius d'una cel·la

int countLiveNeighbors(int a[ROW][COL], int r, int c) {

    int count = 0;

    for(int i = r - 1; i <= r + 1; i++) {

        for(int j = c - 1; j <= c + 1; j++) {

            if((i != r || j != c) && (i >= 0 && j >= 0) && (i < ROW && j < COL)) {

                if(a[i][j] == 1) {

                    count++;

                }

            }

        }

    }

    return count;

}

 

int main() {

    int grid[ROW][COL];

    int nextGen[ROW][COL];

 

    // Inicialitza la graella amb valors aleatoris (0 per a mort, 1 per a viva)

    for(int i = 0; i < ROW; i++) {

        for(int j = 0; j < COL; j++) {

            grid[i][j] = rand() % 2;

        }

    }

 

    // Imprimeix l'estat inicial de la graella

    printf("Etapa Inicial:");

    printRowLine();

    for(int i = 0; i < ROW; i++) {

        printf(":");

        for(int j = 0; j < COL; j++) {

            printf("  %d  :", grid[i][j]);

        }

        printRowLine();

    }

 

    // Calcula la següent generació basada en el nombre de veïns vius

    for(int i = 0; i < ROW; i++) {

        for(int j = 0; j < COL; j++) {

            int liveNeighbors = countLiveNeighbors(grid, i, j);

            if(grid[i][j] == 1 && (liveNeighbors == 2 || liveNeighbors == 3)) {

                nextGen[i][j] = 1;

            } else if(grid[i][j] == 0 && liveNeighbors == 3) {

                nextGen[i][j] = 1;

            } else {

                nextGen[i][j] = 0;

            }

        }

    }

 

    // Imprimeix la següent generació

    printf("\nSegüent Generació:");

    printRowLine();

    for(int i = 0; i < ROW; i++) {

        printf(":");

        for(int j = 0; j < COL; j++) {

            printf("  %d  :", nextGen[i][j]);

        }

        printRowLine();

    }
 printf("\nUltima Generació:");

    printRowLine();

    for(int i = 0; i < ROW; i++) {

        printf(":");

        for(int j = 0; j < COL; j++) {

            printf("  %d  :", ultGen[i][j]);

        }

        printRowLine();

    }

 

    return 0;

}