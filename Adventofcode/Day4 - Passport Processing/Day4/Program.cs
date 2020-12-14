using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program nr = new Program();
            nr.CalculateValid();

        }

        private void CalculateValid()
        {
            var lines = File.ReadAllLines("input.txt");
            List<Passport> ValidPassports = new List<Passport>();
            List<Passport> NotValidPassports = new List<Passport>();
            int id = 0;


            string ecl = String.Empty;
            string pid = String.Empty;
            int? eyr = null;
            string hcl = String.Empty;
            int? byr = null;
            int? iyr = null;
            int? cid = null;
            string hgt = String.Empty;

            foreach (string item in lines)
            {
                string[] KeyValue = item.Split(':', ' ');
                for (int i = 0; i < KeyValue.Length; i++)
                {
                    int temp;
                    switch (KeyValue[i])
                    {
                        case "ecl":
                            ecl = KeyValue[i + 1];
                            break;
                        case "pid":
                            //int.TryParse(KeyValue[i + 1], out temp);
                            //pid = temp;
                            pid = KeyValue[i + 1];
                            break;
                        case "eyr":
                            int.TryParse(KeyValue[i + 1], out temp);
                            eyr = temp;
                            break;
                        case "hcl":
                            hcl = KeyValue[i + 1];
                            break;
                        case "byr":
                            int.TryParse(KeyValue[i + 1], out temp);
                            byr = temp;
                            break;
                        case "iyr":
                            int.TryParse(KeyValue[i + 1], out temp);
                            iyr = temp;
                            break;
                        case "cid":
                            int.TryParse(KeyValue[i + 1], out temp);
                            cid = temp;
                            break;
                        case "hgt":
                            hgt = KeyValue[i + 1];
                            break;
                        default:
                            break;
                    }
                }


                if (item == "")
                {
                    id++;
                    Passport newPass = new Passport(id, ecl, pid, eyr, hcl, byr, iyr, cid, hgt);
                    List<ValidationResult> validationResults = IsValidPass(newPass);

                    if (validationResults.Count != 0)
                    {
                        NotValidPassports.Add(newPass);
                            }
                    else
                    {
                        ValidPassports.Add(newPass);

                    }





                    ecl = String.Empty;
                    pid = String.Empty;
                    eyr = null;
                    hcl = String.Empty;
                    byr = null;
                    iyr = null;
                    cid = null;
                    hgt = String.Empty;
                }
                //Console.WriteLine(item);
            }
            id++;
            Passport finalPass = new Passport(id, ecl, pid, eyr, hcl, byr, iyr, cid, hgt);
            List<ValidationResult> validationResults2 = IsValidPass(finalPass);

            if (validationResults2.Count != 0)
            {
                NotValidPassports.Add(finalPass);
            }
            else
            {
                ValidPassports.Add(finalPass);

            }
            ecl = String.Empty;
            pid = String.Empty;
            eyr = null;
            hcl = String.Empty;
            byr = null;
            iyr = null;
            cid = null;
            hgt = String.Empty;

            Console.WriteLine("Not valid passwords: " + NotValidPassports.Count);          
            foreach (var item in NotValidPassports)
            {
                Console.WriteLine("\n ID: " + item.ID + "\n ECL: " + item.ECL + "\n PID: " + item.PID + "\n EYR: " + item.EYR + "\n HCL: " +
                    item.HCL + "\n BYR: " + item.BYR + "\n IYR: " + item.IYR
                    + "\n CID: " + item.CID + "\n HGT: " + item.HGT + "\n");
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Valid passwords: " + ValidPassports.Count);
            foreach (var item in ValidPassports)
            {
                Console.WriteLine("\n ID: " + item.ID + "\n ECL: " + item.ECL + "\n PID: " + item.PID + "\n EYR: " + item.EYR + "\n HCL: " +
                    item.HCL + "\n BYR: " + item.BYR + "\n IYR: " + item.IYR
                    + "\n CID: " + item.CID + "\n HGT: " + item.HGT + "\n");
            }
            Console.ReadKey();

        }
        public static List<ValidationResult> IsValidPass(Passport pass)
        {
            ValidationContext context = new ValidationContext(pass);
            List<ValidationResult> results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(pass, context, results, true);

            return results;
        }
    }

}
