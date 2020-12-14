using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class Passport
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ECL { get; set; }
        public string _ecl
        {
            get => _ecl;
            set
            {
                if (value == "amb" || value == "blu" || value == "brn" || value == "gry" || value == "grn" || value == "hzl" || value == "oth")
                {
                    ECL = value;
                }
            }
        }


        [Required(AllowEmptyStrings = false)]
        public string PID { get; set; }
        public string _pid
        {
            get => _pid;
            set
            {
                if (value.Length == 9)
                {
                    PID = value;
                }
            }
        }


        [Required]
        [Range(2020, 2030)]
        public int? EYR { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string HCL { get; set; }
        public string _hcl
        {
            get => _hcl;
            set
            {
                if (value.StartsWith("#") && value.Length == 7)
                {
                    var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                    if (regexItem.IsMatch(value.Remove(0)))
                    {
                        HCL = value;
                    }

                }
            }
        }


        [Required]
        [Range(1920, 2002)]
        public int? BYR { get; set; }


        [Required]
        [Range(2010, 2020)]
        public int? IYR { get; set; }


        //[Required]
        public int? CID { get; set; }


        [Required(AllowEmptyStrings = false)]
        public string HGT { get; set; }
        public string _hgt
        {
            get => _hgt;
            set
            {
                if (value.EndsWith("cm"))
                {
                    int number;
                    int.TryParse(value.Remove(value.Length - 2), out number);
                    if (number >= 150 && number <= 193)
                    {
                        HGT = value;
                    }
                }
                else if (value.EndsWith("in"))
                {
                    int number;
                    int.TryParse(value.Remove(value.Length - 2), out number);
                    if (number >= 59 && number <= 76)
                    {
                        HGT = value;
                    }
                }
            }
        }


        public Passport(int id, string ecl, string pid, int? eyr, string hcl, int? byr, int? iyr, int? cid, string hgt)
        {
            ID = id;
            _ecl = ecl;
            _pid = pid;
            EYR = eyr;
            _hcl = hcl;
            BYR = byr;
            IYR = iyr;
            CID = cid;
            _hgt = hgt;
        }
        //public bool IsValid()
        //{

        //}
    }
}
