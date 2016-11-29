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
            //create  arrival list
            List<Arrival> arrivalList = new List<Arrival>
        {
            new Arrival {Time=DateTime.Now.AddHours(2), FlNumber= "S3478",
                Town ="Kharkiv",Company="S7",Terminal=Terminal.TerminalA,FlStatus=FlStatus.Arrived,Gate=Gate.Gate1},
            new Arrival {Time=DateTime.Now.AddHours(1), FlNumber= "K9863",
                Town ="Kharkiv",Company="SA",Terminal=Terminal.TerminalB,FlStatus=FlStatus.Canceled,Gate=Gate.Gate2},
            new Arrival {Time=DateTime.Now.AddHours(3), FlNumber= "IL687",
                Town ="Kharkiv",Company="MAU",Terminal=Terminal.TerminalC,FlStatus=FlStatus.CheckIn,Gate=Gate.Gate3},
            new Arrival {Time=DateTime.Now.AddMinutes(20), FlNumber= "H45L6",
                Town ="Kharkiv",Company="VR",Terminal=Terminal.TerminalD,FlStatus=FlStatus.Delayed,Gate=Gate.Gate4},
            new Arrival {Time=DateTime.Now.AddMinutes(40), FlNumber= "PO6H4",
                Town ="Kharkiv",Company="AF",Terminal=Terminal.TerminalF,FlStatus=FlStatus.Unknown, Gate=Gate.Gate5}
        };
            //create  departures list
            List<Departures> departuresList = new List<Departures>
        {
            new Departures {Time=DateTime.Now.AddHours(2), FlNumber= "S3478",
                Town ="Kiev",Company="S7",Terminal=Terminal.TerminalA,FlStatus=FlStatus.Arrived,Gate=Gate.Gate1},
            new Departures {Time=DateTime.Now.AddHours(1), FlNumber= "K9863",
                Town ="Moskow",Company="SA",Terminal=Terminal.TerminalB,FlStatus=FlStatus.Canceled,Gate=Gate.Gate2},
            new Departures {Time=DateTime.Now.AddHours(3), FlNumber= "IL687",
                Town ="Krakiv",Company="MAU",Terminal=Terminal.TerminalC,FlStatus=FlStatus.CheckIn,Gate=Gate.Gate3},
            new Departures {Time=DateTime.Now.AddMinutes(20), FlNumber= "H45L6",
                Town ="Lviv",Company="VR",Terminal=Terminal.TerminalD,FlStatus=FlStatus.Delayed,Gate=Gate.Gate4},
            new Departures {Time=DateTime.Now.AddMinutes(40), FlNumber= "PO6H4",
                Town ="Varshava",Company="AF",Terminal=Terminal.TerminalF,FlStatus=FlStatus.Unknown, Gate=Gate.Gate5}
        };

            Start(arrivalList, departuresList);

            Console.ReadLine();
        }

        //method for choose what we do
        static void Start(List<Arrival> arrivalList, List<Departures> departuresList)
        {
            Console.WriteLine("What you need?");
            Console.WriteLine("Arrival list-enter - 1; departures list-enter - 2");
            //We put swich-case in the block try-catch that would catch possible exceptions
            try
            {
                int enterChoise = int.Parse(Console.ReadLine());

                switch (enterChoise)
                {
                    case 1:
                        ShowArrival(arrivalList);
                        break;
                    case 2:
                        ShowDepartures(departuresList);
                        break;
                }
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
                        enterChoise = int.Parse(Console.ReadLine());

                        switch (enterChoise)
                        {
                            case 1:
                                AddArrival(arrivalList);
                                ShowArrival(arrivalList);
                                Start(arrivalList, departuresList);
                                break;
                            case 2:
                                AddDepartures(departuresList);
                                ShowDepartures(departuresList);
                                Start(arrivalList, departuresList);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Do you whant delete  arrival - 1 or departures - 2");
                        enterChoise = int.Parse(Console.ReadLine());

                        switch (enterChoise)
                        {
                            case 1:
                                DeleteArrival(arrivalList);
                                ShowArrival(arrivalList);
                                Start(arrivalList, departuresList);
                                break;
                            case 2:
                                DeleteDepartures(departuresList);
                                ShowDepartures(departuresList);
                                Start(arrivalList, departuresList);
                                break;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Find a arriving - 1 or departing - 2");
                        enterChoise = int.Parse(Console.ReadLine());

                        switch (enterChoise)
                        {
                            case 1:
                                FindArrival(arrivalList);
                                Start(arrivalList, departuresList);
                                break;
                            case 2:
                                FindDepartures(departuresList);
                                Start(arrivalList, departuresList);
                                break;
                        }
                        break;

                    case 4:
                        Console.WriteLine("Find a arriving - 1 or departing - 2");
                        enterChoise = int.Parse(Console.ReadLine());

                        switch (enterChoise)
                        {
                            case 1:
                                FindNearestArrival(arrivalList);
                                Start(arrivalList, departuresList);
                                break;
                            case 2:
                                FindNearestDepartures(departuresList);
                                Start(arrivalList, departuresList);
                                break;
                        }
                        break;

                    case 5:
                        Console.WriteLine("change somthin in arriving - 1 or departing - 2");
                        enterChoise = int.Parse(Console.ReadLine());

                        switch (enterChoise)
                        {
                            case 1:
                                ChangeArrival(arrivalList);
                                Start(arrivalList, departuresList);
                                break;
                            case 2:
                                ChangeDepartures(departuresList);
                                Start(arrivalList, departuresList);
                                break;
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                Emergency();
            }

        }

        //method for print in console one element of the list
        static void ShowOneArrival(List<Arrival> arrivalList, int count)
        {
            Console.WriteLine(arrivalList[count].Time.ToString() + "\t" + arrivalList[count].FlNumber + "\t" + arrivalList[count].Town
                                + "\t" + arrivalList[count].Company + "\t" + arrivalList[count].Terminal + "\t" + arrivalList[count].FlStatus
                                + "\t" + arrivalList[count].Gate);
        }

        static void ShowOneDepartures(List<Departures> departuresList, int count)
        {
            Console.WriteLine(departuresList[count].Time.ToString() + "\t" + departuresList[count].FlNumber + "\t" + departuresList[count].Town
                                + "\t" + departuresList[count].Company + "\t" + departuresList[count].Terminal + "\t" + departuresList[count].FlStatus
                                + "\t" + departuresList[count].Gate);
        }

        //method for print in console all element of the list
        static void ShowArrival(List<Arrival> arrivalList)
        {
            for (int i = 0; i < arrivalList.Count; i++)
            {
                ShowOneArrival(arrivalList, i);
            }
        }

        static void ShowDepartures(List<Departures> departuresList)
        {
            for (int i = 0; i < departuresList.Count; i++)
            {
                ShowOneDepartures(departuresList, i);
            }
        }

        //method for add new element in the list
        static void AddArrival(List<Arrival> arrivalList)
        {
            Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
            DateTime timeChoice = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Flight Number");
            string flNumberChoice = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter Company");
            string companyChoice = Console.ReadLine().ToUpper();

            Terminal terminalChoise = ChooseTerminal();

            FlStatus flStatusChoise = ChooseFlStatusArrival();

            Gate gateChoise = ChooseGate();

            arrivalList.Add(new Arrival
            {
                Time = timeChoice,
                FlNumber = flNumberChoice,
                Town = "Kharkiv",
                Company = companyChoice,
                Terminal = terminalChoise,
                FlStatus = flStatusChoise,
                Gate = gateChoise
            });
        }

        static void Emergency()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("Declared an emergency situation. Proceed to the nearest exit");
            
            Console.ReadLine();
            Environment.Exit(0);
        }
        static void AddDepartures(List<Departures> departuresList)
        {
            Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
            DateTime timeChoice = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Flight Number");
            string flNumberChoice = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter Town");
            string townChoice = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter Company");
            string companyChoice = Console.ReadLine().ToUpper();

            Terminal terminalChoise = ChooseTerminal();

            FlStatus flStatusChoise = ChooseFlStatusDepartures();

            Gate gateChoise = ChooseGate();

            departuresList.Add(new Departures
            {
                Time = timeChoice,
                FlNumber = flNumberChoice,
                Town = townChoice,
                Company = companyChoice,
                Terminal = terminalChoise,
                FlStatus = flStatusChoise,
                Gate = gateChoise
            });
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
            Console.WriteLine("Enter FlyStatus check-in - 1, arrived - 2, canceled - 3, expected at - 4, delayed - 5, in flight - 6, unknown - default");
            FlStatus flStatusChoise = FlStatus.Unknown;

            try
            {
                int enterChoise1 = int.Parse(Console.ReadLine());

                switch (enterChoise1)
                {
                    case 1:
                        flStatusChoise = FlStatus.CheckIn;
                        break;
                    case 2:
                        flStatusChoise = FlStatus.Arrived;
                        break;
                    case 3:
                        flStatusChoise = FlStatus.Canceled;
                        break;
                    case 4:
                        flStatusChoise = FlStatus.ExpectedAt;
                        break;
                    case 5:
                        flStatusChoise = FlStatus.Delayed;
                        break;
                    case 6:
                        flStatusChoise = FlStatus.InFlight;
                        break;
                    default:
                        Console.WriteLine("You have entered an incorrect value FlStatus unknown");
                        break;
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
            Console.WriteLine("Enter FlyStatus check-in - 1, gate closed - 2, departed at - 3, canceled - 4, delayed - 5, unknown - default");
            FlStatus flStatusChoise = FlStatus.Unknown;

            try
            {
                int enterChoise1 = int.Parse(Console.ReadLine());

                switch (enterChoise1)
                {
                    case 1:
                        flStatusChoise = FlStatus.CheckIn;
                        break;
                    case 2:
                        flStatusChoise = FlStatus.GateClosed;
                        break;
                    case 3:
                        flStatusChoise = FlStatus.DepartedAt;
                        break;
                    case 4:
                        flStatusChoise = FlStatus.Canceled;
                        break;
                    case 5:
                        flStatusChoise = FlStatus.Delayed;
                        break;
                    default:
                        Console.WriteLine("You have entered an incorrect value FlStatus unknown");
                        break;
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
        static void DeleteArrival(List<Arrival> arrivalList)
        {
            Console.WriteLine("Enter Flight Number");
            string delFlNumber = Console.ReadLine().ToUpper();

            for (int i = 0; i < arrivalList.Count; i++)
            {
                if (arrivalList[i].FlNumber == delFlNumber)
                    arrivalList.RemoveAt(i);
            }
        }

        static void DeleteDepartures(List<Departures> departuresList)
        {
            Console.WriteLine("Enter Flight Number");
            string delFlNumber = Console.ReadLine().ToUpper();

            for (int i = 0; i < departuresList.Count; i++)
            {
                if (departuresList[i].FlNumber == delFlNumber)
                    departuresList.RemoveAt(i);
            }
        }

        // method for searching elements of the List
        static void FindArrival(List<Arrival> arrivalList)
        {
            Console.WriteLine("Enter what you want to find Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                switch (findNumber)
                {
                    case 1:
                        Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
                        DateTime enterTime = DateTime.Parse(Console.ReadLine());

                        bool notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {

                            if (arrivalList[i].Time == enterTime)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }

                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter FlNumber ");
                        string enterFlNumber = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].FlNumber == enterFlNumber)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Town ");
                        string enterTown = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Town == enterTown)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Company ");
                        string enterCompany = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Company == enterCompany)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Terminal ");
                        Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Terminal == enterTerminal)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter flStatus ");
                        FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].FlStatus == enterFlStatus)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Enter Gate ");
                        Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Gate == enterGate)
                            {
                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Emergency();
            }
        }


        static void FindDepartures(List<Departures> departuresList)
        {
            Console.WriteLine("Enter what you want to find Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                switch (findNumber)
                {
                    case 1:
                        Console.WriteLine("Enter Time in format yyyy-MM-dd HH:mm");
                        DateTime enterTime = DateTime.Parse(Console.ReadLine());

                        bool notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Time == enterTime)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }

                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter FlNumber ");
                        string enterFlNumber = Console.ReadLine();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].FlNumber == enterFlNumber)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Town ");
                        string enterTown = Console.ReadLine();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Town == enterTown)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Company ");
                        string enterCompany = Console.ReadLine();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Company == enterCompany)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Terminal ");
                        Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Terminal == enterTerminal)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter FlStatus ");
                        FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].FlStatus == enterFlStatus)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Enter Gate ");
                        Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Gate == enterGate)
                            {
                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Emergency();
            }

        }

        static void ChangeArrival(List<Arrival> arrivalList)
        {
            Console.WriteLine("Enter what you want to change Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                switch (findNumber)
                {
                    case 1:
                        Console.WriteLine("Enter a editable time in format yyyy-MM-dd HH:mm");
                        DateTime enterTime = DateTime.Parse(Console.ReadLine());

                        bool notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {

                            if (arrivalList[i].Time == enterTime)
                            {
                                Console.WriteLine("Enter new time in format yyyy-MM-dd HH:mm");
                                DateTime enterTimeNew = DateTime.Parse(Console.ReadLine());

                                var temp = arrivalList.ToArray()[i];
                                temp.Time = enterTime;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }

                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter a editable FlNumber ");
                        string enterFlNumber = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {

                            if (arrivalList[i].FlNumber == enterFlNumber)
                            {
                                Console.WriteLine("Enter new FlNumber ");
                                string enterNewFlNumber = Console.ReadLine().ToUpper();

                                var temp = arrivalList.ToArray()[i];
                                temp.FlNumber = enterNewFlNumber;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Town ");
                        string enterTown = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Town == enterTown)
                            {
                                Console.WriteLine("Enter new Town ");
                                string enterNewTown = Console.ReadLine().ToUpper();

                                var temp = arrivalList.ToArray()[i];
                                temp.Town = enterNewTown;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Company ");
                        string enterCompany = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Company == enterCompany)
                            {
                                Console.WriteLine("Enter new Company ");
                                string enterNewCompany = Console.ReadLine().ToUpper();

                                var temp = arrivalList.ToArray()[i];
                                temp.Town = enterNewCompany;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Terminal ");
                        Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Terminal == enterTerminal)
                            {
                                Terminal newTerminal = ChooseTerminal();

                                var temp = arrivalList.ToArray()[i];
                                temp.Terminal = newTerminal;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter FlStatus ");
                        FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].FlStatus == enterFlStatus)
                            {
                                FlStatus newFlStatus = ChooseFlStatusArrival();

                                var temp = arrivalList.ToArray()[i];
                                temp.FlStatus = newFlStatus;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Enter Gate ");
                        Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < arrivalList.Count; i++)
                        {
                            if (arrivalList[i].Gate == enterGate)
                            {
                                Gate newGate = ChooseGate();

                                var temp = arrivalList.ToArray()[i];
                                temp.Gate = newGate;

                                arrivalList.RemoveAt(i);
                                arrivalList.Insert(i, temp);

                                ShowOneArrival(arrivalList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Emergency();
            }
        }

        static void ChangeDepartures(List<Departures> departuresList)
        {
            Console.WriteLine("Enter what you want to change Time - 1, FlNumber - 2, Town - 3, Company - 4, Terminal - 5, FlStatus - 6, Gate - 7");

            try
            {
                int findNumber = int.Parse(Console.ReadLine());

                switch (findNumber)
                {
                    case 1:
                        Console.WriteLine("Enter a editable time in format yyyy-MM-dd HH:mm");
                        DateTime enterTime = DateTime.Parse(Console.ReadLine());

                        bool notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Time == enterTime)
                            {
                                Console.WriteLine("Enter new time in format yyyy-MM-dd HH:mm");
                                DateTime enterTimeNew = DateTime.Parse(Console.ReadLine());

                                var temp = departuresList.ToArray()[i];
                                temp.Time = enterTime;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }

                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter a editable FlNumber ");
                        string enterFlNumber = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].FlNumber == enterFlNumber)
                            {
                                Console.WriteLine("Enter new FlNumber ");
                                string enterNewFlNumber = Console.ReadLine().ToUpper();

                                var temp = departuresList.ToArray()[i];
                                temp.FlNumber = enterNewFlNumber;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Town ");
                        string enterTown = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Town == enterTown)
                            {
                                Console.WriteLine("Enter new Town ");
                                string enterNewTown = Console.ReadLine().ToUpper();

                                var temp = departuresList.ToArray()[i];
                                temp.Town = enterNewTown;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Company ");
                        string enterCompany = Console.ReadLine().ToUpper();

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Company == enterCompany)
                            {
                                Console.WriteLine("Enter new Company ");
                                string enterNewCompany = Console.ReadLine().ToUpper();

                                var temp = departuresList.ToArray()[i];
                                temp.Town = enterNewCompany;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Terminal ");
                        Terminal enterTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Terminal == enterTerminal)
                            {
                                Terminal newTerminal = ChooseTerminal();

                                var temp = departuresList.ToArray()[i];
                                temp.Terminal = newTerminal;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter FlStatus ");
                        FlStatus enterFlStatus = (FlStatus)Enum.Parse(typeof(FlStatus), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].FlStatus == enterFlStatus)
                            {
                                FlStatus newFlStatus = ChooseFlStatusArrival();

                                var temp = departuresList.ToArray()[i];
                                temp.FlStatus = newFlStatus;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Enter Gate ");
                        Gate enterGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());

                        notFind = true;
                        for (int i = 0; i < departuresList.Count; i++)
                        {
                            if (departuresList[i].Gate == enterGate)
                            {
                                Gate newGate = ChooseGate();

                                var temp = departuresList.ToArray()[i];
                                temp.Gate = newGate;

                                departuresList.RemoveAt(i);
                                departuresList.Insert(i, temp);

                                ShowOneDepartures(departuresList, i);
                                notFind = false;
                            }
                            if (notFind)
                            {
                                Console.WriteLine("Flights meet these criteria are not found");
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                Emergency();
            }
        }
        //method for find nearest flights
        static void FindNearestArrival(List<Arrival> arrivalList)
        {
            bool noFind = true;
            for (int i = 0; i < arrivalList.Count; i++)
            {
                if (arrivalList[i].Time >= DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0)) && arrivalList[i].Time <= DateTime.Now.AddHours(1))
                {
                    ShowOneArrival(arrivalList, i);
                    noFind = false;
                }
            }

            if (noFind)
            {
                Console.WriteLine("No closest flights");
            }
        }

        static void FindNearestDepartures(List<Departures> departuresList)
        {
            bool noFind = true;
            for (int i = 0; i < departuresList.Count; i++)
            {
                if (departuresList[i].Time <= DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0)) && departuresList[i].Time >= DateTime.Now.AddHours(1))
                {
                    ShowOneDepartures(departuresList, i);
                }
            }
            if (noFind)
            {
                Console.WriteLine("No closest flights");
            }
        }
    }
}