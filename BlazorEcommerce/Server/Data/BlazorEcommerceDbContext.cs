using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Server.Data
{
    public class BlazorEcommerceDbContext : DbContext
    {
        public BlazorEcommerceDbContext(DbContextOptions<BlazorEcommerceDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { 
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Title = "The Man in the High Castle",
                    Description = "The Man in the High Castle (1962), by Philip K. Dick, is an alternative history novel wherein the Axis Powers won World War II. The story occurs in 1962, fifteen years after the end of the war in 1947, and depicts the political intrigues between Imperial Japan and Nazi Germany as they rule the partitioned United States. The titular character is the author of a novel-within-the-novel entitled The Grasshopper Lies Heavy, itself also an alternative history of the war.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/Man_in_the_High_Castle_%281st_Edition%29.png",
                    Price = 9.99m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Title = "The Lost Daughter",
                    Description = "The Lost Daughter is a 2021 psychological drama film adapted for the screen and directed by Maggie Gyllenhaal (in her feature directorial debut) based on the 2006 novel of the same name by Elena Ferrante. The film stars Olivia Colman, Dakota Johnson, Jessie Buckley, Paul Mescal, Dagmara Domińczyk, Jack Farthing, Oliver Jackson-Cohen, with Peter Sarsgaard, and Ed Harris. Colman also serves as an executive producer.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/The_Lost_Daughter_%28film%29.jpg",
                    Price = 1.59m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 3,
                    Title = "The Terminal List",
                    Description = "The Terminal List is an American action thriller television series based on Jack Carr's 2018 novel of the same name.[1] The series tells the story of a Navy SEAL who seeks to avenge the murder of his family. It stars Chris Pratt (who also serves as an executive producer), Constance Wu, Taylor Kitsch, Riley Keough, Arlo Mertz, and Jeanne Tripplehorn.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ed/The_Terminal_List.jpeg",
                    Price = 4.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "The Matrix",
                    Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                    Price = 5.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Back to the Future",
                    Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                    Price = 7.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Toy Story",
                    Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                    Price = 15.99m,
                    CategoryId = 2

                },
                new Product
                {
                    Id = 7,
                    Title = "Half-Life 2",
                    Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                    Price = 23.99m,
                    CategoryId = 3

                },
                new Product
                {
                    Id = 8,
                    Title = "Diablo II",
                    Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                    Price = 21.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    Title = "Day of the Tentacle",
                    Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                    Price = 30.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 10,
                    Title = "Xbox",
                    Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    Price = 11.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 11,
                    Title = "Super Nintendo Entertainment System",
                    Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                    Price = 14.59m,
                    CategoryId = 3
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
