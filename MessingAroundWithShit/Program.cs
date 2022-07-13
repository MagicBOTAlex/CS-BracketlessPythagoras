/// =====================
///   Declare variables
/// =====================
float sideA = 0;
float sideB = 0;
float sideC = 0;

float Eax = 0;
float Ebx = 0;
float Ecx = 0;
int Edx = 0;

goto Main;

/// ===================
///   Declare methods
/// ===================

// Calculates the lenth of c on a triangle using pytagoras therom
CalculatePythagorean:
    Eax = sideA;
    goto PowFuctionEax;
    PowFuctionEaxReturn:
    sideA = Eax;

    Ebx = sideB;
    goto PowFuctionEbx;
    PowFuctionEbxReturn:
    sideB = Ebx;

    Eax = sideA;
    Ebx = sideB;
    goto SumEaxEbx;
    SumEaxEbxReturn:
    sideC = Eax;
    
    Eax = sideC;
    goto SquareRootEax;
    SquareRootEaxReturn:
    sideC = Eax;

goto CalTriAreaReturn;

// Calculates the power of 2 for Eax
PowFuctionEax:
    Eax = Eax * Eax;
    goto PowFuctionEaxReturn;

// Calculates the power of 2 for Ebx
PowFuctionEbx:
    Ebx = Ebx * Ebx;
    goto PowFuctionEbxReturn;

// Sums the Eax register with Ebx and outpust it to the Eax register
SumEaxEbx:
    Eax = Eax + Ebx;
goto SumEaxEbxReturn;

// Finds the square root of Ecx and outputs the result to the Ecx register
// Note: uses the Eax, Ebx, Ecx and Edx registers
// Source: https://stackoverflow.com/a/49699681/14683392
// Edited by: BOTAlex
SquareRootEax:
    Ebx = 1;
    Ecx = 0;
    Edx = 0;

    if (Eax < 1)
        goto SquareRootNormalize;
    SquareRootNormalizeReturn:

SqrtLoopCycle:
    Eax *= 0.5f;
    Ebx += Ebx;
    if (Eax > Ebx)
        goto SqrtLoopCycle;

SqrtLoop2Cycle:
    if (!(Edx < 4))
        goto SqrtLoop2Escape;
    Ecx = Eax + Ebx;
    Ecx = Ecx * 0.5f;
    Ebx = Ebx / Ecx;
    Ebx = Ebx * Eax;
    Eax = Ecx;
    Edx = Edx + 1;
    goto SqrtLoop2Cycle;

SqrtLoop2Escape:
    Eax = Eax + Ecx;
    Eax = Eax * 0.5f;
    goto SquareRootEaxReturn;

SquareRootNormalize:
    Ebx = Eax;
    Eax = 1;
    goto SquareRootNormalizeReturn;



// Main entry for program
Main:
    Console.Write("Input triangle side a value:");
    sideA = float.Parse(Console.ReadLine());
    Console.Write("Input triangle side b value:");
    sideB = float.Parse(Console.ReadLine());

    goto CalculatePythagorean;
    CalTriAreaReturn:

    Console.WriteLine("\nTriangle side c is: " + sideC);