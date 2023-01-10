using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR.Utilities
{
    public  class DataSource
    {

        public static object[] ValidLoginTest()
        {
            string[] dataset1 = new string[2];
            dataset1[0] = "admin";
            dataset1[1] = "pass";
         
            object[] allData = new object[1];
            allData[0] = dataset1;
            return allData;
        }





        public static object[] InvalidLoginTest()
        {
            string[] dataset1 = new string[3];
            dataset1[0] = "Saul";
            dataset1[1] = "pass123";
            dataset1[2] = "Invalid username ";


            string[] dataset2 = new string[3];
            dataset2[0] = "John";
            dataset2[1] = "pass123";
            dataset2[2] = "Invalid username ";

            object[] allData= new object[2];
            allData[0] = dataset1;
            allData[1] = dataset2;
            return allData;
        }
        public static object[] ValidPatientDataTest()
        {
            string[] dataset1 = new string[6];
            dataset1[0] = "admin";
            dataset1[1] = "pass";
            dataset1[2] = "john";
            dataset1[3] = "w";
            dataset1[4] = "wick";
            dataset1[5] = "john wick";




            string[] dataset2 = new string[6];
            dataset2[0] = "admin";
            dataset2[1] = "pass";
            dataset2[2] = "saul";
            dataset2[3] = "g";
            dataset2[4] = "goodman";
            dataset2[5] = "saul goodman";



            object[] allDataSet = new object[2];
            allDataSet[0] = dataset1;
            allDataSet[1] = dataset2;

            return allDataSet;

        }
        public static object[] InvalidLogindata2()
        {
            object[] data = ExcelUtils.GetSheetIntoObjectArray(@"C:\Users\omkarj\Desktop\C# Project\AutomationProject1\OpenEMR\TestData\openemr_data.xlsx", "InvalidLoginTest");
            return data;

        }

        public static object[] ValidPatientData1()
        {
            object[] data = ExcelUtils.GetSheetIntoObjectArray(@"C:\\Users\\omkarj\\Desktop\\C# Project\\AutomationProject1\\OpenEMR\\TestData\\openemr_data.xlsx", "AddValidPatientTest");

            return data;

        }
    }
}
