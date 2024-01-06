using System;
using System.Collections.Generic;

namespace Flight
{
    class Person
    {
        public string Name;
        public int Birthday;
        public int Riddingcount;
        public static int counter = 0;
        public string role;
        
        public void printperson()
        {
            Console.Write("탑승번호: " + Riddingcount +", "+ role + ", 이름: " + Name + ", 생년: " + Birthday);
        }

    }
    class Employee : Person
    {
        private int company_number;
        public int Company_number
        {
            get { return company_number; }
            set 
            {
                if(value > 0)
                {
                    company_number = value;
                }
                else
                {
                    Console.WriteLine("0보다 큰 값을 입력하십시오.");
                    company_number = 0;
                }
                
            }
        }
        private int pay;
        private char last_rank;

        public int getPay() { return pay; }
        public char getLast_rank() { return last_rank; }

        public void setPayRank(char Last_rank)
        {
            if(Last_rank == 'S'|| Last_rank == 'A'|| Last_rank == 'B'|| Last_rank == 'C'|| Last_rank == 'D')
            {
                this.last_rank = Last_rank;
            }
            else
            {
                while(!(Last_rank == 'S' || Last_rank == 'A' || Last_rank == 'B' || Last_rank == 'C' || Last_rank == 'D'))
                {
                    Console.WriteLine("연말 평가는 S,A,B,C,D중 하나여야 합니다.");
                    Console.Write("연말평가:");
                    Last_rank = char.Parse(Console.ReadLine());
                }
                this.last_rank = Last_rank;
            }
        }
        public void setPayRank(int Pay)
        {
            if (Pay > 0)
            {
                this.pay = Pay;
            }
            else
            {
                while (Pay <= 0)
                {
                    Console.WriteLine("0보다 커야합니다.");
                    Console.Write("급여:");
                    Pay = int.Parse(Console.ReadLine());
                }
                this.pay = Pay;
            }
        }

        
        public void printemployee()
        {
            Console.Write(" 사번: "+company_number+", 급여: "+pay+", 연말평가: " +last_rank);
        }
    }
    class Pilot : Employee
    {
        public const int maxpilot = 2;
        public static int countpilot = 0;
        private int all_flight_long;
        public int All_flight_long
        {
            get { return all_flight_long; }
            set
            {
                if (value > 0)
                {
                    all_flight_long = value;
                }
                else
                {
                    Console.WriteLine("0보다 큰 값을 입력하십시오.");
                    all_flight_long = 0;
                }
            }
        }
        public int license_number;
        public Pilot()
        {
            Person.counter = counter + 1;
            this.Riddingcount = counter;
            countpilot++;
        }
        public void printpilot()
        {
            Console.WriteLine(" 총 비행거리:" + all_flight_long + "km 면허번호:" + license_number);
        }

    }
    class Attendant : Employee
    {
        public const int max_attendent = 3;
        public static int count_attendent = 0;
        private string service_class;
        public string Service_class
        {
            get { return service_class; }
            set
            {
                if(value == "First"||value == "Business" || value == "Economy")
                {
                    service_class = value;
                }
                else
                {

                    Console.WriteLine("First, Business, Economy 중에 하나를 입력해야합니다.");
                    service_class = null;
                }
            }
        }
        public char service_sector;
        public Attendant()
        {
            Person.counter = counter + 1;
            this.Riddingcount = counter;
            count_attendent++;
        }
        public void printattendent()
        {
            Console.WriteLine(" 서비스 클래스:" +service_class + " 서비스 구역:" + service_sector);
        }
    }
    class Passenger : Person
    {
        public const int max_passenger = 5;
        public static int count_passenger = 0;
        public int seat_num;
        public int all_mailisy;
        public Passenger()
        {
            Person.counter = counter + 1;
            this.Riddingcount = counter;
            count_passenger++;
        }
        public void printpassenger()
        {
            Console.WriteLine(" 좌석번호:" + seat_num + " 총마일리지:" + all_mailisy);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int get_num;
            
            List<Person> people = new List<Person>();
            people.Add(new Passenger() { Name = "김기김", role = "승객", Birthday = 980101, seat_num = 1, all_mailisy = 300 });
            people.Add(new Passenger() { Name = "남나나", role = "승객", Birthday = 980102, seat_num = 2, all_mailisy = 400 });
            people.Add(new Passenger() { Name = "담다다", role = "승객", Birthday = 980103, seat_num = 3, all_mailisy = 500 });
            people.Add(new Passenger() { Name = "람라라", role = "승객", Birthday = 980104, seat_num = 4, all_mailisy = 600 });
            people.Add(new Attendant() { Name = "밤바바", Birthday = 980105, Company_number = 10, role = "승무원", Service_class = "Business", service_sector = 'C' });
            people.Add(new Attendant() { Name = "사사사", Birthday = 980106, Company_number = 20, role = "승무원", Service_class = "First", service_sector = 'F' });
            people.Add(new Pilot() { Name = "라라라", Birthday = 980107, Company_number = 30, role = "파일럿", All_flight_long = 100, license_number = 32 });
            ((Employee)people[4]).setPayRank(100000);
            ((Employee)people[4]).setPayRank('A');
            ((Employee)people[5]).setPayRank(55000);
            ((Employee)people[5]).setPayRank('S');
            ((Employee)people[6]).setPayRank(200000);
            ((Employee)people[6]).setPayRank('C');
            while (true)
            {
                Console.WriteLine("1. 파일럿추가, 2.승무원추가, 3.승객추가, 4.현황 출력, 5.종료");
                get_num = int.Parse(Console.ReadLine());
                if (get_num == 1)
                {
                    if (Pilot.countpilot < Pilot.maxpilot)
                    {
                        Pilot pilot = new Pilot();
                        Console.Write("이름:");
                        pilot.Name = Console.ReadLine();
                        Console.Write("생년:");
                        pilot.Birthday = int.Parse(Console.ReadLine());
                        Console.Write("사번:");
                        pilot.Company_number = int.Parse(Console.ReadLine());
                        while (pilot.Company_number <= 0)
                        {
                            Console.Write("사번:");
                            pilot.Company_number = int.Parse(Console.ReadLine());
                        }
                        Console.Write("급여:");
                        pilot.setPayRank(int.Parse(Console.ReadLine()));
                        Console.Write("연말평가(S,A,B,C,D):");
                        pilot.setPayRank(char.Parse(Console.ReadLine()));
                        Console.Write("총 비행 거리(km):");
                        pilot.All_flight_long = int.Parse(Console.ReadLine());
                        while (pilot.All_flight_long <= 0)
                        {
                            Console.Write("총 비행 거리(km):");
                            pilot.All_flight_long = int.Parse(Console.ReadLine());
                        }
                        Console.Write("면허번호:");
                        pilot.license_number = int.Parse(Console.ReadLine());
                        pilot.role = "파일럿";

                        people.Add(pilot);

                        Console.WriteLine("파일럿이 성공적으로 추가되었습니다");
                    }
                    else
                    {
                        Console.WriteLine("파일럿을 더이상 추가 할 수 없습니다.");
                    }

                }
                else if (get_num == 2)
                {
                    if(Attendant.count_attendent < Attendant.max_attendent)
                    {
                        Attendant attendant = new Attendant();
                        Console.Write("이름:");
                        attendant.Name = Console.ReadLine();
                        Console.Write("생년:");
                        attendant.Birthday = int.Parse(Console.ReadLine());
                        Console.Write("사번:");
                        attendant.Company_number = int.Parse(Console.ReadLine());
                        while (attendant.Company_number <= 0)
                        {
                            Console.Write("사번:");
                            attendant.Company_number = int.Parse(Console.ReadLine());
                        }
                        Console.Write("급여:");
                        attendant.setPayRank(int.Parse(Console.ReadLine()));
                        Console.Write("연말평가(S,A,B,C,D):");
                        attendant.setPayRank(char.Parse(Console.ReadLine()));
                        Console.Write("서비스 클래스:");
                        attendant.Service_class = Console.ReadLine();
                        while (!(attendant.Service_class == "First" || attendant.Service_class == "Business" || attendant.Service_class == "Economy"))
                        {
                            Console.Write("서비스 클래스:");
                            attendant.Service_class = Console.ReadLine();
                        }
                        Console.Write("서비스 구역:");
                        attendant.service_sector = char.Parse(Console.ReadLine());
                        attendant.role = "승무원";

                        people.Add(attendant);
                        Console.WriteLine("승무원이 성공적으로 추가되었습니다");
                    }
                    else
                    {
                        Console.WriteLine("승무원을 더이상 추가 할 수 없습니다.");
                    }
                }

                else if (get_num == 3)
                {
                    if (Passenger.count_passenger < Passenger.max_passenger)
                    {
                        Passenger passenger = new Passenger();
                        Console.Write("이름:");
                        passenger.Name = Console.ReadLine();
                        Console.Write("생년:");
                        passenger.Birthday = int.Parse(Console.ReadLine());
                        Console.Write("좌석번호:");
                        passenger.seat_num = int.Parse(Console.ReadLine());
                        Console.Write("총 마일리지:");
                        passenger.all_mailisy = int.Parse(Console.ReadLine());
                        passenger.role = "승객";
                        people.Add(passenger);
                        Console.WriteLine("승객이 성공적으로 추가되었습니다");
                    }
                    else
                    {
                        Console.WriteLine("승객을 더이상 추가 할 수 없습니다.");
                    }
                   
                }
                else if (get_num == 4)
                {
                    foreach(var item in people)
                    {
                        if(item is Pilot)
                        {
                            item.printperson();
                            ((Employee)item).printemployee();
                            ((Pilot)item).printpilot();
                        }
                    }
                    foreach (var item in people)
                    {
                        if (item is Attendant)
                        {
                            item.printperson();
                            ((Employee)item).printemployee();
                            ((Attendant)item).printattendent();
                        }
                    }
                    foreach (var item in people)
                    {
                        if (item is Passenger)
                        {
                            item.printperson();
                            ((Passenger)item).printpassenger();
                        }
                    }
                }
                else if (get_num == 5)
                {
                    Console.WriteLine("프로그램 종료");
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다 다시 입력하십시오.");
                }
            }
        }
    }
}
