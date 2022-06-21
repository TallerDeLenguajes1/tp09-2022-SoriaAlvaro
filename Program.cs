
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
string path =@"/home/alvaro/Documentos/Taller1/tallerGit/tp09-2022-SoriaAlvaro/";
var archivos = new Dictionary<int,string>();
string indexJSON = path+@"index.json";
int i=0;
do{
    try{
        System.Console.WriteLine("Carpeta: {0}",path);
        getFiles(path,ref archivos,ref i);
        foreach(var carpetas in Directory.GetDirectories(path)){
            System.Console.WriteLine("Carpeta: {0}",carpetas);
            getFiles(carpetas,ref archivos,ref i);
        }  
        using(StreamWriter sw = new StreamWriter(indexJSON,true)){
            string jsonString = JsonSerializer.Serialize(archivos);
            sw.WriteLine(jsonString);
            sw.Close();
        }
    }catch(Exception error){
        System.Console.WriteLine("No ingresaste una ruta correta "+error.Message);
    }
}while(!Directory.Exists(path));

//funciones
static void getFiles(string carp, ref Dictionary<int,string> arch, ref int i){
    System.Console.WriteLine("Archivos:");
    foreach(var archivo in Directory.GetFiles(carp)){
        System.Console.WriteLine("\t{0}",Path.GetFileName(archivo));
        arch.Add(i,Path.GetFileName(archivo));
        i++;
    }
    System.Console.WriteLine("");
}