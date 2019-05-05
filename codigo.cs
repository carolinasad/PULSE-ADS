using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text; 

namespace playHardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();

              //declarando a pulseira 
            Queue <double> minhaPulseira = new Queue <double>(); 
            Queue <double> futurasRecargas = new Queue <double>(); 


            Console.WriteLine("Projeto PlayHard Pulseira");
            Console.WriteLine("");
            Console.WriteLine("Saldos do Cliente:"); 
            pg.mostrarSaldo(minhaPulseira,futurasRecargas);
            Console.WriteLine("");
            Console.WriteLine("Realizando a Primeira Recarga");
            pg.adicionarCredito( 5.00 , minhaPulseira, futurasRecargas);
            pg.mostrarSaldo(minhaPulseira,futurasRecargas);

            Console.WriteLine("");
            Console.WriteLine("Realizando 4 recargas para ficar saldo na recargas futuras");
            pg.adicionarCredito( 5.00 , minhaPulseira, futurasRecargas);
            pg.adicionarCredito( 5.00 , minhaPulseira, futurasRecargas);
            pg.adicionarCredito( 5.00 , minhaPulseira, futurasRecargas);
            pg.adicionarCredito( 5.00 , minhaPulseira, futurasRecargas);
            
            pg.mostrarSaldo(minhaPulseira,futurasRecargas);

           
 
            Console.WriteLine("Simulando Cliente consumindo creditos da pulseira");
            pg.utilizarCredito(minhaPulseira, futurasRecargas);

            pg.mostrarSaldo(minhaPulseira,futurasRecargas);

            Console.ReadKey();
        }

        void adicionarCredito (double valor,Queue <double> minhaPulseira , Queue <double> futurasRecargas){
            if(minhaPulseira.Count < 3){
                  minhaPulseira.Enqueue(valor);
            }else {
                futurasRecargas.Enqueue(valor); 
            }
        }
        void mostrarSaldo(Queue <double> minhaPulseira , Queue <double> futurasRecargas){
            int contador1 =1;
            int contador2 = 1;
            double totalPulseira = 0; 
            double totalFuturasRecargas = 0; 



            if(minhaPulseira.Count>0){  
                Console.WriteLine("Pulseira:"); 
                foreach (double valor in minhaPulseira){
                    Console.WriteLine("bolsa "+ contador1 +": R$ "+valor);
                    totalPulseira += valor;
                    contador1 ++;
                }
            }else{
                Console.WriteLine("Sem Saldo na Pulseira");                
            }
            Console.WriteLine();
            if(futurasRecargas.Count>0){  
                Console.WriteLine("Conta Futuras Recargas:");
                foreach (double valor in futurasRecargas){
                    Console.WriteLine("bolsa "+ contador2 +": R$ "+valor);
                    totalFuturasRecargas +=valor; 
                    contador2++;
                }
            }else{
                Console.WriteLine("Sem Saldo futuros");                
            }
            Console.WriteLine();
        }
 
        void utilizarCredito (Queue <double> minhaPulseira , Queue <double> futurasRecargas){
            minhaPulseira.Dequeue();
            if(futurasRecargas.Count() > 0 ){
                double credito = futurasRecargas.Dequeue(); 
                minhaPulseira.Enqueue(credito);

            } 
           
        }


    }

}
