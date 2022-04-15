using System;

namespace Epidemiya
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Epidemic
    {   
        // количество известных больных
        private int NumOfPatients; // l

        // количество людей которые не всприимчивы к болезни
        private int ImmuneToDisease; // R

        // количество людей проживающих в регионе
        private int NumberOfInhabitance; // N

        // интенсивность заражения от одного больного
        private int InfectionIntencity; // lambda

        // агрессивность возбудиделя болезни
        private int AggressivenessOfTheDisease; // A 

        // инетсивность выздоровления
        private int IntensityOfRecovery; // u

        // скорость потери иммунитета
        private int TendecyToLoseImmunity; // y


        // доля восприимчевых среди населнния
        private int PercentageOfSusceptible()
        {
            return 1 - (ImmuneToDisease / NumberOfInhabitance);
        }

        // среднее кол-во людей заболеющих за неделю
        private int DiseasePerWeek() // v
        {
            return PercentageOfSusceptible() * ((NumOfPatients * InfectionIntencity) + AggressivenessOfTheDisease);
        }

        // средне кол-во людей в начале следующей недели
        private int TheNumberOfCasesAtTheBeginningOfNextWeek() // l2
        {
            return NumOfPatients * (1 - IntensityOfRecovery) + DiseasePerWeek();
        }

        // кол-во людей потерявших иммунитет
        private int NumberOfPeopleWhoLostImmunityThisWeek() // R2
        {
            return ImmuneToDisease * (NumOfPatients - TendecyToLoseImmunity) + DiseasePerWeek();
        }

        // среднее кол-во заболевших за вторую неделю
        private int TheNumberOfCasesAtNextWeek() // v2
        {
            return (1 - (NumberOfPeopleWhoLostImmunityThisWeek() / NumberOfInhabitance)) * ((TheNumberOfCasesAtTheBeginningOfNextWeek() * InfectionIntencity) + AggressivenessOfTheDisease);
        }
    }
}
