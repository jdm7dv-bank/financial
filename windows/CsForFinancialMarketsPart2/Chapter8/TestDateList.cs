//Author: Andrea Germani
//** Example 1- 5 2005
//** 14 Jun09 check and improv example 1-5, new example 6-8
//** 17 Sep09 check example 1
//** 19 Sep09 Example 9

using System;
using System.Collections.Generic;
using System.Text;



class Program
{
    static void Main(string[] args)
    {
        //Please uncomment the example you want to run.

        //TestDateList.Example1();
        //TestDateList.Example2();
        //TestDateList.Example3();
        //TestDateList.Example4();
        //TestDateList.Example5();
        //TestDateList.Example6();
        //TestDateList.Example7();
        //TestDateList.Example8();
        //TestDateList.Example9();
        //TestDateList.Example10();
    }
}

    public static class TestDateList
    {

        // Testing Date and DateList
        public static void Example1()
        {

            //Example 1: year fraction

            //Year Fraction shorter then a year
            Date startDate = new Date(2006, 3, 2);
            Date endDate = new Date(2006, 5, 12);
            Console.WriteLine("StartDate:{0:D},\tEndDate:{1:D}", startDate.DateValue,endDate.DateValue);
            Console.WriteLine("YearFraction Act/Act: " + startDate.YF_AA(endDate));
            Console.WriteLine("YearFraction Act/360: " + startDate.YF_MM(endDate));
            Console.WriteLine("YearFraction 30/360: " + startDate.YF_30_360(endDate));
            Console.WriteLine("YearFraction Act/365: " + startDate.YF_365(endDate));
            Console.WriteLine("YearFraction Act/365.25: " + startDate.YF_365_25(endDate));

            Console.WriteLine("***********");

            //Year Fraction one year tenor
            Date startDate_1 = new Date(2009, 3, 2);
            Date endDate_1 = new Date(2010, 3, 2);
            Console.WriteLine("StartDate:{0:D},\tEndDate:{1:D}", startDate_1.DateValue, endDate_1.DateValue);
            Console.WriteLine("YearFraction Act/Act: " + startDate_1.YF_AA(endDate_1));
            Console.WriteLine("YearFraction Act/360: " + startDate_1.YF_MM(endDate_1));
            Console.WriteLine("YearFraction 30/360: " + startDate_1.YF_30_360(endDate_1));
            Console.WriteLine("YearFraction Act/365: " + startDate_1.YF_365(endDate_1));
            Console.WriteLine("YearFraction Act/365.25: " + startDate_1.YF_365_25(endDate_1));
            Console.WriteLine("***********");


            // 30/360
            Date startDate_3 = new Date(2007, 1, 15);
            Date endDate_3 = new Date(2007, 1, 31);
            Console.WriteLine("StartDate:{0:D},\tEndDate:{1:D}", startDate_3.DateValue, endDate_3.DateValue);
            Console.WriteLine("Days 30/360: " + startDate_3.D_30_360(endDate_3));
            Console.WriteLine("Days 30E/360: " + startDate_3.D_30_360(endDate_3));
            Console.WriteLine("Days 30E/360 ISDA: " + startDate_3.D_30_360E_ISDA(endDate_3));
            
            Date startDate_4 = new Date(2007, 2, 14);
            Date endDate_4 = new Date(2007, 2, 28);
            Console.WriteLine("StartDate:{0:D},\tEndDate:{1:D}", startDate_4.DateValue, endDate_4.DateValue);
            Console.WriteLine("Days 30/360: " + startDate_4.D_30_360(endDate_4));
            Console.WriteLine("Days 30E/360: " + startDate_4.D_30_360E(endDate_4));
            Console.WriteLine("Days 30E/360 ISDA: " + startDate_4.D_30_360E_ISDA(endDate_4));
            Console.WriteLine("***********");

        }
        
        public static void Example2()
        {
            //Example 2: Constructors:checking different constructors
            Date date1 = new Date();
            Console.WriteLine("Constructor: = new Date(), Output: {0:D}",date1.DateValue);
            Date date2 = new Date(2006, 5, 15);
            Console.WriteLine("Constructor: = new Date(2006,5,15), Output: {0:D}",date2.DateValue);
            Date date3 = new Date(new DateTime());
            Console.WriteLine("Constructor: = new Date(new DateTime()), Output: {0:D}",date3.DateValue);
            Date date4 = new Date(38852);
            Console.WriteLine("Constructor: = new new Date(38852), Output: {0:D}",date4.DateValue);

        }
        
        public static void Example3()
        {
            //Example 3
            Date date1 = new Date(2006, 5, 15);
            Date date2 = new Date(date1);
            Console.WriteLine("Using CopyConstructor: 'Date date2 = new Date(date1)' ");
            Console.WriteLine("Date1: {0:D}" ,date1.DateValue);
            Console.WriteLine("Date2: {0:D}" , date2.DateValue);
            date2.SerialValue = 38853;
            Console.WriteLine("After changing Date2, the value of Date1 is: {0:D}",date1.DateValue);
            Console.WriteLine("After changing Date2, the value of Date2 is: {0:D}" ,date2.DateValue);
            Console.WriteLine();
            Date date3 = date1;
            
            Console.WriteLine("Using =  'Date date3 = date1' ");
            Console.WriteLine("Date1: {0:D}" ,date1.DateValue);
            Console.WriteLine("Date3: {0:D}", date3.DateValue);
            date1.SerialValue = 38851;
            Console.WriteLine("After changing Date1, the value of Date1 is: {0:D}" ,date1.DateValue);
            Console.WriteLine("After changing Date1, the value of Date3 is: {0:D}" ,date3.DateValue);
            Console.WriteLine();
            Console.WriteLine("Using properties: ");
            Console.WriteLine("Date1 get value: {0:D}",date1.DateValue);
            Console.WriteLine("Date1 get serial number: {0}" ,date1.SerialValue);
            date1.DateValue = date2.DateValue;
            Console.WriteLine("After setting Date1.Value = Date2.Value, Date1.value is: {0:D}",date1.DateValue);
            date1.SerialValue = 38860;
            Console.WriteLine("After setting Date1.SerialValue = 38860, Date1.value is: {0:D}" ,date3.DateValue);
        }
        
        public static void Example4()
        {
            //Example 4: Modified Following
            Date date1 = new Date(2009, 6, 13);            
            Console.WriteLine("my date1 is :{0:D} ", date1.DateValue);
            Console.WriteLine("my date1.mod_foll() is : {0:D} ", date1.mod_foll().DateValue);
            
            Console.WriteLine();

            Date date2 = new Date(2009, 6, 18);
            Console.WriteLine("my date2 is :{0:D} ", date2.DateValue);
            Console.WriteLine("my date2.mod_foll() is : {0:D} ", date2.mod_foll().DateValue);              }
        
        public static void Example5() 
        {
            //Calculating difference in days according differente conv.
            Date startDate = new Date(2012, 2, 15);
            Date endDate = new Date(2012, 8, 15);
            Console.WriteLine("StartDate:{0:D},\tEndDate:{1:D}", startDate.DateValue, endDate.DateValue);           
            Console.WriteLine("Number of days according Act/360: " + startDate.D_MM(endDate));
            Console.WriteLine("Number of days according 30/360: " + startDate.D_30_360(endDate));

            Console.WriteLine();

            Date date1 = new Date(2009,6,11);
            
            //Adding working date, actutal days in a period
            Console.WriteLine("Date1 is : {0:D}", date1.DateValue);
            Console.WriteLine("Date1 + 1 working days : {0:D}, actual days between: {1}", date1.add_workdays(1).DateValue,
                 date1.D_EFF(date1.add_workdays(1)));
            Console.WriteLine("Date1 + 2 working days : {0:D}, actual days between: {1}", date1.add_workdays(2).DateValue, 
                date1.D_EFF(date1.add_workdays(2)));
            Console.WriteLine("Date1 + 3 working days : {0:D}, actual days between: {1}", date1.add_workdays(3).DateValue,
                date1.D_EFF(date1.add_workdays(3)));
                        
            // Adding periods
            Console.WriteLine("Date1 + 2 days : {0:D}", date1.add_period_string("2d", 0).DateValue);
            Console.WriteLine("Date1 + 4 months : {0:D}", date1.add_period_string("4m",0).DateValue);
            Console.WriteLine("Date1 + 4 months mod foll: {0:D}", date1.add_period_string("4m", 1).DateValue);
            Console.WriteLine("Date1 + 7 years : {0:D}", date1.add_period_string("7y", 0).DateValue);

           




           
        }
        
        public static void Example6() 
        {

            //Test different constructors

            DateList myDL_1 = new DateList(new Date(2009, 8, 3), new Date(2011, 8, 3), 2, 1);
            Console.WriteLine("new DateList(new Date(2009, 8, 3), new Date(2011, 8, 3), 2, 1");
            myDL_1.PrintVectDateList();
            Console.WriteLine();

            DateList myDL_2 = new DateList(new Date(2009, 8, 3).DateValue, new Date(2011, 8, 3).DateValue,2, 1,1,0,-2);
            Console.WriteLine("new DateList(new Date(2009, 8, 3).DateValue, new Date(2011, 8, 3).DateValue,2, 1,1,0,-2)");
            myDL_2.PrintVectDateList();
            Console.WriteLine();

            
            DateList myDL_3 = new DateList(new Date(2009, 8, 3).SerialValue, new Date(2011, 8, 3).SerialValue, 2, 1, 1, 0, -2);
            Console.WriteLine("new DateList(new Date(2009, 8, 3).SerialValue, new Date(2011, 8, 3).SerialValue, 2, 1, 1, 0, -2)");
            myDL_3.PrintVectDateList();
            Console.WriteLine();

            DateList myDL_4 = new DateList(myDL_1);
            Console.WriteLine("new DateList(myDL_1)");
            myDL_4.PrintVectDateList();
            Console.WriteLine();

            
        
        }

        public static void Example7() 
        {
            //testing each dataList arguments
            // in general the output of dataList is a matrix of dates, for schedulate payments period, each rows is a period
            // for columns:
            //1° column fixing date
            //2° column startingDate of period
            //3° column endDate of period
            //4° column payment date of period


            DateTime startDate = new Date(2009, 8, 3).DateValue;
            DateTime endDate = new Date(2014, 10, 3).DateValue;
            int adjusted = 1;
            int paymentPerYear = 2;
            int arrears = 0;
            int fixingDays = -2;            
            int shortPeriod = 1;

            DateList myDL_1 = new DateList(startDate,endDate,paymentPerYear,shortPeriod,adjusted,arrears,fixingDays);
            Console.WriteLine("Starting DataList");
            myDL_1.PrintVectDateList();
            Console.WriteLine();

            adjusted = 0;
            DateList myDL_2 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("adjusted = 0, 3°column can be Sat or Sund");
            myDL_2.PrintVectDateList();
            Console.WriteLine();

            paymentPerYear = 1;
            DateList myDL_3 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("paymentPerYear = 1, frequency of payment changed");
            myDL_3.PrintVectDateList();
            Console.WriteLine();

            arrears = 1;
            DateList myDL_4 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("arrears = 1, 1° column count fixing date starting from 3° column and not from 2° column");
            myDL_4.PrintVectDateList();
            Console.WriteLine();

            fixingDays = 0;
            DateList myDL_5 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("fixingDays = 0, 1° column has a different leg");
            myDL_5.PrintVectDateList();
            Console.WriteLine();

            shortPeriod = 2;
            DateList myDL_6 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("shortPeriod = 2, changed the short periud");
            myDL_6.PrintVectDateList();
            Console.WriteLine();

        }
        
        public static void Example8() 
        {
            //testing dataList read only properties

            DateTime startDate = new Date(2009, 8, 3).DateValue;
            DateTime endDate = new Date(2014, 10, 3).DateValue;
            int adjusted = 1;
            int paymentPerYear = 2;
            int arrears = 0;
            int fixingDays = -2;
            int shortPeriod = 1;

            DateList myDL_1 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);
            Console.WriteLine("public Date[,] GetDateList");
            myDL_1.PrintMatrix(myDL_1.GetDateList);
            Console.WriteLine();
            Console.WriteLine("double[,] GetDateListSerial");
            myDL_1.PrintMatrix(myDL_1.GetDateListSerial);
            Console.WriteLine();
            Console.WriteLine("public Date[,] GetShortDateList");
            myDL_1.PrintMatrix(myDL_1.GetShortDateList);
            Console.WriteLine();
            Console.WriteLine("public Date[] GetSimpleArray");
            myDL_1.PrintVect(myDL_1.GetSimpleArray);
            Console.WriteLine();
            Console.WriteLine("count numbers of rows: public int Length " + myDL_1.Length);
           
        }

        public static void Example9()
        {
            // Testing different version of 30/360 and 30E/360 according ISDA definition 
            // http://www.isda.org/c_and_a/docs/30-360-2006ISDADefs.xls
            // you can check data in sheet "Comparison"
            Date TerminationDate = new Date(2009, 2, 28);
            Array <Date> StartDates= new Array <Date>(23,1);
            Array<Date> EndDates = new Array<Date>(23, 1);
            StartDates[1] = new Date(2007, 1, 15); EndDates[1] = new Date(2007, 1, 30);
            StartDates[2] = new Date(2007, 1, 15); EndDates[2] = new Date(2007, 2, 15);
            StartDates[3] = new Date(2007, 1, 15); EndDates[3] = new Date(2007, 7, 15);
            StartDates[4] = new Date(2007, 9, 30); EndDates[4] = new Date(2008, 3, 31);
            StartDates[5] = new Date(2007, 9, 30); EndDates[5] = new Date(2007, 10, 31);
            StartDates[6] = new Date(2007, 9, 30); EndDates[6] = new Date(2008, 9, 30);
            StartDates[7] = new Date(2007, 1, 15); EndDates[7] = new Date(2007, 1, 31);
            StartDates[8] = new Date(2007, 1, 31); EndDates[8] = new Date(2007, 2, 28);
            StartDates[9] = new Date(2007, 2, 28); EndDates[9] = new Date(2007, 3, 31);
            StartDates[10] = new Date(2006, 8, 31); EndDates[10] = new Date(2007, 2, 28);
            StartDates[11] = new Date(2007, 2, 28); EndDates[11] = new Date(2007, 8, 31);            
            StartDates[12] = new Date(2007, 2, 14); EndDates[12] = new Date(2007, 2, 28);
            StartDates[13] = new Date(2007, 2, 26); EndDates[13] = new Date(2008, 2, 29);
            StartDates[14] = new Date(2008, 2, 29); EndDates[14] = new Date(2009, 2, 28);
            StartDates[15] = new Date(2008, 2, 29); EndDates[15] = new Date(2008, 3, 30);
            StartDates[16] = new Date(2008, 2, 29); EndDates[16] = new Date(2008, 3, 31);
            StartDates[17] = new Date(2007, 2, 28); EndDates[17] = new Date(2007, 3, 5);
            StartDates[18] = new Date(2007, 10, 31); EndDates[18] = new Date(2007, 11, 28);
            StartDates[19] = new Date(2007, 8, 31); EndDates[19] = new Date(2008, 2, 29);
            StartDates[20] = new Date(2008, 2, 29); EndDates[20] = new Date(2008, 8, 31);
            StartDates[21] = new Date(2008, 8, 31); EndDates[21] = new Date(2009, 2, 28);
            StartDates[22] = new Date(2009, 2, 28); EndDates[22] = new Date(2009, 8, 31);



            Console.WriteLine("Number of days:");
            for (int i = 1; i < 23; i++)
            {
                Console.WriteLine("{0:d},\t{1:d},\t{2},\t{3},\t{4},\t{5}", StartDates[i].DateValue, EndDates[i].DateValue,
                     StartDates[i].D_30_360(EndDates[i]), StartDates[i].D_30_360E(EndDates[i]), StartDates[i].D_30_360E_ISDA(EndDates[i],TerminationDate),
                StartDates[i].D_EFF(EndDates[i]));
            }

            Console.WriteLine("\n{0}","Year Fraction:");
            for (int i = 1; i < 23; i++)
            {
                Console.WriteLine("{0:d},\t{1:d},\t{2:F4},\t{3:F4},\t{4:F4},\t{5:F4}", StartDates[i].DateValue, EndDates[i].DateValue,
                     StartDates[i].YF_30_360(EndDates[i]), StartDates[i].YF_30_360E(EndDates[i]), StartDates[i].YF_30_360E_ISDA(EndDates[i], TerminationDate),
                StartDates[i].YF_MM(EndDates[i]));
            }

        }


        public static void Example10()
        {
            //This example create a dateList, create a NumericMatrix<double> with serial date and a NumericMatrix<Date>
            // of Date. Finally print associative matrices in Excel

            //input for my datelist
            DateTime startDate = new Date(2009, 8, 3).DateValue;
            DateTime endDate = new Date(2014, 10, 3).DateValue;
            int adjusted = 1;
            int paymentPerYear = 2;
            int arrears = 0;
            int fixingDays = -2;
            int shortPeriod = 1;

            //my dateList
            DateList myDL_1 = new DateList(startDate, endDate, paymentPerYear, shortPeriod, adjusted, arrears, fixingDays);

            //iniziating  a NumericMatrix<double> Class form my dates
            NumericMatrix<double> myDates = myDL_1.GetMatrixSerial;

            //i can also use a NumericMatrix<Data> to keep the output as Data
            NumericMatrix<Date> myDatesData = myDL_1.GetMatrixData;

            //checking Data output
            Console.WriteLine(myDatesData[1, 1].DateValue);


            //I create an associative matrix AssocMatrix
            // with "header" label for columns and "n_lines" for rows

            //Label for columns
            Set<string> header = new Set<string>();
            header.Insert("FixingDate");
            header.Insert("StartDate");
            header.Insert("EndDate");
            header.Insert("PaymentDate");

            //Label for rows
            Set<string> n_line = new Set<string>();

            for (int i = 0; i < myDates.MaxRowIndex +1; i++)
            {
                n_line.Insert("# "+ (i+1));
                
            }


            //Creating AssocMatrix            
            AssocMatrix<string,string, double> OutMatrix = new AssocMatrix<string,string, double>(n_line,header, myDates);

        
            // Print associative matrices in Excel, to "My Date List" sheet, the output will be in excel serial number format
            ExcelMechanisms exl = new ExcelMechanisms();
            exl.printAssocMatrixInExcel<string, string, double>(OutMatrix, "My Date List");
         

        }
    }



