using System;

/*
ΠΑΝΑΓΙΩΤΗΣ ΠΡΑΤΤΗΣ Π15120 Εργασία 1
δημιουργεία προγράμματος που υλοποιεί τον υπολογισμό του 
παραγοντικού με χρήση των while, for και do-while loops
*/

namespace firstexercise
{
	class factorial
	{
		
		static void Main(string[] args)
		{
			//στην μέθοδο Main δημιουργω τα αντικείμενα των άλλων τάξεων ώστε 
			//για 3 διαφορετικές τιμές να υπολογιστεί το παραγοντικό 
			long num1;
			long num2;
			long num3;
			//αρχικά για κάθε τιμή καλώ την συνάρτηση validate 
			//της τάξης userinputvalidation ώστε να ειναι έγκυρη η τιμή
			//και μετά καλώ τις συναρτήσεις calculate για το κάθε είδος επανάληψης
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
			//Σε αυτο το πρόγραμμα χρησιμοποιώ integer τύπου Int64 δηλαδή long ώστε να μπορεί
			//το πρόγραμμα να υπολογίζει όσο το δυνατόν μεγαλύτερα παραγοντικά
			//αν το factorial είναι πέρα από τα όρια το αποτέλεσμα βγαίνει 0
			
			//αν χρησιμοποιούσα double θα υπολογίζονταν τα παραγοντικά και πιο μεγάλων αριθμών
			//όμως το παραγοντικό έχει νόημα μόνο για φυσικούς-integers και όχι και για πραγματικούς-double
			public long validate()
			{
				
				//θα χρειαστώ έναν integer για να κάνω την σύγκριση και τον έλεγχο αν μετατρέπεται
				//το input σε long, αν όχι τότε ξαναζητάω από τον χρήστη να δώσει αριθμό
				Console.WriteLine("Give a number to calculate its factorial");
				long parsedValue, n=0;
				bool condition = false;
				while(condition==false)
				{
					//αρχικά με την μέθοδο TryPrse ελέγχουμε αν μπορεί το input του χρήστη
					//να μετατραπεί σε integer και μετά έλεγχος να μην είναι αρνητικός
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
	//παραγοντικό τύπος : n! = 1*2*...*(n-1)*n , n>=0 με 0!=1
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
				//η διαφορά με τα άλλα loops εδώ είναι οτι αν δώσει ο χρήστης 0 δεν θα γίνει αρχικά
				//έλεγχος και το παραγοντικό θα βγει 0 που ειναι λάθος
				//επιλέγω λοιπόν να κάνω αρχικά έλεγχο και για το 0 και για το 1 που έχουν ίδιο αποτέλεσμα
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