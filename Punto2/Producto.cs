using System;
namespace Productos{
    class Producto{
        private string nombre;
        private DateTime fechaVencimiento;
        private float precio; //entre 1000 y 5000
        private string tamanio;
        private string[] nombres = new string[]{
            "Galletas","Pepsi","Hamburguesas","Café","Salchichas"
        };
        private string[] tamanios = new string[]{
            "Grande","Chico","Mediano"
        };
        private Random r = new Random();
        public Producto(){
            this.nombre = nombres[r.Next(0,nombres.Length)];
            this.precio = r.Next(1000,5001);
            this.tamanio = tamanios[r.Next(0,tamanios.Length)];
            this.fechaVencimiento = NuevaFecha();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }

        public void MostrarDatos(){
            System.Console.WriteLine("Nombre del producto: {0}\nFecha de vencimiento: {1}\nPrecio: ${2}\nTamaño: {3}\n",this.Nombre,this.fechaVencimiento.ToString("dd-MM-yyyy"),this.precio,this.tamanio);
        }
        private DateTime NuevaFecha(){
            Random r = new Random();
            DateTime start = new DateTime(2022,1,1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }
    }
}