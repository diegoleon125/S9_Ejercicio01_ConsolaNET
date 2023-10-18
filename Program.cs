using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S9_Ejercicio01_ConsolaNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lim_vend = 0;
            int lim_devuel = 0;
            float lim_caja = 0f;
            int abr_vend = 0;
            int abr_devuel = 0;
            float abr_caja = 0f;
            int gol_vend = 0;
            int gol_devuel = 0;
            float gol_caja = 0f;
            int ele_vend = 0;
            int ele_devuel = 0;
            float ele_caja = 0f;
            string objeto = "";
            int opcion;
            bool INICIO = true;
            while (INICIO)
            {
                //INICIO
                PantallaInicio(); //PARTE_01
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1://REGISTRAR VENTA
                        bool REGISTRARVENTA = true;
                        while (REGISTRARVENTA)
                        {
                            PantallaRegistrar("Venta"); //PARTE_02
                            opcion = int.Parse(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1: objeto = "Limpieza"; break;
                                case 2: objeto = "Abarrotes"; break;
                                case 3: objeto = "Golosinas"; break;
                                case 4: objeto = "Electrónicos"; break;
                                case 5: REGISTRARVENTA = false; break;
                            }
                            if (opcion != 5)//VENTA OBJETO
                            {
                                bool VENTAOBJETO = true;
                                while (VENTAOBJETO)
                                {
                                    int cantidad = ObjetoCantidad(objeto, "Venta"); //PARTE_04
                                    float preciototal = ObjetoCaja(cantidad, "ingresado");
                                    switch (objeto)
                                    {
                                        case "Limpieza":
                                            lim_vend += cantidad;
                                            lim_caja += preciototal; break;
                                        case "Abarrotes":
                                            abr_vend += cantidad;
                                            abr_caja += preciototal; break;
                                        case "Golosinas":
                                            gol_vend += cantidad;
                                            gol_caja += preciototal; break;
                                        case "Electrónicos":
                                            ele_vend += cantidad;
                                            ele_caja += preciototal; break;
                                    }
                                    opcion = int.Parse(Console.ReadLine());
                                    if (opcion == 2)
                                    {
                                        VENTAOBJETO = false;
                                    }
                                }
                            }
                        }
                        break;
                    case 2://REGISTRAR DEVOLUCION
                        bool REGISTRARDEVOLUCION = true;
                        while (REGISTRARDEVOLUCION)
                        {
                            PantallaRegistrar("Devolución"); //PARTE_03
                            opcion = int.Parse(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1: objeto = "Limpieza"; break;
                                case 2: objeto = "Abarrotes"; break;
                                case 3: objeto = "Golosinas"; break;
                                case 4: objeto = "Electrónicos"; break;
                                case 5: REGISTRARDEVOLUCION = false; break;
                            }
                            if (opcion != 5)//DEVOLUCION OBJETO
                            {
                                bool DEVOLUCIONOBJETO = true;
                                while (DEVOLUCIONOBJETO)
                                {
                                    int cantidad = ObjetoCantidad(objeto, "Devolución"); //PARTE_04
                                    float preciototal = ObjetoCaja(cantidad, "devuelto");
                                    switch (objeto)
                                    {
                                        case "Limpieza":
                                            lim_devuel += cantidad;
                                            lim_caja -= preciototal; break;
                                        case "Abarrotes":
                                            abr_devuel += cantidad;
                                            abr_caja -= preciototal; break;
                                        case "Golosinas":
                                            gol_devuel += cantidad;
                                            gol_caja -= preciototal; break;
                                        case "Electrónicos":
                                            ele_devuel += cantidad;
                                            ele_caja -= preciototal; break;
                                    }
                                    opcion = int.Parse(Console.ReadLine());
                                    if (opcion == 2)
                                    {
                                        DEVOLUCIONOBJETO = false;
                                    }
                                }
                            }
                        }
                        break;
                    case 3: INICIO = false; break;
                }
            }
            Console.Clear(); //PARTE_05
            Console.Write("================================\r\n" +
                "Tienda de Don Lucas\r\n" +
                "================================\r\n" +
                "1: Registrar venta\r\n" +
                "2: Registrar devolución\r\n" +
                "3: Cerrar Caja\r\n" +
                "================================\r\n" +
                "Cerrando Caja\r\n" +
                "================================\r\n" +
                "Totales\r\n" +
                "================================\r\n");
            ObjetoTOTAL("Limpieza ", lim_vend, lim_devuel, lim_caja);
            ObjetoTOTAL("Abarrotes", abr_vend, abr_devuel, abr_caja);
            ObjetoTOTAL("Golosinas", gol_vend, gol_devuel, gol_caja);
            ObjetoTOTAL("Electro  ", ele_vend, ele_devuel, ele_vend);
            float caja_total = lim_caja + abr_caja + gol_caja + ele_caja;
            Console.Write("Queda en caja " + caja_total.ToString("C"));
            Console.ReadKey();
        }
        private static void PantallaInicio() //PARTE_01
        {
            Console.Clear();
            Console.Write("================================\r\n" +
                "Tienda de Don Lucas\r\n" +
                "================================\r\n" +
                "1: Registrar venta\r\n" +
                "2: Registrar devolución\r\n" +
                "3: Cerrar Caja\r\n" +
                "================================\r\n" +
                "Ingrese una opción: ");
        }
        private static void PantallaRegistrar(string txt) //PARTE_02, PARTE_03
        {
            Console.Clear();
            Console.Write("================================\r\n" +
                "Registrar " + txt +" de:\r\n" +
                "================================\r\n" +
                "1: Limpieza\r\n" +
                "2: Abarrotes\r\n" +
                "3: Golosinas\r\n" +
                "4: Electrónicos\r\n" +
                "5: <- Regresar\r\n" +
                "================================\r\n" +
                "Ingrese una opción: ");
        }
        private static int ObjetoCantidad(string objeto, string txt) //PARTE_04_1
        {
            Console.Clear();
            Console.Write("================================\r\n" +
                "Registrar " + txt + " de " + objeto + "\r\n" +
                "================================\r\n" +
                "Ingrese cantidad (unidades): ");
            return int.Parse(Console.ReadLine());
            
        }
        private static float ObjetoCaja(int cantidad, string txt) //PARTE_04_2
        {
            Console.Write("Ingrese precio: S/ ");
            float precio = float.Parse(Console.ReadLine());
            float preciototal = cantidad * precio;
            string txtpreciototal = preciototal.ToString("C");

            Console.Write("================================\r\n" +
                "Se han "+ txt + " " + cantidad + " unidades\r\n" +
                "Se han " + txt + " " + txtpreciototal + " en caja\r\n" +
                "================================\r\n" +
                "1: Registrar más productos de limpieza\r\n" +
                "2: <- Regresar\r\n" +
                "================================\r\n" +
                "Ingrese una opción: ");
            return preciototal;
        }
        private static void ObjetoTOTAL(string obj, int vendido, int devuelto, float caja)
        {
            Console.Write("\t" + "|\t".PadLeft(5, ' ') + vendido + " vendidos\r\n");
            Console.Write(obj + "|\t".PadLeft(4, ' ') + devuelto + " devueltos\r\n");
            Console.Write("\t" + "|\t".PadLeft(5, ' ') + (vendido - devuelto) + " en total\r\n");
            Console.Write("\t" + "|\t".PadLeft(5, ' ') + caja.ToString("C") + " en caja\r\n");
            Console.Write("================================\r\n");

        }
    }
}