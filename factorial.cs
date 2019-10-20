using System;

/*
Author Παναγιώτης Πράττης/Panagiotis Prattis
*/

namespace firstexercise
{
	class factorial
	{
		
		static void Main(string[] args)
		{
			//create objects of other classes
			//and three variables to calculate factorial
			//with three different ways
			long num1;
			long num2;
			long num3;
			//for each value I call the fanction validate
			//of the class userinputvalidation to check if value is valid
			userinputvalidation v = new userinputvalidation();
			Console.WriteLine("Let's calculate a factorial using the for loop");
			num1 = v.validate();
			
			forfactorial f = new forfactorial();
			f.forcalculate(num1);
			Console.WriteLine("Let's calculate a factorial using the while loop");
			num2 = v.validate();
			
			whilefactorial w = new whilefactorial();
			w.whilecalculate(num2);
			Console.WriteLine("Let's calculate a factorial using the do-while loop");
			
			num3 = v.validate();
			dofactorial d = new dofactorial();
			d.docalculate(num3);
				
			
			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
		
	}
	
	public class userinputvalidation
	{
			//I use integer type Int64 which is called long
			//in order to calculate bigger factorials 
			//if the result is bigger than the max long value, I output 0
			
			//I could use double to calculate even bigger factorials
			//but factorial concernsonly natural numbers / integers and not real numbers / double
			public long validate()
			{
				
				//I will need an integer to check and compare if input can be converted to long
				Console.WriteLine("Give a number to calculate its factorial");
				long parsedValue, n=0;
				bool condition = false;
				while(condition==false)
				{
					//with TryPrse check if input can be converted to long
					//and then if input is  not negative
					string input = Console.ReadLine();
					if (Int64.TryParse(input, out parsedValue) == true)
					{
						if (Convert.ToInt64(input) >= 0)
						{
							n = Convert.ToInt64(input);
							condition=true;
						}
						else if(Convert.ToInt64(input) < 0)
						{
							Console.WriteLine("Don't give a negative number");
						}	
					}	
					else if(Int64.TryParse(input, out parsedValue) == false)
					{
						Console.WriteLine("Give a number");
					}
							
				}
				return n;
			}
	}
	//factorial formula : n! = 1*2*...*(n-1)*n , with n>=0 and 0!=1
	public class forfactorial
	{
		public long forcalculate(long n)
		{
			long f=1;
				for(long i=1; i<=n; i++)
			{
				f*=i;
			}
			Console.WriteLine("The factorial using the for loop is "+ n +"! = "+ f);
			Console.WriteLine();
			return f;
		}
	}
	public class whilefactorial
	{
			public long whilecalculate(long n)
			{
				long f=1;
				long x = n;
				while(x>1)
				{
					f*=x;
					x--;
				}
				Console.WriteLine("The factorial using the while loop is "+ n +"! = "+ f);
				Console.WriteLine();
				return f;
			}
	}
	public class dofactorial
	{
			public long docalculate(long n)
			{
				long f=1;
				long x = n;
				if (n==1 || n ==0)
				{
					Console.WriteLine("The factorial using the do-while loop is "+ n +"! = 1");
					Console.WriteLine();
				}
				else
				{
					do
					{
						f*=x;
						x--;
					}while(x>1);
					Console.WriteLine("The factorial using the do-while loop is "+ n +"! = "+ f);
					Console.WriteLine();
				}	
				return f;
			}
	}
}
