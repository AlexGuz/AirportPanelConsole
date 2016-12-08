using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //create  flying list
            List<Flying> flyingList = new List<Flying>
            {
                new Flying {Time=DateTime.Now.AddHours(2), FlNumber= "S3478", Type=FlyingType.Arrival,
                    Town ="Kharkiv",Company="S7",Terminal=Terminal.TerminalA,FlStatus=FlStatus.Arrived,Gate=Gate.Gate1},
                new Flying {Time=DateTime.Now.AddHours(1), FlNumber= "K9863",Type=FlyingType.Arrival,
                    Town ="Kharkiv",Company="SA",Terminal=Terminal.TerminalB,FlStatus=FlStatus.Canceled,Gate=Gate.Gate2},
                new Flying {Time=DateTime.Now.AddHours(3), FlNumber= "IL687",Type=FlyingType.Arrival,
                    Town ="Kharkiv",Company="MAU",Terminal=Terminal.TerminalC,FlStatus=FlStatus.CheckIn,Gate=Gate.Gate3},
                new Flying {Time=DateTime.Now.AddMinutes(20), FlNumber= "H45L6",Type=FlyingType.Arrival,
                    Town ="Kharkiv",Company="VR",Terminal=Terminal.TerminalD,FlStatus=FlStatus.Delayed,Gate=Gate.Gate4},
                new Flying {Time=DateTime.Now.AddMinutes(40), FlNumber= "PO6H4",Type=FlyingType.Arrival,
                    Town ="Kharkiv",Company="AF",Terminal=Terminal.TerminalF,FlStatus=FlStatus.Unknown, Gate=Gate.Gate5},
                new Flying {Time=DateTime.Now.AddHours(2), FlNumber= "S4563",Type=FlyingType.Departures,
                    Town ="Kiev",Company="S7",Terminal=Terminal.TerminalA,FlStatus=FlStatus.Arrived,Gate=Gate.Gate1},
                new Flying {Time=DateTime.Now.AddHours(1), FlNumber= "L4789",Type=FlyingType.Departures,
                    Town ="Moskow",Company="SA",Terminal=Terminal.TerminalB,FlStatus=FlStatus.Canceled,Gate=Gate.Gate2},
                new Flying {Time=DateTime.Now.AddHours(3), FlNumber= "LF456",Type=FlyingType.Departures,
                    Town ="Krakiv",Company="MAU",Terminal=Terminal.TerminalC,FlStatus=FlStatus.CheckIn,Gate=Gate.Gate3},
                new Flying {Time=DateTime.Now.AddMinutes(20), FlNumber= "UI57P",Type=FlyingType.Departures,
                    Town ="Lviv",Company="VR",Terminal=Terminal.TerminalD,FlStatus=FlStatus.Delayed,Gate=Gate.Gate4},
                new Flying {Time=DateTime.Now.AddMinutes(40), FlNumber= "R45PL",Type=FlyingType.Departures,
                    Town ="Varshava",Company="AF",Terminal=Terminal.TerminalF,FlStatus=FlStatus.Unknown, Gate=Gate.Gate5}
            };

            Start(flyingList);

            Console.ReadLine();
        }

        //method for choose what we do
        static void Start(List<Flying> flyingList)
        {
            while (true)
            {
                Console.WriteLine("What you need?");
                Console.WriteLine("Arrival list-enter - 1; departures list-enter - 2; exit fron console - 0");

                int enter = int.Parse(Console.ReadLine());

                if (enter == 0)
                {
                    Environment.Exit(0);
                }

                //We put swich-case in the block try-catch that would catch possible exceptions
                try
                {
                    FlyingType enterType = (FlyingType)Enum.Parse(typeof(FlyingType), enter.ToString());

                    ShowFlight(flyingList, enterType);
                }
                catch (FormatException)
                {
                    Emergency();
                }

                Console.WriteLine("Do you whant add new flight - 1 or delete flight - 2? Find a flight on the specified parameters - 3, Find the nearest flight - 4" +
                    "change somthin in list - 5");
                try
                {
                    int enterChoise = int.Parse(Console.ReadLine());

                    switch (enterChoise)
                    {
                        case 1:
                            Console.WriteLine("Do you whant add new arrival - 1 or departures - 2");
                            FlyingType enterType = (FlyingType)Enum.Parse(typeof(FlyingType), Console.ReadLine());
                            AddFlight(flyingList, enterType);
                            break;

                        case 2:
                            Console.WriteLine("Do you whant delete  arrival - 1 or departures - 2");
                            enterType = (FlyingType)Enum.Parse(typeof(FlyingType), Console.ReadLine());
                            DeleteFlight(flyingList);
                            ShowFlight(flyingList, enterType);
                            break;

                        case 3:
                            FindFlight(flyingList);
                            break;

                        case 4:
                            Console.WriteLine("Find a nearest flight arrival - 1 or departures - 2");
                            enterType = (FlyingType)Enum.Parse(typeof(FlyingType), Console.ReadLine());
                            FindNearestFlight(flyingList, enterType);
                            break;

                        case 5:
                            Console.WriteLine("change somthin in flight");
                            ChangeFlight(flyingList);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Emergency();
                }
            }
        }

        //emergency situation
        static void Emergency()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("Declared an emergency situation. Proceed to the nearest exit");

            Console.ReadLine();
            Environment.Exit(0);
        }

        //method for print in console one element of the list
        static void ShowOneFlight(List<Flying> flyingList, int count)
        {
            Console.WriteLine(flyingList[count].Type + flyingList[count].Time.ToString() + "\t" + flyingList[count].FlNumber + "\t" + flyingList[count].Town
                                + "\t" + flyingList[count].Company + "\t" + flyingList[count].Terminal + "\t" + flyingList[count].FlStatus
                                + "\t" + flyingList[count].Gate);
        }

        //method for print in console all element of the list
        static void ShowFlight(List<Flying> flyingList, FlyingType enterType)
        {
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Type == enterType)
                {
                    ShowOneFlight(flyingList, i);
                }
            }
        }

        //method for add new element in the list
        static void AddFlight(List<Flying> flyingList, FlyingType choise)
        {
            Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
            DateTime timeChoice = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Flight Number");
            string flNumberChoice = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter Company");
            string companyChoice = Console.ReadLine().ToUpper();

            Terminal terminalChoise = ChooseTerminal();

            FlStatus flStatusChoise;

            Gate gateChoise = ChooseGate();

            string townChoice = "Kharkiv";

            if (FlyingType.Departures == choise)
            {
                Console.WriteLine("Enter Town");
                townChoice = Console.ReadLine().ToUpper();
                flStatusChoise = ChooseFlStatusArrival();
            }

            else
            {
                flStatusChoise = ChooseFlStatusDepartures();
            }

            flyingList.Add(new Flying
            {
                Time = timeChoice,
                FlNumber = flNumberChoice,
                Company = companyChoice,
                Terminal = terminalChoise,
                FlStatus = flStatusChoise,
                Town = townChoice,
                Gate = gateChoise,
                Type = choise
            });

            ShowFlight(flyingList, choise);
        }

        //method for choose a new Terminal
        static Terminal ChooseTerminal()
        {
            Console.WriteLine("Enter Terminal TerminalA - 1, TerminalB - 2, TerminalC - 3, TerminalD - 4, TerminalF - 5, unknown - default- 0");
            Terminal terminalChoise = Terminal.Unknown;

            try
            {
                terminalChoise = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());
            }
            catch (FormatException)
            {
                Emergency();
            }
            return terminalChoise;
        }

        //method for choose a new FlStatus for arrival List
        static FlStatus ChooseFlStatusArrival()
        {
            Dictionary<int, FlStatus> choiseOperations = new Dictionary<int, FlStatus>
            {
                { 1, FlStatus.CheckIn },
                { 2, FlStatus.Arrived },
                { 3, FlStatus.Canceled },
                { 4, FlStatus.ExpectedAt },
                { 5, FlStatus.Delayed },
                { 6, FlStatus.InFlight }
            };

            Console.WriteLine("Enter FlyStatus check-in - 1, arrived - 2, canceled - 3, expected at - 4, delayed - 5, in flight - 6, unknown - default");
            FlStatus flStatusChoise = FlStatus.Unknown;

            try
            {
                int enterChoise = int.Parse(Console.ReadLine());

                if (choiseOperations.ContainsKey(enterChoise))
                {
                    flStatusChoise = choiseOperations[enterChoise];
                }                
            }
            catch (FormatException)
            {
                Emergency();
            }
            return flStatusChoise;
        }

        //method for choose a new FlStatus for departures List
        static FlStatus ChooseFlStatusDepartures()
        {
            Dictionary<int, FlStatus> choiseOperations = new Dictionary<int, FlStatus>
            {
                { 1, FlStatus.CheckIn },
                { 2, FlStatus.GateClosed },
                { 3, FlStatus.DepartedAt },
                { 4, FlStatus.Canceled },
                { 5, FlStatus.Delayed }
            };

            Console.WriteLine("Enter FlyStatus check-in - 1, gate closed - 2, departed at - 3, canceled - 4, delayed - 5, unknown - default");
            FlStatus flStatusChoise = FlStatus.Unknown;

            try
            {
                int enterChoise = int.Parse(Console.ReadLine());

                if (choiseOperations.ContainsKey(enterChoise))
                {
                    flStatusChoise = choiseOperations[enterChoise];
                }
            }
            catch (FormatException)
            {
                Emergency();
            }

            return flStatusChoise;
        }

        //method for choose a new Gate
        static Gate ChooseGate()
        {
            Console.WriteLine("Enter gate Gate1 - 1, Gate2 - 2, Gate3 - 3, Gate4 - 4, Gate5 - 5, Gate6 - 6, Gate7 - 7 , Gate8 - 8 , Gate9 - 9, unknown - default - 0");
            Gate gateChoise = Gate.Unknown;

            try
            {
                gateChoise = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());
            }
            catch (FormatException)
            {
                Emergency();
            }
            return gateChoise;
        }

        //method for delete element of the list
        static void DeleteFlight(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Flight Number");
            string delFlNumber = Console.ReadLine().ToUpper();

            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].FlNumber == delFlNumber)
                {
                    flyingList.RemoveAt(i);
                    break;
                }
            }
        }

        // method for searching elements of the List
        static void FindFlight(List<Flying> flyingList)
        {
            Dictionary<int, Action<List<Flying>>> choiseOperations = new Dictionary<int, Action<List<Flying>>>
            {
                { 1, FindFlightTime },
                { 2, FindFlightFlNumber },
                { 3, FindFlightTown },
                { 4, FindFlightCompany },
                { 5, FindFlightTerminal },
                { 6, FindFlightFlStatus },
                { 7, FindFlightGate }
            };
            Console.WriteLine("Enter what you want to find Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                if (choiseOperations.ContainsKey(findNumber))
                {
                    choiseOperations[findNumber](flyingList);
                }
            }
            catch (Exception)
            {
                Emergency();
            }
        }

        // method for searching Gate in element of the List
        private static void FindFlightGate(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Gate ");
            Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Gate == enterGate)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching flStatus in element of the List
        private static void FindFlightFlStatus(List<Flying> flyingList)
        {
            Console.WriteLine("Enter flStatus ");
            FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].FlStatus == enterFlStatus)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching Terminal in element of the List
        private static void FindFlightTerminal(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Terminal ");
            Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Terminal == enterTerminal)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching Company in element of the List
        private static void FindFlightCompany(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Company ");
            string enterCompany = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Company == enterCompany)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching Town in element of the List
        private static void FindFlightTown(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Town ");
            string enterTown = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Town == enterTown)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching FlNumber in element of the List
        private static void FindFlightFlNumber(List<Flying> flyingList)
        {
            Console.WriteLine("Enter FlNumber ");
            string enterFlNumber = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].FlNumber == enterFlNumber)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        // method for searching Time in element of the List
        static void FindFlightTime(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
            DateTime enterTime = DateTime.Parse(Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {

                if (flyingList[i].Time == enterTime)
                {
                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }

                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing elements of the List
        static void ChangeFlight(List<Flying> flyingList)
        {
            Dictionary<int, Action<List<Flying>>> choiseOperations = new Dictionary<int, Action<List<Flying>>>
            {
                { 1, ChangeFlightTime },
                { 2, ChangeFlightFlNumber },
                { 3, ChangeFlightTown },
                { 4, ChangeFlightCompany },
                { 5, ChangeFlightTerminal },
                { 6, ChangeFlightFlStatus },
                { 7, ChangeFlightGate }
            };

            Console.WriteLine("Enter what you want to change Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                if (choiseOperations.ContainsKey(findNumber))
                {
                    choiseOperations[findNumber](flyingList);
                }
            }
            catch (Exception)
            {
                Emergency();
            }
        }

        //  method for changing Gate in element of the List
        private static void ChangeFlightGate(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Gate ");
            Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Gate == enterGate)
                {
                    Gate newGate = ChooseGate();

                    var temp = flyingList.ToArray()[i];
                    temp.Gate = newGate;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing FlStatus in element of the List
        private static void ChangeFlightFlStatus(List<Flying> flyingList)
        {
            Console.WriteLine("Enter FlStatus ");
            FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].FlStatus == enterFlStatus)
                {
                    FlStatus newFlStatus = ChooseFlStatusArrival();

                    var temp = flyingList.ToArray()[i];
                    temp.FlStatus = newFlStatus;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing Terminal in element of the List
        private static void ChangeFlightTerminal(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Terminal ");
            Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Terminal == enterTerminal)
                {
                    Terminal newTerminal = ChooseTerminal();

                    var temp = flyingList.ToArray()[i];
                    temp.Terminal = newTerminal;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing Company in element of the List
        private static void ChangeFlightCompany(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Company ");
            string enterCompany = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Company == enterCompany)
                {
                    Console.WriteLine("Enter new Company ");
                    string enterNewCompany = Console.ReadLine().ToUpper();

                    var temp = flyingList.ToArray()[i];
                    temp.Town = enterNewCompany;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing Town in element of the List
        private static void ChangeFlightTown(List<Flying> flyingList)
        {
            Console.WriteLine("Enter Town ");
            string enterTown = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Town == enterTown)
                {
                    Console.WriteLine("Enter new Town ");
                    string enterNewTown = Console.ReadLine().ToUpper();

                    var temp = flyingList.ToArray()[i];
                    temp.Town = enterNewTown;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing FlNumber in element of the List
        private static void ChangeFlightFlNumber(List<Flying> flyingList)
        {
            Console.WriteLine("Enter a editable FlNumber ");
            string enterFlNumber = Console.ReadLine().ToUpper();

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {

                if (flyingList[i].FlNumber == enterFlNumber)
                {
                    Console.WriteLine("Enter new FlNumber ");
                    string enterNewFlNumber = Console.ReadLine().ToUpper();

                    var temp = flyingList.ToArray()[i];
                    temp.FlNumber = enterNewFlNumber;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }
                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //  method for changing Time in element of the List
        private static void ChangeFlightTime(List<Flying> flyingList)
        {
            Console.WriteLine("Enter a editable time in format yyyy-MM-dd HH:mm");
            DateTime enterTime = DateTime.Parse(Console.ReadLine());

            bool notFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {

                if (flyingList[i].Time == enterTime)
                {
                    Console.WriteLine("Enter new time in format yyyy-MM-dd HH:mm");
                    DateTime enterTimeNew = DateTime.Parse(Console.ReadLine());

                    var temp = flyingList.ToArray()[i];
                    temp.Time = enterTime;

                    flyingList.RemoveAt(i);
                    flyingList.Insert(i, temp);

                    ShowOneFlight(flyingList, i);
                    notFind = false;
                }

                if (notFind)
                {
                    Console.WriteLine("Flights meet these criteria are not found");
                }
            }
        }

        //method for find nearest flights
        static void FindNearestFlight(List<Flying> flyingList, FlyingType enterType)
        {
            bool noFind = true;
            for (int i = 0; i < flyingList.Count; i++)
            {
                if (flyingList[i].Type == enterType)
                {
                    if (flyingList[i].Time >= DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0)) && flyingList[i].Time <= DateTime.Now.AddHours(1))
                    {
                        ShowOneFlight(flyingList, i);
                        noFind = false;
                    }
                }
            }

            if (noFind)
            {
                Console.WriteLine("No closest flights");
            }
        }
    }
}