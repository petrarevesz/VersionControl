﻿using IRF_GYAK7.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_GYAK7
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234); 

        public Form1()
        {
            InitializeComponent();

            List<Person> Population = new List<Person>();
            List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
            List<DeathProbability> DeathProbabilities = new List<DeathProbability>();


            Population = GetPopulation(@"C:\Temp\nép.csv");
            //    BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            //  DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

           

        }
        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }






    }
}
