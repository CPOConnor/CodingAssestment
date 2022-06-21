// See https://aka.ms/new-console-template for more information

string FindLeastVariableWeatherDay()
{
    using (var sr = new StreamReader("weather.dat"))
    {
        string day = "";
        double minTempDifference = double.MaxValue;
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine() ?? "";
            string[] cells = line.Split().Where(s => s != String.Empty).ToArray();

            if (cells.Length < 3)
                continue;
            if (!Double.TryParse(cells[1].Replace("*", ""), out double maxTemp))
                continue;
            if (!Double.TryParse(cells[2].Replace("*", ""), out double minTemp))
                continue;

            if (maxTemp - minTemp < minTempDifference)
            {
                minTempDifference = maxTemp - minTemp;
                day = cells[0];
            }
        }
        return day; 
    }
}

string FindLeastVariableFootballTeam()
{

    using (var sr = new StreamReader("football.dat"))
    {
        string team = "";
        int minGoalDifference = Int32.MaxValue;
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine() ?? "";
            string[] cells = line.Split().Where(s => s != String.Empty).ToArray();

            if (cells.Length < 9)
                continue;
            if (!Int32.TryParse(cells[6], out int goalsFor))
                continue;
            if (!Int32.TryParse(cells[8], out int goalsAgainst))
                continue;

            int lineGoalDifference = Math.Abs(goalsFor - goalsAgainst);

            if (lineGoalDifference < minGoalDifference)
            {
                minGoalDifference = lineGoalDifference;
                team = cells[1];
            }
        }
        return team;
    }
}

string FindLeastVariableColumn(string filename, int indexOutColumn, int indexComp1, int indexComp2)
{
    using (var sr = new StreamReader(filename))
    {
        string output = "";
        double minVariance = Double.MaxValue;
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine() ?? "";
            string[] cells = line.Split().Where(s => s != String.Empty).ToArray();

            int maxIndex = new int[] { indexComp1, indexComp2, indexOutColumn }.Max();
            if (cells.Length < maxIndex + 1)
                continue;
            if (!Double.TryParse(cells[indexComp1].Replace("*", ""), out double column1Val))
                continue;
            if (!Double.TryParse(cells[indexComp2].Replace("*", ""), out double column2Val))
                continue;

            double lineVariance = Math.Abs(column1Val - column2Val);

            if (lineVariance < minVariance)
            {
                minVariance = lineVariance;
                output = cells[indexOutColumn];
            }
        }
        return output;
    }
}

string weather = FindLeastVariableWeatherDay();
string football = FindLeastVariableFootballTeam();

string weather2 = FindLeastVariableColumn("weather.dat", 0, 1, 2);
string football2 = FindLeastVariableColumn("football.dat", 1, 6, 8);

Console.WriteLine($"Weather: method1 {weather} method2 {weather2}");
Console.WriteLine($"Football: method1 {football} method2 {football2}");
