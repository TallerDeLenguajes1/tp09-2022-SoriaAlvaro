
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
string path =@"/home/alvaro/Documentos/Taller1/tallerGit/tp09-2022-SoriaAlvaro/";
/* string root =@"/home/alvaro/Documentos/Taller1/tallerGit/tp09-2022-SoriaAlvaro/JSON/"; */
var archivos = new List<string>();
var archivosV2 = new Dictionary<int,string>();
string indexJSON = Directory.GetCurrentDirectory()+@"/index.json";
string indexJSONV2 = Directory.GetCurrentDirectory()+@"/indexV2.json";
int i=0;
System.Console.WriteLine(Directory.GetCurrentDirectory());
do{
    try{
        System.Console.WriteLine(@"     Carpeta: "+path);
        foreach(var carpPrincipal in Directory.GetFiles(path)){
            System.Console.WriteLine(Path.GetFileName(carpPrincipal));
            archivos.Add(Path.GetFileName(carpPrincipal));
            archivosV2.Add(i++,Path.GetFileName(carpPrincipal));
        }
        foreach(var carpetas in Directory.GetDirectories(path)){
            System.Console.WriteLine(@"     Carpeta: "+carpetas);
            foreach(var archivo in Directory.GetFiles(carpetas)){
                System.Console.WriteLine(Path.GetFileName(archivo));
                archivos.Add(Path.GetFileName(archivo));
                archivosV2.Add(i++,Path.GetFileName(archivo));
            }
        }
        using(StreamWriter sw = new StreamWriter(indexJSON,true)){
            string jsonString = JsonSerializer.Serialize(archivos);
            sw.WriteLine(jsonString);
            sw.Close();
        }
        using(StreamWriter sw = new StreamWriter(indexJSONV2,true)){
            string jsonString = JsonSerializer.Serialize(archivosV2);
            sw.WriteLine(jsonString);
            sw.Close();
        }
        
    }catch(Exception error){
        System.Console.WriteLine("No ingresaste una ruta correta"+error.Message);
    }
}while(!Directory.Exists(path));