using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MajorTest1
{

    struct InfoContent
    {
        public string type;
        public string name;
        public int duration;
        public string genre;

        public int mainRoleActorId;
        public int actorId;
        public int countryId;
    }

    public class Program
    {
        static async Task add(Context context, InfoContent info_local)
        {
            int mainActor = context.Actors
                .Where(c => c.Id == info_local.mainRoleActorId)
                .Select(c => c.Id)
                .FirstOrDefault();
            int actId = context.Actors
                 .Where(c => c.Id == info_local.actorId)
                .Select(c => c.Id)
                .FirstOrDefault();
            int countryId = context.Contents
                .Where(c => c.Id == info_local.countryId)
                .Select(c => c.Id)
                .FirstOrDefault();

            Console.WriteLine($"{mainActor}");
            if (mainActor != 0 && actId != 0 && countryId != 0)
            {
                context.Contents.Add(new Content()
                {
                    Name = info_local.name,
                    TypeOfContent = info_local.type,
                    Duration = info_local.duration,
                    Genre = info_local.genre,
                    MainRoleActorId = mainActor,
                    ActorId = actId,
                    CountryId = countryId
                });
            }
            context.SaveChangesAsync();
            printContent(context);
        }

        static async Task delete(Context context, int num)

        {
            // вывести и удалить по id     
            IQueryable<Content> info = from pr in context.Contents where pr.Id == num select pr;
            foreach (Content detail in info)
            {
                context.Contents.Remove(detail);
            }
            await context.SaveChangesAsync();
            printContent(context);
        }

        static async Task searchName(Context context, string name)
        {

            IQueryable<Content> info = from pr in context.Contents where pr.Name == name select pr;
            List<Content> list = info.ToList();
            Console.WriteLine($"Search by name");
            foreach (Content informations in info)
                Console.WriteLine($"{informations.Id} {informations.Name} {informations.TypeOfContent} " +
                    $"{informations.Name} {informations.ActorId} {informations.Genre}");
        }

        static async Task searchGenre(Context context, string gen)
        {

            IQueryable<Content> info = from pr in context.Contents where pr.Name == gen select pr;
            List<Content> list = info.ToList();
            Console.WriteLine($"Search by genre");
            foreach (Content informations in info)
                Console.WriteLine($"{informations.Id} {informations.Name} {informations.TypeOfContent} " +
                    $"{informations.Name} {informations.ActorId} {informations.Genre}");
        }


        static async Task searchActor(Context context, int actId)
        {
            int idType = context.Actors
                .Where(c => c.Id == actId)
                .Select(c => c.Id)
                .FirstOrDefault();

            Console.WriteLine($"Id type for search {idType}");

            IQueryable<Content> information = from pr in context.Contents where pr.ActorId == idType select pr;
            List<Content> list = information.ToList();
            Console.WriteLine($"Search by actor");
            foreach (Content informations in information)
                Console.WriteLine($"{informations.Id} {informations.Name} {informations.TypeOfContent} " +
                   $"{informations.Name} {informations.ActorId} {informations.Genre}");
        }

        static async Task searchMainActor(Context context, int actId)
        {
            int idType = context.Actors
                .Where(c => c.Id == actId)
                .Select(c => c.Id)
                .FirstOrDefault();

            Console.WriteLine($"Id for search {idType}");

            IQueryable<Content> information = from pr in context.Contents where pr.MainRoleActorId == idType select pr;
            List<Content> list = information.ToList();
            Console.WriteLine($"Search by main actor");
            foreach (Content informations in information)
                Console.WriteLine($"{informations.Id} {informations.Name} {informations.TypeOfContent} " +
                   $"{informations.Name} {informations.ActorId} {informations.Genre}");
        }

        static async Task searchByCountry(Context context, int countryId)
        {
            int idType = context.Countries
                .Where(c => c.Id == countryId)
                .Select(c => c.Id)
                .FirstOrDefault();

            Console.WriteLine($"Id for search {idType}");

            IQueryable<Content> information = from pr in context.Contents where pr.CountryId == idType select pr;
            List<Content> list = information.ToList();
            Console.WriteLine($"Search by country");
            foreach (Content informations in information)
                Console.WriteLine($"{informations.Id} {informations.Name} {informations.TypeOfContent} " +
                   $"{informations.Name} {informations.ActorId} {informations.Genre}");
        }

        static void printContent(Context context)
        {

            IQueryable<Content> content = from pr in context.Contents select pr;
            List<Content> list = content.ToList();
            Console.WriteLine($"APPLE TV CONTENT");
            foreach (Content info in content)
                Console.WriteLine($"{info.TypeOfContent} {info.Name} {info.MainRoleActorId} {info.Duration} {info.CountryId} {info.Genre} ");
        }

        static async Task Main (string[] args)
        {
            Context context = new Context();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();

            Console.WriteLine("Works with AppleTV DataBase");
            while (true)
            {
                Console.WriteLine("'1'-add content");
                Console.WriteLine("'2'-delete content");
                Console.WriteLine("'3'-search by film name");
                Console.WriteLine("'4'-search by actors");
                Console.WriteLine("'5'-search by main actor");
                Console.WriteLine("'6'-search by country creation");
                Console.WriteLine("'7'-search by genre");
                Console.WriteLine("'8'-print");
                Console.WriteLine("'9'-exit");
                Console.WriteLine("Enter command to continue:");
                string cmd = Console.ReadLine();

                InfoContent infoContent;
            switch (cmd)
            {
                case "1":
                        Console.WriteLine("Enter content type (film/series):");
                        infoContent.type = Console.ReadLine();
                        Console.WriteLine("Enter content name:");
                        infoContent.name = Console.ReadLine();
                        Console.WriteLine("Enter content duration(hrs):");
                        string dur = Console.ReadLine();
                        infoContent.duration = Convert.ToInt32(dur);
                        Console.WriteLine("Enter content genre:");
                        infoContent.genre = Console.ReadLine();


                        Console.WriteLine("Enter id of main actor:");
                        string id_main = Console.ReadLine();
                        infoContent.mainRoleActorId = Convert.ToInt32(id_main);
                        Console.WriteLine("Enter id of actor:");
                        string id_act = Console.ReadLine();
                        infoContent.actorId = Convert.ToInt32(id_act);
                        Console.WriteLine("Enter id of main actor:");
                        string id_cntry = Console.ReadLine();
                        infoContent.countryId = Convert.ToInt32(id_cntry);

                        await add(context, infoContent);
                        break;
                    case "2":
                        Console.WriteLine($"Enter id to delete:");
                        string cmd_del = Console.ReadLine();
                        int num = Convert.ToInt32(cmd_del);
                        printContent(context);
                        await delete(context, num);
                        break;
                    case "3":
                        //by name
                        Console.WriteLine($"Enter name for search:");
                        infoContent.name = Console.ReadLine();
                        await searchName(context, infoContent.name);
                        break;
                    case "4":
                        //by actor
                        Console.WriteLine("Enter actor id:");
                        string id_actor = Console.ReadLine();
                        infoContent.actorId = Convert.ToInt32(id_actor);
                        await searchActor(context, infoContent.actorId);
                        break;
                    case "5":
                        //by main actor
                        Console.WriteLine("Enter main actor id:");
                        string id_actor_main = Console.ReadLine();
                        infoContent.mainRoleActorId = Convert.ToInt32(id_actor_main);
                        await searchMainActor(context, infoContent.mainRoleActorId);
                        break;
                    case "6":
                        //by country
                        Console.WriteLine("Enter country id:");
                        string id_country = Console.ReadLine();
                        infoContent.countryId = Convert.ToInt32(id_country);
                        await searchByCountry(context, infoContent.countryId);
                        break;
                    case "7":
                        //by genre
                        Console.WriteLine($"Enter the genre for search:");
                        infoContent.genre = Console.ReadLine();
                        await searchGenre(context, infoContent.genre);
                        break;
                    case "8":
                        printContent(context);
                        break;
                    case "9":
                        Console.WriteLine("exit");
                        Environment.Exit(0);
                        break;
                    default:
                    Console.WriteLine("Invalid");
                    break;
                }
            }

        }
    }
}
