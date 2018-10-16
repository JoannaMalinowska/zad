using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    class Neuron
    {
        int inputs;
        int set_number;
        double[,] Sets{ get; set; }
        int epochs;
        double[] Weights;
        double neuron_output;
        int iteration;
        double training_step;

        public void init()
        {
            neuron_output = 0;
            iteration = 0;
            training_step = 0.01;
            Console.WriteLine("How much inputs do You want?");
            inputs=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much training sets do You want?");
            set_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much epochs do You want?");
            double[,] sets = new double[set_number, inputs+1];
            double[] weights = new double[inputs];
            epochs = Convert.ToInt32(Console.ReadLine());
            Random randNum = new Random();
            for (int i = 0; i < set_number; i++)
            {
                for (int k = 0; k < inputs+1 ; k++)
                {
                    sets[i, k] = randNum.Next(-10, 10);
                }
            }
            for (int i = 0; i < inputs; i++)
            {
                weights[i] = randNum.Next(-10, 10);
            }
            this.Weights = weights;
            this.Sets = sets;
        }
        public void calc_weight()
        {
            double error = 0;
            while(iteration<epochs)
            {
                for(int i=0;i<set_number;i++)
                    {
                        for(int k=0; k<Weights.Length;k++)
                        {
                        neuron_output=(Weights[k]*Sets[i,k])+neuron_output;
                        }
                        for(int k=0; k<Weights.Length;k++)
                        {
                        Weights[k]=Weights[k]+training_step*(Sets[i,inputs]-neuron_output)*Sets[i,k];
                        }
                        neuron_output=0;
                    }
               iteration++;
            }
            for (int i = 0; i < set_number; i++)
            {
                for (int k = 0; k < Weights.Length; k++)
                {
                    neuron_output = (Weights[k] * Sets[i, k]) + neuron_output;
                }
                error = (training_step * (Sets[i, inputs] - neuron_output)) + error;
            }
            error = error / set_number;
            int p=1;
        }               
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Neuron neuronek = new Neuron();
            neuronek.init();
            neuronek.calc_weight();
        }
    }
}

