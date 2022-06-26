using System;
using Productos;
using System.Text.Json;
using System.Text.Json.Serialization;


string path =@"/home/alvaro/Documentos/Taller1/tallerGit/tp09-2022-SoriaAlvaro/Punto2/";
string productJSON = path+@"productos.json";
string miJSON = "";
var productosList = new Dictionary<string,Producto>();

int? op;
System.Console.WriteLine("1) Cargar productos\n2)Mostrar Productos.");
op = Convert.ToInt32(Console.ReadLine());

int cantP = 0;
if(op == 1){
    /* Si el archivo ya existe, lo desrializa y agrega nuevos productos */
    if(File.Exists(productJSON)){
        miJSON = File.ReadAllText(productJSON);
        productosList = JsonSerializer.Deserialize<Dictionary<string,Producto>>(miJSON);
        int countList = (int)productosList.Count(); 
        if(countList > 0){
            System.Console.WriteLine("Ingrese una cantidad de productos:");
            cantP = Convert.ToInt32(Console.ReadLine());
            for(int i = countList; i < cantP+countList; i++){
                System.Console.WriteLine("Producto {0}...", i+1);
                productosList.Add("Producto "+(i+1),new Producto());
            }
        }
    }else{
        //si el archivo es nuevo, carga los primeros productos
        System.Console.WriteLine("Ingrese una cantidad de productos:");
        cantP = Convert.ToInt32(Console.ReadLine());
        productosList = CargarProduct(cantP);
    }
        EscribirProductos(productosList,productJSON);
}

if(op == 2){
    miJSON = File.ReadAllText(productJSON);
    productosList = JsonSerializer.Deserialize<Dictionary<string,Producto>>(miJSON);
    foreach(var list in productosList){
        System.Console.WriteLine("{0}\n",list.Key);
        list.Value.MostrarDatos();
    }
}

static Dictionary<string,Producto> CargarProduct(int cantP){
    var newList = new Dictionary<string,Producto>();
    System.Console.WriteLine("Cargando productos...");
    for(int i = 0; i < cantP; i++){
        System.Console.WriteLine("Producto {0}...", i+1);
        newList.Add("Producto "+(i+1),new Producto());
    }
    return newList;
}

static void EscribirProductos(Dictionary<string,Producto> productList, string archivo){
    // StreamWriter con el parametro false, sobrescribe la lista
    using(StreamWriter sw = new StreamWriter(archivo,false)){
        string? jsonString = JsonSerializer.Serialize(productList);
        sw.Write(jsonString);
        sw.Close();
    }
}